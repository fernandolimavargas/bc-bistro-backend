using Microsoft.AspNetCore.SignalR;

namespace BCBistroAPI.Hubs;

public class EstoqueHub : Hub
{
    public async Task TestarConexao(string mensagem)
    {
        await Clients.All.SendAsync(
            "MensagemEstoque",
            mensagem
        );
    }
}