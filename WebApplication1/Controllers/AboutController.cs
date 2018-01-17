using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //routing organisations

    //[Route("about")]
        //as a token, will automatically use the name of the class/function name when within [] 
    [Route("[controller]/[action]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+123456789";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
