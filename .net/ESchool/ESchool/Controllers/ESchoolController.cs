using ESchool.Services;
using Microsoft.AspNetCore.Mvc;


namespace ESchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ESchoolController : ControllerBase
    {

        private readonly ILogger<ESchoolController> _logger;

        public ESchoolController(ILogger<ESchoolController> logger)
        {
            _logger = logger;
        }


        [HttpGet("getUser")]
        public string getUser()
        {
            ESchoolServices eSchoolServices = new ESchoolServices();

            eSchoolServices.GetUser();

            return "try";
         }
    }
}