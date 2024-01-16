using System;
using System.Drawing;
using BirdBoxFull.Shared;
using Stripe;
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



    }
}