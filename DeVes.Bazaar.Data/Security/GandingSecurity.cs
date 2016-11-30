using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Net;

namespace DeVes.Bazaar.Data.Security
{
    public class GandingSecurity
    {
        public static List<Dictionary<string, object>> GetPhysicalDrives(bool notNull)
        {
            var _drives = new List<Dictionary<string, object>>();

            var _searcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");

            foreach (var _share in _searcher.Get())
            {
                var _drive = new Dictionary<string, object>();
                foreach (var _pc in _share.Properties)
                {
                    if (notNull && _pc.Value != null)
                    {
                        _drive[_pc.Name] = _pc.Value;
                    }
                    else if (!notNull)
                    {
                        _drive[_pc.Name] = _pc.Value;
                    }
                }
                _drives.Add(_drive);
            }

            return _drives;
        }
        public static List<Dictionary<string, object>> GetPhysicalProcessors(bool notNull)
        {
            var _drives = new List<Dictionary<string, object>>();

            var _searcher = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (var _share in _searcher.Get())
            {
                var _drive = new Dictionary<string, object>();
                foreach (var _pc in _share.Properties)
                {
                    if (notNull && _pc.Value != null)
                    {
                        _drive[_pc.Name] = _pc.Value;
                    }
                    else if (!notNull)
                    {
                        _drive[_pc.Name] = _pc.Value;
                    }
                }
                _drives.Add(_drive);
            }

            return _drives;
        }

        public static string CreateBaseAccessCode()
        {
            var _pcName = Dns.GetHostName();
            var _processorInfos = GandingSecurity.GetGroundInfosOfProcessor();
            var _driveInfos = GandingSecurity.GetGroundInfosOflDrive();

            //Verteilen
            var _orgVert = GandingSecurity.TotalitySplitt((_pcName + _processorInfos + _driveInfos).ToUpper());

            //Finaler String
            var _verschluesselt = Encryption.EncryptString(_orgVert, "23BDA0CD");//"7498D128-23BD-4D80-A0CD-DFAAF12719BC");

            //Verteilen
            var _vershVert = GandingSecurity.TotalitySplitt(_verschluesselt).ToUpper();

            return _vershVert;
        }
        public static Dictionary<string, string> CheckLizence(string lizensStream, string pcCode)
        {
            var _return = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(lizensStream) && !string.IsNullOrEmpty(lizensStream.Trim()))
            {
                var _baseKeyLengthHalf = pcCode.Length / 2;
                var _baseLeft = pcCode.Substring(0, _baseKeyLengthHalf);
                var _baseRight = pcCode.Substring(_baseKeyLengthHalf);
                var _deKey = _baseRight + "-7498D128-23BD-4D80-A0CD-DFAAF12719BC-" + _baseLeft;

                var _encriptedStream = Encryption.DecryptString(lizensStream, _deKey);

                if (_encriptedStream.StartsWith(_baseRight + ":") && _encriptedStream.EndsWith(":" + _baseLeft))
                {
                    _return["IsActivated"] = null;
                }
            }

            return _return;
        }

        private static string GetGroundInfosOfProcessor()
        {
            string _result = null;

            var _searcher = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (var _share in _searcher.Get())
            {
                _result += _share.Properties["Name"].Value.ToString();
                _result += _share.Properties["ProcessorId"].Value.ToString();

                break;
            }

            return _result;
        }
        private static string GetGroundInfosOflDrive()
        {
            string _result = null;

            var _searcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");

            foreach (var _share in _searcher.Get())
            {
                _result += _share.Properties["Model"].Value.ToString();
                _result += _share.Properties["SerialNumber"].Value.ToString();

                break;
            }

            return _result;
        }

