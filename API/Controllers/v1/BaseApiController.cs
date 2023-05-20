using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}