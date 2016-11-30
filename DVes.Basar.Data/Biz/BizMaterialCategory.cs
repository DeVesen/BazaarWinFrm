using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DVes.Basar.Data.Biz
{
    [DataContract]
    public class BizMaterialCategory : BizBase
    {
        [DataMember]
        public Guid? Id { get; set; }

        [DataMember]
        public string Designation { get; set; }


        public bool ConvertToDataRow(ref System.Data.DataRow row)
        {
            try
            {
                BizBase.SetValue(row, "Id", this.Id);

                BizBase.SetValue(row, "Designation", this.Designation);

                return true;
            }
            catch(Exception ex)
            {
            }
            return false;
        }

        public static BizMaterialCategory ConvertFromDataRow(System.Data.DataRow row)
        {
            BizMaterialCategory _result = new BizMaterialCategory();

            try
            {
                _result.Id = BizBase.ToGuid(row["Id"]);

                _result.Designation = BizBase.ToString(row["Designation"]);
            }
            catch (Exception ex)
            {
                _result = null;
            }

            return _result;
        }
    }
}
