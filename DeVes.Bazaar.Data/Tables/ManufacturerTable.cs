using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DeVes.Bazaar.Data.Tables
{
    internal class ManufacturerTable : BasicTable
    {
        public ManufacturerTable()
        {
            this.TableName = "Manufacturer";

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

            this.AddRowWithoutSave(Guid.NewGuid(), "Adidas");
            this.AddRowWithoutSave(Guid.NewGuid(), "Alpina");
            this.AddRowWithoutSave(Guid.NewGuid(), "Arc'teryx");
            this.AddRowWithoutSave(Guid.NewGuid(), "ArmadaArva");
            this.AddRowWithoutSave(Guid.NewGuid(), "Atomic");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Big Pack");
            this.AddRowWithoutSave(Guid.NewGuid(), "Black Diamond");
            this.AddRowWithoutSave(Guid.NewGuid(), "Blizzard");
            this.AddRowWithoutSave(Guid.NewGuid(), "Bollé");
            this.AddRowWithoutSave(Guid.NewGuid(), "Briko");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Carrera");
            this.AddRowWithoutSave(Guid.NewGuid(), "Cratoni");
            this.AddRowWithoutSave(Guid.NewGuid(), "Crispi");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Dainese");
            this.AddRowWithoutSave(Guid.NewGuid(), "Dalbello");
            this.AddRowWithoutSave(Guid.NewGuid(), "Deuter");
            this.AddRowWithoutSave(Guid.NewGuid(), "Dynafit");
            this.AddRowWithoutSave(Guid.NewGuid(), "Dynamic");
            this.AddRowWithoutSave(Guid.NewGuid(), "Dynastar");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Eider");
            this.AddRowWithoutSave(Guid.NewGuid(), "Elan");
            this.AddRowWithoutSave(Guid.NewGuid(), "Extrem");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Fischer");
            this.AddRowWithoutSave(Guid.NewGuid(), "Fjällräven");
            this.AddRowWithoutSave(Guid.NewGuid(), "Fritschi");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "G3");
            this.AddRowWithoutSave(Guid.NewGuid(), "Garmont");
            this.AddRowWithoutSave(Guid.NewGuid(), "Gentic");
            this.AddRowWithoutSave(Guid.NewGuid(), "Giro");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Hagan");
            this.AddRowWithoutSave(Guid.NewGuid(), "Haglöfs");
            this.AddRowWithoutSave(Guid.NewGuid(), "Head");
            this.AddRowWithoutSave(Guid.NewGuid(), "Helly Hansen");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Jack Wolfskin");
            this.AddRowWithoutSave(Guid.NewGuid(), "Julbo");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "K2");
            this.AddRowWithoutSave(Guid.NewGuid(), "Karhu");
            this.AddRowWithoutSave(Guid.NewGuid(), "Kästle");
            this.AddRowWithoutSave(Guid.NewGuid(), "Kneissl");
            this.AddRowWithoutSave(Guid.NewGuid(), "Komperdell");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "La Sportiva");
            this.AddRowWithoutSave(Guid.NewGuid(), "Lange");
            this.AddRowWithoutSave(Guid.NewGuid(), "Lasse Kjus");
            this.AddRowWithoutSave(Guid.NewGuid(), "Leki");
            this.AddRowWithoutSave(Guid.NewGuid(), "Linken");
            this.AddRowWithoutSave(Guid.NewGuid(), "Lowa");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Mammut");
            this.AddRowWithoutSave(Guid.NewGuid(), "Marker");
            this.AddRowWithoutSave(Guid.NewGuid(), "Matador");
            this.AddRowWithoutSave(Guid.NewGuid(), "Mountain Wave");
            this.AddRowWithoutSave(Guid.NewGuid(), "Movement");
            this.AddRowWithoutSave(Guid.NewGuid(), "Mover");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Naxo");
            this.AddRowWithoutSave(Guid.NewGuid(), "Nike");
            this.AddRowWithoutSave(Guid.NewGuid(), "Nordica");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Oakley");
            this.AddRowWithoutSave(Guid.NewGuid(), "Ortovox");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Patagonia");
            this.AddRowWithoutSave(Guid.NewGuid(), "Peak Performance");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Rodenstock");
            this.AddRowWithoutSave(Guid.NewGuid(), "Rossignol");
            this.AddRowWithoutSave(Guid.NewGuid(), "Rottefella");
            this.AddRowWithoutSave(Guid.NewGuid(), "Rudy Project");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Salewa");
            this.AddRowWithoutSave(Guid.NewGuid(), "Salomon");
            this.AddRowWithoutSave(Guid.NewGuid(), "Scarpa");
            this.AddRowWithoutSave(Guid.NewGuid(), "Schöffel");
            this.AddRowWithoutSave(Guid.NewGuid(), "Scott");
            this.AddRowWithoutSave(Guid.NewGuid(), "Silvretta");
            this.AddRowWithoutSave(Guid.NewGuid(), "Stöckli");
            this.AddRowWithoutSave(Guid.NewGuid(), "Sunrise");
            this.AddRowWithoutSave(Guid.NewGuid(), "Swiss Eye");
            this.AddRowWithoutSave(Guid.NewGuid(), "Sziols");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Tatonka");
            this.AddRowWithoutSave(Guid.NewGuid(), "Tecnica");
            this.AddRowWithoutSave(Guid.NewGuid(), "The North Face");
            this.AddRowWithoutSave(Guid.NewGuid(), "Trab");
            this.AddRowWithoutSave(Guid.NewGuid(), "Tracker");
            this.AddRowWithoutSave(Guid.NewGuid(), "TUA Ski");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Uvex");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Vaude");
            this.AddRowWithoutSave(Guid.NewGuid(), "Voilé");
            this.AddRowWithoutSave(Guid.NewGuid(), "Volant");
            this.AddRowWithoutSave(Guid.NewGuid(), "Völkl");
            
            this.AddRowWithoutSave(Guid.NewGuid(), "Zag");

            return true;
        }
    }
}
