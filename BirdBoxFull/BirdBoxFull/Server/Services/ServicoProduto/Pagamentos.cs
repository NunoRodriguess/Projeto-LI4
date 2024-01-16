using System;
using System.Drawing;
using BirdBoxFull.Shared;
using Stripe;
using Stripe.Checkout;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public class Pagamentos : IPagamentos
    {
        private readonly string chavePrivada = "sk_test_51OYrugGgqewYMNNJoelzijRk1r6Tosid2HJe9uxUUcxKTgPHcsQ9gUPaBFCKw2BSI5fg5Z3yz3YnIHYxChYQcQoc00HfOGjnh0";
        private readonly string chavePublica = "pk";
        public Pagamentos()
        {
            try
            {
                StripeConfiguration.ApiKey = chavePrivada;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public string CreateCustomerStripeAccount(Utilizador utilizador)
        {
            var options = new CustomerCreateOptions
            {
                Name = utilizador.Nome,
                Email = utilizador.email,
                Address = new AddressOptions
                {
                    Line1 = utilizador.rua,
                    PostalCode = utilizador.codigoPostal,
                    City = utilizador.localidade,
                    Country = "Portugal",
                },
                PaymentMethod = "pm_card_visa",
                InvoiceSettings = new CustomerInvoiceSettingsOptions
                {
                    DefaultPaymentMethod = "pm_card_visa",
                },

            };
            var service = new CustomerService();
            var customer = service.Create(options);
            return customer.Id;

        }

        public bool UpdateCustomerStripeAccount(string id, Utilizador updateUser)
        {
            var options = new CustomerUpdateOptions
            {
                Name = updateUser.Nome,
                Email = updateUser.email,
                Address = new AddressOptions
                {
                    Line1 = updateUser.rua,
                    PostalCode = updateUser.codigoPostal,
                    City = updateUser.localidade,
                    Country = "Portugal",
                }

            };
            var service = new CustomerService();
            var customer = service.Update(id, options);
            return true;
        }

        //create a SessionLineItemOptions with name, price and image
        public SessionLineItemOptions CreateSessionLineItem(Leilao leilao, Licitacao licitacao)
        {
            var lineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = Convert.ToInt64(licitacao.valor * 100),
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = leilao.Name,
                        Images = new List<string>
                        {
                            leilao.Images[0]
                        },
                    },
                },
            };
            return lineItem;
        }
        //create a checkout session with  customer id and products list
        public string CreateCheckoutSession(Leilao leilao, Licitacao licitacao) // Garantir que a Licitacao tem o Utilizador direito e que o Leilao tá deireito também
        {
            var lineItems = new List<SessionLineItemOptions>();
            lineItems.Add(CreateSessionLineItem(leilao, licitacao));

            var options = new SessionCreateOptions
            {
                Customer = licitacao.Utilizador.StripeId,
                PaymentMethodTypes = new List<string>
            {
                "card",
            },
                ExpiresAt = leilao.DataFinal.AddDays(2),
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel",
            };
            var service = new SessionService();
            var session = service.Create(options);
            return session.Url;
        }
        //exprire a checkout session
        public bool ExpireCheckoutSession(string id)
        {
            var service = new SessionService();
            service.Expire(id);
            return true;
        }

    }



}
}