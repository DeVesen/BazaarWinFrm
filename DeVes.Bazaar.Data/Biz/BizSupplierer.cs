using System;
using System.Runtime.Serialization;

namespace DeVes.Bazaar.Data.Biz
{
    [DataContract]
    public class BizSupplierer : BizBase
    {
        [DataMember]
        public Guid? SupplierId { get; set; }
        
        [DataMember]
        public int SupplierNo { get; set; }
        
        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string Adress { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public string Phone01 { get; set; }

        [DataMember]
        public string EMail01 { get; set; }

        [DataMember]
        public string Memo { get; set; }

        [DataMember]
        public DateTime? ReturnedToSupplier { get; set; }


        public bool ConvertToDataRow(ref System.Data.DataRow row)
        {
            try
            {
                BizBase.SetValue(row, "Id", this.SupplierId);

                BizBase.SetValue(row, "SupplierNo", this.SupplierNo);

                BizBase.SetValue(row, "Salutation", this.Salutation);
                BizBase.SetValue(row, "LastName", this.LastName);
                BizBase.SetValue(row, "FirstName", this.FirstName);

                BizBase.SetValue(row, "Adress", this.Adress);
                BizBase.SetValue(row, "ZIPCode", this.ZipCode);
                BizBase.SetValue(row, "Town", this.Town);

                BizBase.SetValue(row, "Phone01", this.Phone01);
                BizBase.SetValue(row, "EMail01", this.EMail01);

                BizBase.SetValue(row, "Memo", this.Memo);

                BizBase.SetValue(row, "ReturnedToSupplier", this.ReturnedToSupplier);

                return true;
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }

        public static BizSupplierer ConvertFromDataRow(System.Data.DataRow row)
        {
            var _result = new BizSupplierer();

            try
            {
                _result.SupplierId = BizBase.ToGuid(row["Id"]);

                _result.SupplierNo = BizBase.ToInt32(row["SupplierNo"]) ?? 0;

                _result.Salutation = BizBase.ToString(row["Salutation"]);
                _result.LastName = BizBase.ToString(row["LastName"]);
                _result.FirstName = BizBase.ToString(row["FirstName"]);

                _result.Adress = BizBase.ToString(row["Adress"]);
                _result.ZipCode = BizBase.ToString(row["ZIPCode"]);
                _result.Town = BizBase.ToString(row["Town"]);

                _result.Phone01 = BizBase.ToString(row["Phone01"]);
                _result.EMail01 = BizBase.ToString(row["EMail01"]);

                _result.ReturnedToSupplier = BizBase.ToDateTime(row["ReturnedToSupplier"]);
            }
            catch (Exception)
            {
                _result = null;
            }

            return _result;
        }
    }
}
