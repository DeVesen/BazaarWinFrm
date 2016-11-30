using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net;

namespace DeVes.Bazaar.Data.Security
{
    public class GandingSecurity
    {
        public static List<Dictionary<string, object>> GetPhysicalDrives(bool notNull)
        {
            List<Dictionary<string, object>> _drives = new List<Dictionary<string, object>>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
            ManagementObjectCollection _wmi_HD_objects001 = searcher.Get();

            foreach (ManagementObject share in searcher.Get())
            {
                Dictionary<string, object> _drive = new Dictionary<string, object>();
                foreach (PropertyData PC in share.Properties)
                {
                    if (notNull && PC.Value != null)
                    {
                        _drive[PC.Name] = PC.Value;
                    }
                    else if (!notNull)
                    {
                        _drive[PC.Name] = PC.Value;
                    }
                }
                _drives.Add(_drive);
            }

            return _drives;
        }
        public static List<Dictionary<string, object>> GetPhysicalProcessors(bool notNull)
        {
            List<Dictionary<string, object>> _drives = new List<Dictionary<string, object>>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            ManagementObjectCollection _wmi_HD_objects001 = searcher.Get();

            foreach (ManagementObject share in searcher.Get())
            {
                Dictionary<string, object> _drive = new Dictionary<string, object>();
                foreach (PropertyData PC in share.Properties)
                {
                    if (notNull && PC.Value != null)
                    {
                        _drive[PC.Name] = PC.Value;
                    }
                    else if (!notNull)
                    {
                        _drive[PC.Name] = PC.Value;
                    }
                }
                _drives.Add(_drive);
            }

            return _drives;
        }

        public static string CreateBaseAccessCode()
        {
            string _pcName = Dns.GetHostName();
            string _processorInfos = GandingSecurity.GetGroundInfosOfProcessor();
            string _driveInfos = GandingSecurity.GetGroundInfosOflDrive();

            //Verteilen
            string _orgVert = GandingSecurity.TotalitySplitt((_pcName + _processorInfos + _driveInfos).ToUpper());

            //Finaler String
            string _verschluesselt = Encryption.EncryptString(_orgVert, "23BDA0CD");//"7498D128-23BD-4D80-A0CD-DFAAF12719BC");

            //Verteilen
            string _vershVert = GandingSecurity.TotalitySplitt(_verschluesselt).ToUpper();

            return _vershVert;
        }
        public static Dictionary<string, string> CheckLizence(string lizensStream, string pcCode)
        {
            Dictionary<string, string> _return = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(lizensStream) && !string.IsNullOrEmpty(lizensStream.Trim()))
            {
                int _baseKeyLengthHalf = pcCode.Length / 2;
                string _baseLeft = pcCode.Substring(0, _baseKeyLengthHalf);
                string _baseRight = pcCode.Substring(_baseKeyLengthHalf);
                string _deKey = _baseRight + "-7498D128-23BD-4D80-A0CD-DFAAF12719BC-" + _baseLeft;

                string _encriptedStream = Encryption.DecryptString(lizensStream, _deKey);

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

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            ManagementObjectCollection _wmi_HD_objects001 = searcher.Get();

            foreach (ManagementObject share in searcher.Get())
            {
                _result += share.Properties["Name"].Value.ToString();
                _result += share.Properties["ProcessorId"].Value.ToString();

                break;
            }

            return _result;
        }
        private static string GetGroundInfosOflDrive()
        {
            string _result = null;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_DiskDrive");
            ManagementObjectCollection _wmi_HD_objects001 = searcher.Get();

            foreach (ManagementObject share in searcher.Get())
            {
                _result += share.Properties["Model"].Value.ToString();
                _result += share.Properties["SerialNumber"].Value.ToString();

                break;
            }

            return _result;
        }

        private static List<string> SplitInSubLists(string valueToSplit, int splitCounter)
        {
            List<string> _result = new List<string>();

            int _length = valueToSplit.Length;
            int _half = _length / 2;

            if (_half > 1)
            {
                string _left = valueToSplit.Substring(0, _half);
                string _right = valueToSplit.Substring(_half);

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
            for (int _index01 = 0; _index01 < list01.Count; _index01++)
            {
                if (_index01 < list02.Count)
                {
                    string _nextelement = list02[_index01];
                    list02[_index01] = list01[_index01];
                    list01[_index01] = _nextelement;
                }
            }
        }
        private static List<string> RotateInList(List<string> list)
        {
            for (int _index01 = 0; _index01 < list.Count; _index01 += 2)
            {
                if (_index01 + 1 < list.Count)
                {
                    string _nextelement = list[_index01 + 1];
                    list[_index01 + 1] = list[_index01];
                    list[_index01] = _nextelement;
                }
            }

            return list;
        }
        private static List<List<string>> SplitSplit(string stream, int firstSplit)
        {
            List<string> _splitted = GandingSecurity.SplitInSubLists(stream, firstSplit);
            List<List<string>> _listSplittered = new List<List<string>>();
            int _listsBerQuat = _splitted.Count / 4;
            for (int _i = 0; _i < 4; _i++)
            {
                List<string> _partList = new List<string>();
                _listSplittered.Add(_partList);
                int _toElements = System.Math.Min((_i + 1) * _listsBerQuat, _splitted.Count);
                for (int _y = _i * _listsBerQuat; _y < _toElements; _y++)
                {
                    _partList.Add(_splitted[_y]);
                }
            }

            //Rotation der Sub-Sub Listen
            List<string> _pl000 = _listSplittered[0];
            List<string> _pl001 = _listSplittered[1];
            List<string> _pl002 = _listSplittered[2];
            List<string> _pl003 = _listSplittered[3];
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
            List<List<string>> _listSplittered001 = GandingSecurity.SplitSplit(baseStream, 2);

            //String Wieder zusammen Setzten
            StringBuilder _stream001 = new StringBuilder();
            foreach (List<string> _subList in _listSplittered001)
            {
                foreach (string _string in _subList)
                {
                    _stream001.Append(_string);
                }
            }

            //Aufteilen in wieder kleinere
            List<List<string>> _listSplittered002 = GandingSecurity.SplitSplit(_stream001.ToString(), 4);

            //String Wieder zusammen Setzten
            StringBuilder _stream002 = new StringBuilder();
            foreach (List<string> _subList in _listSplittered001)
            {
                foreach (string _string in _subList)
                {
                    _stream002.Append(_string);
                }
            }

            //Aufteilen in wieder kleinere
            List<List<string>> _listSplittered003 = GandingSecurity.SplitSplit(_stream002.ToString(), 8);

            //Finaler string
            StringBuilder _finalStream = new StringBuilder();
            foreach (List<string> _subList in _listSplittered003)
            {
                for(int _i = 0; _i < _subList.Count; _i += 6)
                {
                    _finalStream.Append(_subList[_i]);
                }
            }

            return _finalStream.ToString();
        }

        private static string IncreaseToChars(string value, int totalChars)
        {
            while (value.Length <= totalChars)
            {
                value += "#";
            }

            return value;
        }
    }
}
