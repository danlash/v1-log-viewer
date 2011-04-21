using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace VersionOne.LogViewer.Specs.parser
{
	public class when_parsing_a_valid_exception_log : spec
	{
		private ExceptionLog _log;
		private IEnumerable<ExceptionLog> _logs;

		#region LOG TEXT
		private const string LOG = @"
==== /VersionOne 2011-04-13 09:04:07 ====
VersionOne.IdeasCommunicationException: Violation'Ideas'Server Error ---> System.Net.WebException: The remote server returned an error: (404) Not Found.
   at System.Net.WebClient.UploadValues(Uri address, String method, NameValueCollection data)
   at System.Net.WebClient.UploadValues(String address, String method, NameValueCollection data)
   at VersionOne.Web.IceNine.Models.HTTPAgent.Post(String url, NameValueCollection parameters)
   --- End of inner exception stack trace ---
   at VersionOne.Web.IceNine.Models.HTTPAgent.Post(String url, NameValueCollection parameters)
   at VersionOne.Web.IceNine.Models.IdeasService.IdeasCreateUserRequest(NewUserRequest newUserRequest)
   at VersionOne.Web.IceNine.Models.IdeasService.CreateNewIdeasUser(NewUserRequest newUserRequest)
   at VersionOne.Web.IceNine.Controllers.IdeaForumSecurityController.CreateUser(String memberOID, String firstName, String lastName, String email, String forumOID)
   at lambda_method(ExecutionScope , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClassd.<InvokeActionMethodWithFilters>b__a()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethodFilter(IActionFilter filter, ActionExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClassd.<>c__DisplayClassf.<InvokeActionMethodWithFilters>b__c()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethodWithFilters(ControllerContext controllerContext, IList`1 filters, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeAction(ControllerContext controllerContext, String actionName)
   at System.Web.Mvc.Controller.ExecuteCore()
   at System.Web.Mvc.ControllerBase.Execute(RequestContext requestContext)
   at System.Web.Mvc.ControllerBase.System.Web.Mvc.IController.Execute(RequestContext requestContext)
   at System.Web.Mvc.MvcHandler.<>c__DisplayClass8.<BeginProcessRequest>b__4()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass1.<MakeVoidDelegate>b__0()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
--- Call Stack ---
   at VersionOne.Web.Global.Application_Error(Object sender, EventArgs e)
   at System.EventHandler.Invoke(Object sender, EventArgs e)
   at System.Web.HttpApplication.RaiseOnError()
   at System.Web.HttpApplication.RecordError(Exception error)
   at System.Web.HttpApplication.ApplicationStepManager.ResumeSteps(Exception error)
   at System.Web.HttpApplication.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpRuntime.ProcessRequestInternal(HttpWorkerRequest wr)
   at System.Web.HttpRuntime.ProcessRequestNoDemand(HttpWorkerRequest wr)
   at System.Web.Hosting.ISAPIRuntime.ProcessRequest(IntPtr ecb, Int32 iWRType)
==== Build: 11.0.0.828 ====
";
		private const string LOG_EXCEPTION = @"VersionOne.IdeasCommunicationException: Violation'Ideas'Server Error ---> System.Net.WebException: The remote server returned an error: (404) Not Found.
   at System.Net.WebClient.UploadValues(Uri address, String method, NameValueCollection data)
   at System.Net.WebClient.UploadValues(String address, String method, NameValueCollection data)
   at VersionOne.Web.IceNine.Models.HTTPAgent.Post(String url, NameValueCollection parameters)
   --- End of inner exception stack trace ---
   at VersionOne.Web.IceNine.Models.HTTPAgent.Post(String url, NameValueCollection parameters)
   at VersionOne.Web.IceNine.Models.IdeasService.IdeasCreateUserRequest(NewUserRequest newUserRequest)
   at VersionOne.Web.IceNine.Models.IdeasService.CreateNewIdeasUser(NewUserRequest newUserRequest)
   at VersionOne.Web.IceNine.Controllers.IdeaForumSecurityController.CreateUser(String memberOID, String firstName, String lastName, String email, String forumOID)
   at lambda_method(ExecutionScope , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClassd.<InvokeActionMethodWithFilters>b__a()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethodFilter(IActionFilter filter, ActionExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClassd.<>c__DisplayClassf.<InvokeActionMethodWithFilters>b__c()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethodWithFilters(ControllerContext controllerContext, IList`1 filters, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeAction(ControllerContext controllerContext, String actionName)
   at System.Web.Mvc.Controller.ExecuteCore()
   at System.Web.Mvc.ControllerBase.Execute(RequestContext requestContext)
   at System.Web.Mvc.ControllerBase.System.Web.Mvc.IController.Execute(RequestContext requestContext)
   at System.Web.Mvc.MvcHandler.<>c__DisplayClass8.<BeginProcessRequest>b__4()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass1.<MakeVoidDelegate>b__0()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
--- Call Stack ---
   at VersionOne.Web.Global.Application_Error(Object sender, EventArgs e)
   at System.EventHandler.Invoke(Object sender, EventArgs e)
   at System.Web.HttpApplication.RaiseOnError()
   at System.Web.HttpApplication.RecordError(Exception error)
   at System.Web.HttpApplication.ApplicationStepManager.ResumeSteps(Exception error)
   at System.Web.HttpApplication.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpRuntime.ProcessRequestInternal(HttpWorkerRequest wr)
   at System.Web.HttpRuntime.ProcessRequestNoDemand(HttpWorkerRequest wr)
   at System.Web.Hosting.ISAPIRuntime.ProcessRequest(IntPtr ecb, Int32 iWRType)";
#endregion

		public override void context()
		{
			IExceptionLogParser parser = new ExceptionLogParser();

			_logs = parser.Parse(LOG.ToStream());
			_log = _logs.FirstOrDefault();
		}

		[Test]
		public void it_should_find_one_log()
		{
			_logs.Count().should_be(1);
		}

		[Test]
		public void it_should_extract_the_virtual_directory()
		{
			_log.VirtualDirectory.should_be("/VersionOne");
		}

		[Test]
		public void it_should_extract_the_date()
		{
			_log.OccurredAt.should_be(DateTime.Parse("2011-04-13 09:04:07"));
		}

		[Test]
		public void it_should_extract_version()
		{
			_log.Version.should_be(new Version("11.0.0.828"));
		}

		[Test]
		public void it_should_extract_exception()
		{
			_log.Exception.should_be(LOG_EXCEPTION);
		}
	}
}
