using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Opus.Cookbook.WebApi.Controllers;

namespace Opus.Cookbook.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PerformanceFilterAttribute : ActionFilterAttribute
    {
        private ControllerBase _controllerBase { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _controllerBase = actionContext.ControllerContext.Controller as ControllerBase;
            ControllerBase.StopWatch.Start();
            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ControllerBase.StopWatch.Stop();
            ControllerBase.JsonResult.ProcessingTime = $"{Math.Floor(ControllerBase.StopWatch.Elapsed.TotalMinutes)}m{Math.Floor(ControllerBase.StopWatch.Elapsed.TotalSeconds)}s";
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}