using Autofac.Integration.WebApi;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace WooliesxAssignment.Filters
{
    public class GlobalExceptionHandlingFiler : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        //public async Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    var controllerContext = actionExecutedContext.ActionContext.ActionDescriptor;
        //    var controllerName = controllerContext.ControllerDescriptor.ControllerType.Name;
        //    var exceptionData = actionExecutedContext.Exception;
        //}
        public GlobalExceptionHandlingFiler(ILogger logger)
        {
            _logger = logger;
        }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var controllerContext = actionExecutedContext.ActionContext.ActionDescriptor;
            var controllerName = controllerContext.ControllerDescriptor.ControllerType.Name;
            var exceptionData = actionExecutedContext.Exception;
            _logger.Error(exceptionData, exceptionData.Message);
        }
    }
}