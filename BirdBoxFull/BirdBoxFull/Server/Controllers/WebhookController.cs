using BirdBoxFull.Server.Services.ServicoProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace BirdBoxFull.Server.Controllers
{
    [Route("webhook")]
    [ApiController]
    public class WebhookController : Controller
    {

        // This is your Stripe CLI webhook secret for testing your endpoint locally.
        const string endpointSecret = "whsec_6c6ec8b2872db7340805184ea9ba36b5f248264c432217d31c1bf810ee33fa34";

        private readonly IServicoLicitacao _servicoLicitacao;

        public WebhookController(IServicoLicitacao servicoLicitacao)
        {
            _servicoLicitacao = servicoLicitacao;
            
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            Console.WriteLine("CONTROLLLER STRIPE");
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var checkoutSession = stripeEvent.Data.Object as Stripe.Checkout.Session;

                    // Retrieve metadata or other details from the checkout session
                    string bidId = checkoutSession.Metadata["codLicitacao"];
                    await _servicoLicitacao.AlterarEstado(bidId,"Paga");
                    // Começar a encomenda também
                    Console.WriteLine($"Checkout session completed for bid ID: {bidId}");

                    // Perform actions based on the bidId
                    // ...
                }
                else if (stripeEvent.Type == Events.CheckoutSessionExpired)
                {
                    var checkoutSession = stripeEvent.Data.Object as Stripe.Checkout.Session;

                    // Retrieve metadata or other details from the checkout session

                    string bidId = checkoutSession.Metadata["codLicitacao"];
                    await _servicoLicitacao.AlterarEstado(bidId, "Invalida");

                    // Now you can use the bidId for further processing
                    Console.WriteLine($"Checkout session expired for bid ID: {bidId}");

                    // Perform actions based on the bidId
                    // ...


                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
