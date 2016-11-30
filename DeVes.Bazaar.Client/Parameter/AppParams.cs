using System;
using System.Collections.Generic;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace GP.UI.Mobile2.AppParameter
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
        private List<String> _lines = new List<string>();

        /// <summary>
        /// Voller Pfad und Name der Datei
        /// </summary>
        private String _fileName = "";

        /// <summary>
        /// Gibt an, welche Zeichen als Kommentarbeginn
        /// gewertet werden sollen. Dabei wird das erste 
        /// Zeichen defaultmäßig für neue Kommentare
        /// verwendet.
        /// </summary>
        private String _commentCharacters = "#;";

        /// <summary>
        /// Regulärer Ausdruck für einen Kommentar in einer Zeile
        /// </summary>
        private String _regCommentStr = "";

        /// <summary>
        /// Regulärer Ausdruck für einen Eintrag
        /// </summary>
        private Regex _regEntry;

        /// <summary>
        /// Regulärer Ausdruck für einen Bereichskopf
        /// </summary>
        private Regex _regCaption;

        /// <summary>
        /// Leerer Standard-Konstruktor
        /// </summary>
        public CfgFile()
        {
            _regCommentStr = @"(\s*[" + _commentCharacters + "](?<comment>.*))?";
            _regEntry = new Regex(@"^[ \t]*(?<entry>([^=])+)=(?<value>([^=" + _commentCharacters + "])+)" + _regCommentStr + "$");
            _regCaption = new Regex(@"^[ \t]*(\[(?<caption>([^\]])+)\]){1}" + _regCommentStr + "$");
        }

        /// <summary>
        /// Konstruktor, welcher sofort eine Datei einliest
        /// </summary>
        /// <param name="filename">Name der einzulesenden Datei</param>
        public CfgFile(string filename)
            : this()
        {
            _fileName = filename;
        }

        public Boolean Read()
        {
            if (!File.Exists(this._fileName))
                return false;

            using (var _sr = new StreamReader(_fileName))
            {
                while (!_sr.EndOfStream)
                {
                    _lines.Add(_sr.ReadLine().TrimEnd());
                }
            }

            return true;
        }

        /// <summary>
        /// Datei sichern
        /// </summary>
        /// <returns></returns>
        public Boolean Save()
        {
            if (_fileName == "") return false;
            try
            {
                using (var _sw = new StreamWriter(_fileName))
                    foreach (var _line in _lines)
                        _sw.WriteLine(_line);
            }
            catch (IOException _ex)
            {
                throw new IOException("Fehler beim Schreiben der Datei " + fileName, _ex);
            }
            catch
            {
                throw new IOException("Fehler beim Schreiben der Datei " + fileName);
            }
            return true;
        }

        /// <summary>
        /// Voller Name der Datei
        /// </summary>
        /// <returns></returns>
        public String fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Verzeichnis der Datei
        /// </summary>
        /// <returns></returns>
        public String GetDirectory()
        {
            return Path.GetDirectoryName(_fileName);
        }

        /// <summary>
        /// Sucht die Zeilennummer (nullbasiert) 
        /// eines gewünschten Eintrages
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>Nummer der Zeile, sonst -1</returns>
        private int SearchCaptionLine(String caption, Boolean caseSensitive)
        {
            if (!caseSensitive) caption = caption.ToLower();
            for (var _i = 0; _i < _lines.Count; _i++)
            {
                var _line = _lines[_i].Trim();
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
        private int SearchEntryLine(String caption, String entry, Boolean caseSensitive)
        {
            caption = caption.ToLower();
            if (!caseSensitive) entry = entry.ToLower();
            var _captionStart = SearchCaptionLine(caption, false);
            if (_captionStart < 0) return -1;
            for (var _i = _captionStart + 1; _i < _lines.Count; _i++)
            {
                var _line = _lines[_i].Trim();
                if (_line == "") continue;
                if (!caseSensitive) _line = _line.ToLower();
                if (_line.StartsWith("["))
                    return -1;// Ende, wenn der nächste Abschnitt beginnt
                if (Regex.IsMatch(_line, @"^[ \t]*[" + _commentCharacters + "]"))
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
        public Boolean CommentValue(String caption, String entry, Boolean caseSensitive)
        {
            var _line = SearchEntryLine(caption, entry, caseSensitive);
            if (_line < 0) return false;
            _lines[_line] = _commentCharacters[0] + _lines[_line];
            return true;
        }

        /// <summary>
        /// Löscht einen Wert
        /// </summary>
        /// <param name="caption">Name des Bereiches</param>
        /// <param name="entry">Name des Eintrages</param>
        /// <param name="caseSensitive">true = Gross-/Kleinschreibung beachten</param>
        /// <returns>true = Eintrag gefunden und gelöscht</returns>
        public Boolean DeleteValue(String caption, String entry, Boolean caseSensitive)
        {
            var _line = SearchEntryLine(caption, entry, caseSensitive);
            if (_line < 0) return false;
            _lines.RemoveAt(_line);
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
        public String GetValue(String caption, String entry, Boolean caseSensitive)
        {
            var _line = SearchEntryLine(caption, entry, caseSensitive);
            if (_line < 0) return "";
            var _pos = _lines[_line].IndexOf("=");
            if (_pos < 0) return "";
            return _lines[_line].Substring(_pos + 1).Trim();
            // Evtl. noch abschliessende Kommentarbereiche entfernen
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
        public Boolean SetValue(String caption, String entry, String value, Boolean caseSensitive)
        {
            caption = caption.ToLower();
            if (!caseSensitive) entry = entry.ToLower();
            var _lastCommentedFound = -1;
            var _captionStart = SearchCaptionLine(caption, false);
            if (_captionStart < 0)
            {
                _lines.Add("[" + caption + "]");
                _lines.Add(entry + "=" + value);
                return true;
            }
            var _entryLine = SearchEntryLine(caption, entry, caseSensitive);
            for (var _i = _captionStart + 1; _i < _lines.Count; _i++)
            {
                var _line = _lines[_i].Trim();
                if (!caseSensitive) _line = _line.ToLower();
                if (_line == "") continue;
                // Ende, wenn der nächste Abschnitt beginnt
                if (_line.StartsWith("["))
                {
                    _lines.Insert(_i, entry + "=" + value);
                    return true;
                }
                // Suche aukommentierte, aber gesuchte Einträge
                // (evtl. per Parameter bestimmen können?), falls
                // der Eintrag noch nicht existiert.
                if (_entryLine < 0)
                    if (Regex.IsMatch(_line, @"^[ \t]*[" + _commentCharacters + "]"))
                    {
                        var _tmpLine = _line.Substring(1).Trim();
                        if (_tmpLine.StartsWith(entry))
                        {
                            // Werte vergleichen, wenn gleich,
                            // nur Kommentarzeichen löschen
                            var _pos = _tmpLine.IndexOf("=");
                            if (_pos > 0)
                            {
                                if (value == _tmpLine.Substring(_pos + 1).Trim())
                                {
                                    _lines[_i] = _tmpLine;
                                    return true;
                                }
                            }
                            _lastCommentedFound = _i;
                        }
                        continue;// Kommentar
                    }
                if (_line.StartsWith(entry))
                {
                    _lines[_i] = entry + "=" + value;
                    return true;
                }
            }
            if (_lastCommentedFound > 0)
                _lines.Insert(_lastCommentedFound + 1, entry + "=" + value);
            else
                _lines.Insert(_captionStart + 1, entry + "=" + value);
            return true;
        }

        public Boolean ExistValue(String caption, String entry, Boolean caseSensitive)
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
        public SortedList<String, String> GetCaption(String caption)
        {
            var _result = new SortedList<string, string>();
            var _captionFound = false;
            for (var _i = 0; _i < _lines.Count; _i++)
            {
                var _line = _lines[_i].Trim();
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
                if (Regex.IsMatch(_line, @"^[ \t]*[" + _commentCharacters + "]")) continue; // Kommentar
                var _pos = _line.IndexOf("=");
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
            var _result = new List<string>();
            for (var _i = 0; _i < _lines.Count; _i++)
            {
                var _line = _lines[_i];
                var _mCaption = _regCaption.Match(_lines[_i]);
                if (_mCaption.Success)
                    _result.Add(_mCaption.Groups["caption"].Value.Trim());
            }
            return _result;
        }

        /// <summary>
        /// Exportiert sämtliche Bereiche und deren Werte
        /// in ein XML-Dokument
        /// </summary>
        /// <returns>XML-Dokument</returns>
        public XmlDocument ExportToXml()
        {
            var _doc = new XmlDocument();
            var _root = _doc.CreateElement(
                Path.GetFileNameWithoutExtension(this.fileName));
            _doc.AppendChild(_root);
            XmlElement _caption = null;
            for (var _i = 0; _i < _lines.Count; _i++)
            {
                var _mEntry = _regEntry.Match(_lines[_i]);
                var _mCaption = _regCaption.Match(_lines[_i]);
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
