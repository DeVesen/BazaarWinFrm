using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace DeVes.Bazaar.Server.Parameter
{
    #region . CfgFile .

    /// <summary>
    /// Klasse, um Dateien im Ini-Format
    /// zu verwalten.
    /// </summary>
    public class CfgFile
    {
        /// <summary>
        /// Inhalt der Datei
        /// </summary>
        private readonly List<string> m_lines = new List<string>();

        /// <summary>
        /// Voller Pfad und Name der Datei
        /// </summary>
        private string m_fileName = "";

        /// <summary>
        /// Gibt an, welche Zeichen als Kommentarbeginn
        /// gewertet werden sollen. Dabei wird das erste 
        /// Zeichen defaultmäßig für neue Kommentare
        /// verwendet.
        /// </summary>
        private string m_commentCharacters = "#;";

        /// <summary>
        /// Regulärer Ausdruck für einen Eintrag
        /// </summary>
        private Regex m_regEntry;

        /// <summary>
        /// Regulärer Ausdruck für einen Bereichskopf
        /// </summary>
        private Regex m_regCaption;

        /// <summary>
        /// Leerer Standard-Konstruktor
        /// </summary>
        public CfgFile()
        {
            var _regCommentStr = @"(\s*[" + m_commentCharacters + "](?<comment>.*))?";
            m_regEntry = new Regex(@"^[ \t]*(?<entry>([^=])+)=(?<value>([^=" + m_commentCharacters + "])+)" + _regCommentStr + "$");
            m_regCaption = new Regex(@"^[ \t]*(\[(?<caption>([^\]])+)\]){1}" + _regCommentStr + "$");
        }

        /// <summary>
        /// Konstruktor, welcher sofort eine Datei einliest
        /// </summary>
        /// <param name="filename">Name der einzulesenden Datei</param>
        public CfgFile(string filename)
            : this()
        {
            m_fileName = filename;
        }

        public bool Read()
        {
            m_lines.Clear();

            if (!File.Exists(this.m_fileName))
                return false;

            using (var _sr = new StreamReader(m_fileName))
            {
                while (!_sr.EndOfStream)
                {
                    m_lines.Add((_sr.ReadLine() ?? string.Empty).TrimEnd());
                }
            }

            return true;
        }

        /// <summary>
        /// Datei sichern
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (m_fileName == "") return false;
            try
            {
                using (var _sw = new StreamWriter(m_fileName))
                    foreach (var _line in m_lines)
                        _sw.WriteLine(_line);
            }
            catch (IOException _ex)
            {
                throw new IOException("Fehler beim Schreiben der Datei " + FileName, _ex);
            }
            catch
            {
                throw new IOException("Fehler beim Schreiben der Datei " + FileName);
            }
            return true;
        }

        /// <summary>
        /// Voller Name der Datei
        /// </summary>
        /// <returns></returns>
        public string FileName
        {
            get { return m_fileName; }
            set { m_fileName = value; }
        }

        /// <summary>
        /// Verzeichnis der Datei
        /// </summary>
        /// <returns></returns>
        public string GetDirectory()
        {
            return Path.GetDirectoryName(m_fileName);
        }

        /// <summary>
        /// Sucht die Zeilennummer (nullbasiert) 
        /// eines gewünschten Eintrages
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>Nummer der Zeile, sonst -1</returns>
        private int SearchCaptionLine(string caption, bool caseSensitive)
        {
            if (!caseSensitive) caption = caption.ToLower();
            for (var _i = 0; _i < m_lines.Count; _i++)
            {
                var _line = m_lines[_i].Trim();
                if (_line == "") continue;
                if (!caseSensitive) _line = _line.ToLower();
                // Erst den gewünschten Abschnitt suchen
                if (_line == "[" + caption + "]")
                    return _i;
            }
            return -1;// Bereich nicht gefunden
        }

        /// <summary>
        /// Sucht die Zeilennummer (nullbasiert) 
        /// eines gewünschten Eintrages
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="entry">Name des Eintrages</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>Nummer der Zeile, sonst -1</returns>
        private int SearchEntryLine(string caption, string entry, bool caseSensitive)
        {
            caption = caption.ToLower();
            if (!caseSensitive) entry = entry.ToLower();
            var _captionStart = SearchCaptionLine(caption, false);
            if (_captionStart < 0) return -1;
            for (var _i = _captionStart + 1; _i < m_lines.Count; _i++)
            {
                var _line = m_lines[_i].Trim();
                if (_line == "") continue;
                if (!caseSensitive) _line = _line.ToLower();
                if (_line.StartsWith("["))
                    return -1;// Ende, wenn der nächste Abschnitt beginnt
                if (Regex.IsMatch(_line, @"^[ \t]*[" + m_commentCharacters + "]"))
                    continue; // Kommentar
                if (_line.StartsWith(entry))
                    return _i;// Eintrag gefunden
            }
            return -1;// Eintrag nicht gefunden
        }

        /// <summary>
        /// Kommentiert einen Wert aus
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="entry">Name des Eintrages</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>true = Eintrag gefunden und auskommentiert</returns>
        public bool CommentValue(string caption, string entry, bool caseSensitive)
        {
            var _line = SearchEntryLine(caption, entry, caseSensitive);
            if (_line < 0) return false;
            m_lines[_line] = m_commentCharacters[0] + m_lines[_line];
            return true;
        }

        /// <summary>
        /// Löscht einen Wert
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="entry">Name des Eintrages</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>true = Eintrag gefunden und gelöscht</returns>
        public bool DeleteValue(string caption, string entry, bool caseSensitive)
        {
            var _line = SearchEntryLine(caption, entry, caseSensitive);
            if (_line < 0) return false;
            m_lines.RemoveAt(_line);
            return true;
        }

        /// <summary>
        /// Liest den Wert eines Eintrages aus
        /// (Erweiterung: case sensitive)
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="entry">Name des Eintrages</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>Wert des Eintrags oder leer</returns>
        public string GetValue(string caption, string entry, bool caseSensitive)
        {
            var _line = SearchEntryLine(caption, entry, caseSensitive);

            if (_line < 0) return "";

            var _pos = (m_lines[_line] ?? string.Empty).IndexOf("=", StringComparison.Ordinal);

            return _pos < 0 ? "" : (m_lines[_line] ?? string.Empty).Substring(_pos + 1).Trim();
        }

        public string getValue_AsString(string caption, string entry, string defaultValue)
        {
            try
            {
                var _result = GetValue(caption, entry, false);
                if (!string.IsNullOrEmpty(_result) && !string.IsNullOrEmpty(_result.Trim()))
                {
                    return _result;
                }
            }
            catch
            {
                // ignored
            }
            return defaultValue;
        }

        public double getValue_AsdDouble(string caption, string entry, double defaultValue)
        {
            return this.getValue_AsdDouble(caption, entry, null) ?? defaultValue;
        }
        public double? getValue_AsdDouble(string caption, string entry, double? defaultValue)
        {
            try
            {
                return Convert.ToDouble(GetValue(caption, entry, false));
            }
            catch
            {
                // ignored
            }
            return defaultValue;
        }

        public bool getValue_AsBool(string caption, string entry, bool defaultValue)
        {
            return this.getValue_AsBool(caption, entry, null) ?? defaultValue;
        }
        public bool? getValue_AsBool(string caption, string entry, bool? defaultValue)
        {
            try
            {
                return Convert.ToBoolean(GetValue(caption, entry, false));
            }
            catch
            {
                // ignored
            }
            return defaultValue;
        }

        public int getValue_AsInt(string caption, string entry, int defaultValue)
        {
            return this.getValue_AsInt(caption, entry, null) ?? defaultValue;
        }
        public int? getValue_AsInt(string caption, string entry, int? defaultValue)
        {
            try
            {
                var _value = GetValue(caption, entry, false);
                return Convert.ToInt32(_value);
            }
            catch
            {
                // ignored
            }
            return defaultValue;
        }

        public DateTime getValue_AsDateTime(string caption, string entry, bool caseSensitive, DateTime defaultValue)
        {
            return this.getValue_AsDateTime(caption, entry, caseSensitive, null) ?? defaultValue;
        }
        public DateTime? getValue_AsDateTime(string caption, string entry, bool caseSensitive, DateTime? defaultValue)
        {
            try
            {
                return Convert.ToDateTime(GetValue(caption, entry, caseSensitive));
            }
            catch
            {
                // ignored
            }
            return defaultValue;
        }

        /// <summary>
        /// Setzt einen Wert in einem Bereich. Wenn der Wert
        /// (und der Bereich) noch nicht existiert, werden die
        /// entsprechenden Einträge erstellt.
        /// </summary>
        /// <param name="caption">Name des Bereichs</param>
        /// <param name="entry">name des Eintrags</param>
        /// <param name="value">Wert des Eintrags</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>true = Eintrag erfolgreich gesetzt</returns>
        private bool _setValue(string caption, string entry, string value, bool caseSensitive)
        {
            caption = caption.ToLower();
            if (!caseSensitive) entry = entry.ToLower();
            var _lastCommentedFound = -1;
            var _captionStart = SearchCaptionLine(caption, false);
            if (_captionStart < 0)
            {
                m_lines.Add("[" + caption + "]");
                m_lines.Add(entry + "=" + value);
                return true;
            }
            var _entryLine = SearchEntryLine(caption, entry, caseSensitive);
            for (var _i = _captionStart + 1; _i < m_lines.Count; _i++)
            {
                var _line = m_lines[_i].Trim();
                if (!caseSensitive) _line = _line.ToLower();
                if (_line == "") continue;
                // Ende, wenn der nächste Abschnitt beginnt
                if (_line.StartsWith("["))
                {
                    m_lines.Insert(_i, entry + "=" + value);
                    return true;
                }
                // Suche aukommentierte, aber gesuchte Einträge
                // (evtl. per Parameter bestimmen können?), falls
                // der Eintrag noch nicht existiert.
                if (_entryLine < 0)
                    if (Regex.IsMatch(_line, @"^[ \t]*[" + m_commentCharacters + "]"))
                    {
                        var _tmpLine = _line.Substring(1).Trim();
                        if (_tmpLine.StartsWith(entry))
                        {
                            // Werte vergleichen, wenn gleich,
                            // nur Kommentarzeichen löschen
                            var _pos = _tmpLine.IndexOf("=", StringComparison.Ordinal);
                            if (_pos > 0)
                            {
                                if (value == _tmpLine.Substring(_pos + 1).Trim())
                                {
                                    m_lines[_i] = _tmpLine;
                                    return true;
                                }
                            }
                            _lastCommentedFound = _i;
                        }
                        continue;// Kommentar
                    }
                if (_line.StartsWith(entry))
                {
                    m_lines[_i] = entry + "=" + value;
                    return true;
                }
            }
            if (_lastCommentedFound > 0)
                m_lines.Insert(_lastCommentedFound + 1, entry + "=" + value);
            else
                m_lines.Insert(_captionStart + 1, entry + "=" + value);
            return true;
        }
        
        public bool SetValue(string caption, string entry, string value)
        {
            this.DeleteValue(caption, entry, true);
            return this._setValue(caption, entry, value, true);
        }
        public bool SetValue(string caption, string entry, bool value)
        {
            this.DeleteValue(caption, entry, true);
            return this._setValue(caption, entry, value ? "true" : "false", true);
        }
        public bool SetValue(string caption, string entry, int value)
        {
            this.DeleteValue(caption, entry, true);
            return this._setValue(caption, entry, value.ToString(), true);
        }
        public bool SetValue(string caption, string entry, double value)
        {
            this.DeleteValue(caption, entry, true);
            return this._setValue(caption, entry, value.ToString(CultureInfo.InvariantCulture), true);
        }
        public bool SetValue(string caption, string entry, DateTime value)
        {
            this.DeleteValue(caption, entry, true);
            return this._setValue(caption, entry, value.ToString(CultureInfo.InvariantCulture), true);
        }

        public bool ExistValue(string caption, string entry, bool caseSensitive)
        {
            if (this.SearchCaptionLine(caption, caseSensitive) >= 0)
            {
                if (this.SearchEntryLine(caption, entry, caseSensitive) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Liest alle Einträge uns deren Werte eines Bereiches aus
        /// </summary>
        /// <param name="caption">Name des Bereichs</param>
        /// <returns>Sortierte Liste mit Einträgen und Werten</returns>
        public SortedList<string, string> GetCaption(string caption)
        {
            var _result = new SortedList<string, string>();
            var _captionFound = false;
            for (var _i = 0; _i < m_lines.Count; _i++)
            {
                var _line = m_lines[_i].Trim();
                if (_line == "") continue;
                // Erst den gewünschten Abschnitt suchen
                if (!_captionFound)
                    if (_line.ToLower() != "[" + caption + "]") continue;
                    else
                    {
                        _captionFound = true;
                        continue;
                    }
                // Ende, wenn der nächste Abschnitt beginnt
                if (_line.StartsWith("[")) break;
                if (Regex.IsMatch(_line, @"^[ \t]*[" + m_commentCharacters + "]")) continue; // Kommentar
                var _pos = _line.IndexOf("=", StringComparison.Ordinal);
                if (_pos < 0)
                    _result.Add(_line, "");
                else
                    _result.Add(_line.Substring(0, _pos).Trim(), _line.Substring(_pos + 1).Trim());
            }
            return _result;
        }

        /// <summary>
        /// Erstellt eine Liste aller enthaltenen Bereiche
        /// </summary>
        /// <returns>Liste mit gefundenen Bereichen</returns>
        public List<string> GetAllCaptions()
        {
            return (
                    from _t in m_lines
                    select m_regCaption.Match(_t) into _mCaption
                        where _mCaption.Success
                    select _mCaption.Groups["caption"].Value.Trim()
                   ).ToList();
        }

        /// <summary>
        /// Exportiert sämtliche Bereiche und deren Werte
        /// in ein XML-Dokument
        /// </summary>
        /// <returns>XML-Dokument</returns>
        public XmlDocument ExportToXml()
        {
            var _doc = new XmlDocument();
            // ReSharper disable once AssignNullToNotNullAttribute
            var _root = _doc.CreateElement(Path.GetFileNameWithoutExtension(this.FileName));
            _doc.AppendChild(_root);

            XmlElement _caption = null;

            foreach (string _t in m_lines)
            {
                var _mEntry = m_regEntry.Match(_t);
                var _mCaption = m_regCaption.Match(_t);
                if (_mCaption.Success)
                {
                    _caption = _doc.CreateElement(_mCaption.Groups["caption"].Value.Trim());
                    _root.AppendChild(_caption);
                    continue;
                }
                if (_mEntry.Success)
                {
                    var _xe = _doc.CreateElement(_mEntry.Groups["entry"].Value.Trim());
                    _xe.InnerXml = _mEntry.Groups["value"].Value.Trim();
                    if (_caption == null)
                        _root.AppendChild(_xe);
                    else
                        _caption.AppendChild(_xe);
                }
            }
            return _doc;
        }
    }

    #endregion . CfgFile .
}
