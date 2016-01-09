using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Sirius.Foundation
{
    public abstract class DAOBase<RequestType, ResponseType>
        where ResponseType : ResponseBase
        where RequestType : RequestBase
    {
        public DAOBase()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Parameters
        { get; private set; }

        protected abstract ResponseType GetData(RequestType requestData);

        Logger logger = Logger.LoggerFor<DAOBase<RequestType, ResponseType>>();

        public virtual ResponseType Execute(RequestType requestData)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                logger.LogVerbose("Starting DAO Execution.");

                ResponseType data = this.GetData(requestData);

                logger.LogVerbose("Ending DAO Execution.");

                return data;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "And error occurred during DAO execution: {0}", ex.Message);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                logger.LogVerbose("DAO execution runtime: {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            }
        }
    }
}
