
using System.Threading.Tasks;
using HN.Management.Engine.ViewModels;
using HN.Management.Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HN.Management.Web.Apis.V1.Controllers
{ 
    [ApiController]
    [Route("api/mail")]
    public class MailController : Controller
    {
        private readonly IEmailService emailService;

        public MailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("contact-me")]
        public async Task<IActionResult> ContactMeAsync([FromBody] ContactRequest contactRequest)
        {
            return this.Ok(await this.emailService.ContactMe(contactRequest));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("newsletter-program")]
        public async Task<IActionResult> NewsletterProgram([FromQuery] string email)
        {
            return this.Ok(await this.emailService.SendNewsletterProgram(email));
        }
    }
}

