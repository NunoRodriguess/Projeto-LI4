﻿namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public interface IEmailSenderService
    {
        public void SendAuctionEndedEmail(string toAddress, string auctionTitle, bool sucesso);
    }
}
