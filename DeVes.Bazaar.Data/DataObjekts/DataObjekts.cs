using System.Runtime.Serialization;
using DeVes.Bazaar.Data.Biz;

namespace DeVes.Bazaar.Data.DataObjekts
{
    [DataContract]
    public class PositionSellResult
    {
        [DataContract]
        public enum NotSoldPosReasonTypes
        {
            [EnumMember]
            MeanTimeChanged,
            [EnumMember]
            MeanTimeSold,
            [EnumMember]
            MeanTimeReturned,
            [EnumMember]
            NotFound
        }

        [DataMember]
        public BizPosition[] SoldPositions { get; set; }

        [DataMember]
        public BizPosition[] NotPossibleToSell { get; set; }

        [DataMember]
        public NotSoldPosReasonTypes[] NotSoldPosReason { get; set; }
    }

    [DataContract]
    public class PositionReturnedResult
    {
        [DataMember]
        public int PositionsCountTotal { get; set; }
        [DataMember]
        public int PositionsToReturnCountTotal { get; set; }
        [DataMember]
        public double PositionsToReturnMoney { get; set; }


        [DataMember]
        public BizPosition[] SoldPositions { get; set; }

        [DataMember]
        public BizPosition[] NotSoldPositions { get; set; }

        [DataMember]
        public BizPosition[] AlreadyReturnedPositions { get; set; }

        [DataMember]
        public bool HadDifferences { get; set; }
    }

    [DataContract]
    public class ParameterResult
    {
        [DataMember]
        public double ProzSoldGewein { get; set; }

        [DataMember]
        public string SellerInfoText { get; set; }

        [DataMember]
        public bool PrintPev { get; set; }
    }

    [DataContract]
    public class AllPositionResult
    {
        [DataMember]
        public BizSupplierer Supplier { get; set; }

        [DataMember]
        public BizPosition[] Positions { get; set; }
    }
}
