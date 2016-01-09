using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Services.Protocols;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Cielo.Sirius.Foundation
{
    public abstract class ServiceBase
    {
        Logger logger = Logger.LoggerFor<ServiceBase>();

        public ServiceBase()
        {
        }

        protected ResponseType ExecuteBusiness<RequestType, ResponseType>(BusinessLogicBase<RequestType, ResponseType> business, RequestType requestData, [CallerMemberNameAttribute] string callerMethodName = "")
            where ResponseType : ResponseBase, new()
            where RequestType : RequestBase
        {
            ResponseType response = null;
            Stopwatch stopWatch = null;
            
            try
            {
                Trace.CorrelationManager.StartLogicalOperation();

                if (requestData.CorrelationId == Guid.Empty)
                {
                    Trace.CorrelationManager.ActivityId = Guid.NewGuid();
                }
                else
                {
                    Trace.CorrelationManager.ActivityId = requestData.CorrelationId;
                }

                stopWatch = new Stopwatch();
                stopWatch.Start();

                logger.LogVerbose("Starting {0} Execution.", callerMethodName);
                logger.LogVerbose("{0} Request Data: {1}", business.GetType().FullName, Logger.BasicSerialization(requestData));

                response = business.Execute(requestData);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during {0} execution: {1}", business.GetType().FullName, ex.Message);

                response = new ResponseType();
                response.Status = ExecutionStatus.TechnicalError;
                response.ErrorCode = ErrorCodes.GENERIC_TECHNICAL_ERROR;
                response.ErrorMessage = ex.Message;
            }
            finally
            {
                if (stopWatch != null)
                {
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    logger.LogVerbose("AbrirEvento execution runtime: {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                }

                if(response != null)
                {
                    response.CorrelationId = Trace.CorrelationManager.ActivityId;

                    logger.LogVerbose("{0} Response Data: {1}", business.GetType().FullName, Logger.BasicSerialization(response));
                }

                logger.LogVerbose("Ending {0} Execution.", callerMethodName);

                Trace.CorrelationManager.StopLogicalOperation();
            }

            return response;
        }
    }
}