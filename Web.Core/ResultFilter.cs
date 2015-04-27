using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Web.Core
{
    public class ResultFilter : ActionFilterAttribute
    {
        private static ILog logger = log4net.LogManager.GetLogger(typeof(ResultFilter));

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (!actionExecutedContext.Request.Headers.Contains("rweewer"))
            {
                return;
            }

            if (actionExecutedContext.Exception != null)
            {
                Exception ex = actionExecutedContext.Exception;

                logger.Error("错误", ex);

                actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    Content = new JsonContent(new ApiResult(500, ex))
                };

                return;
            }

            ObjectContent content = actionExecutedContext.Response.Content as ObjectContent;

            if (content != null)
            {
                actionExecutedContext.Response.Content = new JsonContent(new ApiResult(content.Value));

            }
        }
    }
}
