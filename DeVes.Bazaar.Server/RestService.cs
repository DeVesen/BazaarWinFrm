using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using DeVes.Bazaar.Data;
using DeVes.Bazaar.Data.Biz;
using DeVes.Extension.Common;

namespace DeVes.Bazaar.Server
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        RestCurrentSituation GetActualSituation();


        [OperationContract]
        RestSupplierItem GetSupplier(string suppNum);


        [OperationContract]
        BizPosition GetPosition(string posNum);


        [OperationContract]
        ReturnToSupplierResult ReturnPositionToSupplier(string suppNum, string posNum);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestService : IRestService
    {
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "stats/ActualSituation")]
        public RestCurrentSituation GetActualSituation()
        {
            int _supplCount, _positionsCount;
            int _notSold, _isSold, _isReturn;
            double _soldBetrag, _eigenBetrag;

            lock (GParams.Instance.ComLockObj)
            {
                GParams.Instance.Supplier.SupplierStats(out _supplCount);

                GParams.Instance.Position.PositionsStats(out _positionsCount, out _notSold, out _isSold, out _isReturn,
                                                         out _soldBetrag);

                var _prozValue = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", 15);
                _eigenBetrag = _soldBetrag * _prozValue / 100;
            }

            return new RestCurrentSituation()
            {
                SupplierCount = _supplCount,
                PositionCount = _positionsCount
            };
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "data/Supplier/{suppNum}")]
        public RestSupplierItem GetSupplier(string suppNum)
        {
            var _prozValue = Program.CfgFile.getValue_AsdDouble("SellParams", "ProzGewin", 15);
            var _supplierNum = DeVesConverter.ToInteger(suppNum) ?? 0;

            var _supplierBiz = GParams.Instance.Supplier.SupplierGet_No(_supplierNum);
            if (_supplierBiz == null) return new RestSupplierItem();

            var _supplierPositionBizList = GParams.Instance.Position.PositionsGet(_supplierBiz.SupplierNo);
            var _soldEuroTotal = _supplierPositionBizList.Where(p => p.SoldFor.HasValue).Sum(p => p.SoldFor ?? 0);
            var _ownEuroPart = _soldEuroTotal*_prozValue/100;
            var _supplierEuroPart = _soldEuroTotal - _ownEuroPart;

            return new RestSupplierItem()
            {
                Id = _supplierBiz.SupplierId.ToString(),
                Number = _supplierBiz.SupplierNo,

                Salutation = _supplierBiz.Salutation,
                LastName = _supplierBiz.LastName,
                FirstName = _supplierBiz.FirstName,
                FullName = string.Format("{0} {1} {2}", _supplierBiz.Salutation, _supplierBiz.FirstName,_supplierBiz.LastName),

                Phone = _supplierBiz.Phone01,
                ReturnedToSupplier = _supplierBiz.ReturnedToSupplier.HasValue ? _supplierBiz.ReturnedToSupplier.Value.ToString("dd.MM.yyyy HH:mm:ss") : null,

                PosCountTotal = _supplierPositionBizList.Length,
                PosCountSold = _supplierPositionBizList.Count(p => p.SoldFor.HasValue),
                PosCountRetu = _supplierPositionBizList.Count(p => p.ReturnedToSupplierAt.HasValue && !p.SoldFor.HasValue),
                PosCountNotAdd = 0,
                IncomeTotal = _soldEuroTotal,
                Delivery = _ownEuroPart,
                ToBePaidOut = _supplierEuroPart
            };
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "data/Position/{posNum}")]
        public BizPosition GetPosition(string posNum)
        {
            var _positionNum = DeVesConverter.ToInteger(posNum) ?? 0;

            return GParams.Instance.Position.PositionGet(_positionNum);
        }


        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "work/ReturnPositionToSupplier/{suppNum}/{posNum}")]
        public ReturnToSupplierResult ReturnPositionToSupplier(string suppNum, string posNum)
        {
            var _supplierNum = DeVesConverter.ToInteger(suppNum) ?? 0;
            var _positionNum = DeVesConverter.ToInteger(posNum) ?? 0;

            var _positionBiz = GParams.Instance.Position.PositionGet(_positionNum);
            if (_positionBiz == null)
            {
                return new ReturnToSupplierResult()
                {
                    Succeeded = ReturnToSupplierResult.SucceededTypes.Error,
                    Message = string.Format("Position '{0}' nicht bekannt!", _positionNum)
                };
            }


            var _supplierBiz = GParams.Instance.Supplier.SupplierGet_ByID(_positionBiz.SupplierId);
            if (_supplierBiz == null)
            {
                return new ReturnToSupplierResult()
                {
                    Succeeded = ReturnToSupplierResult.SucceededTypes.Error,
                    Message = string.Format("Händler von Position '{0}' nicht gefunden!", _positionNum)
                };
            }

            if (_supplierBiz.SupplierNo != _supplierNum)
            {
                return new ReturnToSupplierResult()
                {
                    Succeeded = ReturnToSupplierResult.SucceededTypes.Error,
                    Message = string.Format("Position '{0}' gehört Händler '{1}'!", _positionNum, _supplierBiz.SupplierNo)
                };
            }


            if (_positionBiz.SoldFor.HasValue)
            {
                return new ReturnToSupplierResult()
                {
                    Succeeded = ReturnToSupplierResult.SucceededTypes.Error,
                    Message = string.Format("Position '{0}' bereits verkauft!", _positionNum)
                };
            }

            if (_positionBiz.ReturnedToSupplierAt.HasValue)
            {
                return new ReturnToSupplierResult()
                {
                    Succeeded = ReturnToSupplierResult.SucceededTypes.Warning,
                    Message = string.Format("Position '{0}' bereits zurückgegeben!", _positionNum)
                };
            }

            GParams.Instance.Position.SetPositionsAsReturned(new BizPosition[] { _positionBiz });

            return new ReturnToSupplierResult()
            {
                Succeeded = ReturnToSupplierResult.SucceededTypes.Succeeded,
                Message = string.Format("Position '{0}' zurück gebucht...", _positionNum)
            };
        }
    }


    public class RestCurrentSituation
    {
        public int SupplierCount { get; set; }

        public int PositionCount { get; set; }
    }


    public class RestSupplierItem
    {
        public string Id { get; set; }
        public int Number { get; set; }

        public string Salutation { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }

        public string Phone { get; set; }

        public int PosCountTotal { get; set; }
        public int PosCountSold { get; set; }
        public int PosCountRetu { get; set; }
        public int PosCountNotAdd { get; set; }

        public double IncomeTotal { get; set; }
        public double Delivery { get; set; }
        public double ToBePaidOut { get; set; }
        
        public string ReturnedToSupplier { get; set; }
    }

    public class ReturnToSupplierResult
    {
        public enum SucceededTypes : int
        {
            Succeeded = 1,
            Warning = 2,
            Error = 3
        }

        public SucceededTypes Succeeded { get; set; }
        public string Message { get; set; }
    }

    public class Position
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
    }


    public class CustomHeaderMessageInspector : IDispatchMessageInspector
    {
        Dictionary<string, string> requiredHeaders;
        public CustomHeaderMessageInspector(Dictionary<string, string> headers)
        {
            requiredHeaders = headers ?? new Dictionary<string, string>();
        }

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
            foreach (var item in requiredHeaders)
            {
                httpHeader.Headers.Add(item.Key, item.Value);
            }
        }
    }
    public class EnableCrossOriginResourceSharingBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            var requiredHeaders = new Dictionary<string, string>();

            requiredHeaders.Add("Access-Control-Allow-Origin", "*");
            requiredHeaders.Add("Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS");
            requiredHeaders.Add("Access-Control-Allow-Headers", "X-Requested-With,Content-Type");

            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CustomHeaderMessageInspector(requiredHeaders));
        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }

        public override Type BehaviorType
        {
            get { return typeof(EnableCrossOriginResourceSharingBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new EnableCrossOriginResourceSharingBehavior();
        }
    }
}
