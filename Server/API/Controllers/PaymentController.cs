using API.ErrorHandler;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using System.IO;
using System.Threading.Tasks;
using Order = Core.Entities.OrderAggregate.Order;

namespace API.Controllers
{
    public class PaymentController : ApiBaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<IPaymentService> _logger;
        private const string whSecret = "";

        public PaymentController(IPaymentService paymentService, ILogger<IPaymentService> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateorUpdatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateorUpdatePaymentIntent(basketId);

            if (basket == null) return BadRequest(new ApiResponse(400, "Problem in creating basket"));

            return basket;
        }

        [HttpPost("{webhook}")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], whSecret);

            PaymentIntent paymentIntent;
            Order order;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    paymentIntent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment succeeded:", paymentIntent.Id);
                    order = await _paymentService.UpdateOrderPaymentSucceeded(paymentIntent.Id);
                    break;
                case "payment_intent.payment_failed":
                    paymentIntent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment Failed:", paymentIntent.Id);
                    order = await _paymentService.UpdateOrderPaymentFailed(paymentIntent.Id);
                    break;
            }
            return new EmptyResult();
        }
    }
}