using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CRM.API.Areas.PublicArea.Controllers
{
    [Area("PublicArea")]
    [Route("api/[area]/[controller]")]
    [DisplayName("Public Controller")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is a public endpoint.");
        }
    }
}
