using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCFServiceReference;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WCFServiceController : ControllerBase
    {
        [HttpGet("")]
        public async Task<string> GetDBVersion()
        {
            var WCFClient = new EISClient(EISClient.EndpointConfiguration.wsI);
            var response = await WCFClient.GetDBVersionAsync();
            return response.GetDBVersionResult;
        }
    }
}