        private static List<string> SplitInSubLists(string valueToSplit, int splitCounter)
        {
            var _result = new List<string>();

            var _length = valueToSplit.Length;
            var _half = _length / 2;

            if (_half > 1)
            {
                var _left = valueToSplit.Substring(0, _half);
                var _right = valueToSplit.Substring(_half);

                if (splitCounter >= 0)
                {
                    _result.AddRange(GandingSecurity.SplitInSubLists(_left, splitCounter - 1));
                    _result.AddRange(GandingSecurity.SplitInSubLists(_right, splitCounter - 1));
                }
                else
                {
                    _result.Add(_left);
                    _result.Add(_right);
                }
            }
            else
            {
                _result.Add(valueToSplit);
            }

            return _result;
        }
        private static void RotateLists(ref List<string> list01, ref List<string> list02)
        {
            for (var _index01 = 0; _index01 < list01.Count; _index01++)
            {
                if (_index01 < list02.Count)
                {
                    var _nextelement = list02[_index01];
                    list02[_index01] = list01[_index01];
                    list01[_index01] = _nextelement;
                }
            }
        }
        private static List<string> RotateInList(List<string> list)
        {
            for (var _index01 = 0; _index01 < list.Count; _index01 += 2)
            {
                if (_index01 + 1 < list.Count)
                {
                    var _nextelement = list[_index01 + 1];
                    list[_index01 + 1] = list[_index01];
                    list[_index01] = _nextelement;
                }
            }

            return list;
        }
        private static List<List<string>> SplitSplit(string stream, int firstSplit)
        {
            var _splitted = GandingSecurity.SplitInSubLists(stream, firstSplit);
            var _listSplittered = new List<List<string>>();
            var _listsBerQuat = _splitted.Count / 4;
            for (var _i = 0; _i < 4; _i++)
            {
                var _partList = new List<string>();
                _listSplittered.Add(_partList);
                var _toElements = System.Math.Min((_i + 1) * _listsBerQuat, _splitted.Count);
                for (var _y = _i * _listsBerQuat; _y < _toElements; _y++)
                {
                    _partList.Add(_splitted[_y]);
                }
            }

            //Rotation der Sub-Sub Listen
            var _pl000 = _listSplittered[0];
            var _pl001 = _listSplittered[1];
            var _pl002 = _listSplittered[2];
            var _pl003 = _listSplittered[3];
            RotateLists(ref _pl000, ref _pl002);
            RotateLists(ref _pl001, ref _pl003);
            _listSplittered[0] = _pl000;
            _listSplittered[1] = _pl001;
            _listSplittered[2] = _pl002;
            _listSplittered[3] = _pl003;

            //Rotation der Sub Listen
            _listSplittered[0] = GandingSecurity.RotateInList(_pl000);
            _listSplittered[1] = GandingSecurity.RotateInList(_pl001);
            _listSplittered[2] = GandingSecurity.RotateInList(_pl002);
            _listSplittered[3] = GandingSecurity.RotateInList(_pl003);

            return _listSplittered;
        }
        private static string TotalitySplitt(string baseStream)
        {
            var _listSplittered001 = GandingSecurity.SplitSplit(baseStream, 2);

            //String Wieder zusammen Setzten
            var _stream001 = new StringBuilder();
            foreach (var _subList in _listSplittered001)
            {
                foreach (var _string in _subList)
                {
                    _stream001.Append(_string);
                }
            }

            //Aufteilen in wieder kleinere
            GandingSecurity.SplitSplit(_stream001.ToString(), 4);

            //String Wieder zusammen Setzten
            var _stream002 = new StringBuilder();
            foreach (var _subList in _listSplittered001)
            {
                foreach (var _string in _subList)
                {
                    _stream002.Append(_string);
                }
            }

            //Aufteilen in wieder kleinere
            var _listSplittered003 = GandingSecurity.SplitSplit(_stream002.ToString(), 8);

            //Finaler string
            var _finalStream = new StringBuilder();
            foreach (var _subList in _listSplittered003)
            {
                for(var _i = 0; _i < _subList.Count; _i += 6)
                {
                    _finalStream.Append(_subList[_i]);
                }
            }

            return _finalStream.ToString();
        }
    }
}
