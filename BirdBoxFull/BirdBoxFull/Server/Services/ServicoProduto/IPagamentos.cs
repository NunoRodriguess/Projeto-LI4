using BirdBoxFull.Shared;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public interface IPagamentos
    {

        string CreateCustomerStripeAccount(Utilizador newUtilizador);
        bool UpdateCustomerStripeAccount(String stripId, Utilizador updatedUser);

    }
}