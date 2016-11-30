using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DVes.Basar.Data.Tables
{
    internal class BasicTable : DataTable
    {
        public virtual string GetXmlFileName()
        {
            return this.TableName + "Table.xml";
        }
        public virtual bool SetDefaultRows()
        {
            return false;
        }

        public static T OpenDataTable<T>(string openFromFolder) where T : BasicTable, new()
        {
            T _result = new T();

            string _readPath = System.IO.Path.Combine(openFromFolder, _result.GetXmlFileName());

            if (System.IO.File.Exists(_readPath))
            {
                _result.ReadXml(_readPath);
            }

            if (_result.Rows.Count <= 0)
            {
                if (_result.SetDefaultRows())
                {
                    _result.SaveDataTable(openFromFolder);
                }
            }

            return _result;
        }

        public void SaveDataTable(string folderSaveTo)
        {
            string _finalPath = System.IO.Path.Combine(folderSaveTo, this.GetXmlFileName());
            this.WriteXml(_finalPath);
        }
    }
}
