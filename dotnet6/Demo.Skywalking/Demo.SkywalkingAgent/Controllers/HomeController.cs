using Microsoft.AspNetCore.Mvc;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;

namespace Demo.SkywalkingAgent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntrySegmentContextAccessor _segContext;
        public HomeController(IEntrySegmentContextAccessor segContext)
        {
            _segContext = segContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 自定链路日志
        /// </summary>
        /// <returns></returns>
        public string SkywalkingLog()
        {
            //获取全局traceId
            var traceId = _segContext.Context.TraceId;
            _segContext.Context.Span.AddLog(LogEvent.Message("自定义日志1"));
            Thread.Sleep(1000);
            _segContext.Context.Span.AddLog(LogEvent.Message("自定义日志2"));
            return traceId;
        }
       
    }
}
