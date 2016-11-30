using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DeVes.Bazaar.Data.Tables
{
    internal class MaterialCategoryTable : BasicTable
    {
        public MaterialCategoryTable()
        {
            this.TableName = "MaterialCategory";

            this.Columns.Add("Id", typeof(string));

            this.Columns.Add("Designation", typeof(string));
        }

        public DataRow FetchById(Guid? id)
        {
            if (id.HasValue)
            {
                DataRow[] _rows = this.Select("Id='" + id.ToString() + "'");
                if (_rows != null && _rows.Length == 1)
                    return _rows[0];
            }
            return null;
        }

        public void AddRowWithoutSave(Guid id, string designation)
        {
            DataRow _newRow = this.NewRow();

            _newRow["Id"] = id.ToString();
            _newRow["Designation"] = designation;

            this.Rows.Add(_newRow);
        }

        public override bool SetDefaultRows()
        {
            base.SetDefaultRows();

            this.AddRowWithoutSave(Guid.NewGuid(), "Ski");
            this.AddRowWithoutSave(Guid.NewGuid(), "Snowboard");
            this.AddRowWithoutSave(Guid.NewGuid(), "Schuhe");
            this.AddRowWithoutSave(Guid.NewGuid(), "Schuhetaschen");
            this.AddRowWithoutSave(Guid.NewGuid(), "Protektor");
            this.AddRowWithoutSave(Guid.NewGuid(), "Brille");
            this.AddRowWithoutSave(Guid.NewGuid(), "Jacke");
            this.AddRowWithoutSave(Guid.NewGuid(), "Hose");
            this.AddRowWithoutSave(Guid.NewGuid(), "Mütze");
            this.AddRowWithoutSave(Guid.NewGuid(), "Helm");
            this.AddRowWithoutSave(Guid.NewGuid(), "Softshell");
            this.AddRowWithoutSave(Guid.NewGuid(), "Handschuh");
            this.AddRowWithoutSave(Guid.NewGuid(), "Skistock");
            this.AddRowWithoutSave(Guid.NewGuid(), "Skisack");
            this.AddRowWithoutSave(Guid.NewGuid(), "Snowboardsack");
            this.AddRowWithoutSave(Guid.NewGuid(), "Sonstiges");
            this.AddRowWithoutSave(Guid.NewGuid(), "Wachs Ausrüstung");
            this.AddRowWithoutSave(Guid.NewGuid(), "Unterbekleidung");

            return true;
        }
    }
}
