using System;
using System.Runtime.Serialization;

namespace DeVes.Bazaar.Data.Biz
{
    [DataContract]
    public class BizPosition : BizBase
    {
        [DataMember]
        public Guid SupplierId { get; set; }

        [DataMember]
        public int PositionNo { get; set; }

        [DataMember]
        public string Material { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public double? PriceMin { get; set; }
        [DataMember]
        public double PriceMax { get; set; }

        [DataMember]
        public double? SoldFor { get; set; }
        [DataMember]
        public DateTime? SoldAt { get; set; }

        [DataMember]
        public DateTime? ReturnedToSupplierAt { get; set; }

        [DataMember]
        public string Memo { get; set; }

        [DataMember]
        public DateTime? LastChange { get; set; }


        public bool ConvertToDataRow(ref System.Data.DataRow row)
        {
            try
            {
                BizBase.SetValue(row, "SupplierId", this.SupplierId);

                BizBase.SetValue(row, "PositionNo", this.PositionNo);

                BizBase.SetValue(row, "Material", this.Material);
                BizBase.SetValue(row, "Category", this.Category);
                BizBase.SetValue(row, "Manufacturer", this.Manufacturer);

                BizBase.SetValue(row, "PriceMin", this.PriceMin);
                BizBase.SetValue(row, "PriceMax", this.PriceMax);

                BizBase.SetValue(row, "SoldFor", this.SoldFor);
                BizBase.SetValue(row, "SoldAt", this.SoldAt);

                BizBase.SetValue(row, "ReturnedToSupplierAt", this.ReturnedToSupplierAt);

                BizBase.SetValue(row, "Memo", this.Memo);

                BizBase.SetValue(row, "LastChange", this.LastChange);

                return true;
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }

        public static BizPosition ConvertFromDataRow(System.Data.DataRow row)
        {
            BizPosition _result = null;

            if (row != null)
            {
                _result = new BizPosition();

                try
                {
                    _result.SupplierId = BizBase.ToGuid(row["SupplierId"]) ?? Guid.Empty;

                    _result.PositionNo = BizBase.ToInt32(row["PositionNo"]) ?? 0;

                    _result.Material = BizBase.ToString(row["Material"]);
                    _result.Category = BizBase.ToString(row["Category"]);
                    _result.Manufacturer = BizBase.ToString(row["Manufacturer"]);

                    _result.PriceMin = BizBase.ToDouble(row["PriceMin"]);
                    _result.PriceMax = BizBase.ToDouble(row["PriceMax"]) ?? 0;

                    _result.SoldFor = BizBase.ToDouble(row["SoldFor"]);
                    _result.SoldAt = BizBase.ToDateTime(row["SoldAt"]);

                    _result.ReturnedToSupplierAt = BizBase.ToDateTime(row["ReturnedToSupplierAt"]);

                    _result.Memo = BizBase.ToString(row["Memo"]);

                    _result.LastChange = BizBase.ToDateTime(row["LastChange"]);
                }
                catch (Exception)
                {
                    _result = null;
                }
            }

            return _result;
        }

        public bool CheckForMin()
        {
            var _result = this.PositionNo > 0;
            _result = _result && !string.IsNullOrEmpty(this.Material) && !string.IsNullOrEmpty(this.Material.Trim());
            _result = _result && PriceMax > 0;

            return _result;
        }
    }
}
