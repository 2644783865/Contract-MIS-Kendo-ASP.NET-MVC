using System;
using System.IO;
using System.Web.Hosting;
using Misi.DAL.Billing.Model.Object;
using Misi.Service.Billing.Handler.BrokenDevice;
using Misi.Service.Billing.Handler.ErrorCharges;
using Misi.Service.Billing.Handler.NewContract;
using Misi.Service.Billing.Handler.NewScenario;
using Misi.Service.Billing.Handler.ReturnDevice;
using Misi.Service.Billing.Handler.Termination;
using Misi.Service.Billing.Handler.TransferAsset;
using Misi.Service.Billing.Model.BrokenDevice;
using Misi.Service.Billing.Model.Common;
using Misi.Service.Billing.Model.ErrorCharges;
using Misi.Service.Billing.Model.NewContract;
using Misi.Service.Billing.Model.NewScenario;
using Misi.Service.Billing.Model.ReturnDevice;
using Misi.Service.Billing.Model.Termination;
using Misi.Service.Billing.Model.TransferAsset;

namespace Misi.Service.Billing.Handler
{
    public class RequestHandlerFactory
    {
        private static volatile RequestHandlerFactory _factory;
        private static readonly object SyncRoot1 = new object();

        public static RequestHandlerFactory Instance
        {
            get
            {
                if (_factory != null) return _factory;
                lock (SyncRoot1)
                {
                    if (_factory == null)
                    {
                        _factory = new RequestHandlerFactory();
                    }
                }
                return _factory;
            }
        }

        public RequestHandlerBase GetHandler(EScenario scenario)
        {
            RequestHandlerBase handler = null;
            switch (scenario)
            {
                case EScenario.BROKEN_DEVICE:
                    handler = new BrokenDeviceReqHandler();
                    break;
                case EScenario.NEW_SCENARIO:
                    handler = new NewScenarioReqHandler();
                    break;
                case EScenario.ERROR_CHARGES:
                    handler = new ErrorChargesReqHandler();
                    break;
                case EScenario.NEW_CONTRACT:
                    handler = new NewContractReqHandler();
                    break;
                case EScenario.RETURN_DEVICE:
                    handler = new ReturnDeviceReqHandler();
                    break;
                case EScenario.TERMINATION:
                    handler = new TerminationReqHandler();
                    break;
                case EScenario.TRANSFER_ASSET:
                    handler = new TransferAssetReqHandler();
                    break;
            }
            if (handler != null)
            {
                return handler;
            }
            throw new NotImplementedException();
        }

        public RequestHandlerBase GetHandler(ServiceRequestDTO data)
        {
            RequestHandlerBase handler = null;
            var type = data.GetType();
            if (type == typeof(TransferAssetRequestDTO))
            {
                handler = new TransferAssetReqHandler();
            }
            else if (type == typeof(TerminationRequestDTO))
            {
                handler = new TerminationReqHandler();
            }
            else if (type == typeof(ReturnDeviceRequestDTO))
            {
                handler = new ReturnDeviceReqHandler();
            }
            else if (type == typeof(NewScenarioRequestDTO))
            {
                handler = new NewScenarioReqHandler();
            }
            else if (type == typeof(NewContractRequestDTO))
            {
                handler = new NewContractReqHandler();
            }
            else if (type == typeof(ErrorChargesRequestDTO))
            {
                handler = new ErrorChargesReqHandler();
            }
            else if (type == typeof(BrokenDeviceRequestDTO))
            {
                handler = new BrokenDeviceReqHandler();
            }

            if (handler != null)
            {
                handler.ServiceRequest = data;
                return handler;
            }
            throw new NotImplementedException();
        }
    }
}