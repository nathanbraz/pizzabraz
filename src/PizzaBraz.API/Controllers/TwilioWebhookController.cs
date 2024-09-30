using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBraz.Services.Interfaces;
using Twilio.Jwt.AccessToken;
using Twilio.TwiML;

namespace PizzaBraz.API.Controllers
{
    [ApiController]
    public class TwilioWebhookController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public TwilioWebhookController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("/api/v1/twilio/whatsapp-message")]
        public async Task<IActionResult> WhatsappMessage()
        {
            try
            {
                var responseMessage = $"Olá, acesse seu link para pedidos: https://sua-pizzaria.com/pedidos?token=123";

                var messagingResponse = new MessagingResponse();
                messagingResponse.Message(responseMessage);

                return Content(messagingResponse.ToString(), "application/xml");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao processar mensagem.");
            }
        }

    }
}
