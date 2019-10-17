using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Refresh_The_Page.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {

        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Trace.WriteLine($"Action Method {actionContext.ActionDescriptor.ActionName} executing at {DateTime.Now.ToShortDateString()}", "Web API Logs");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.WriteLine($"Action Method {actionExecutedContext.ActionContext.ActionDescriptor.ActionName} executed at {DateTime.Now.ToShortDateString()}", "Web API Logs");
        }
    }
}