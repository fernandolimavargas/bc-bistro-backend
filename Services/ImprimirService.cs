public class ImprimirService
{
    private readonly ImprimirRepository _imprimirRepository;

    public ImprimirService(ImprimirRepository imprimirRepository)
    {
        _imprimirRepository = imprimirRepository;
    }
    
    public async Task<List<ReimpressaoDTO>> VisualizarComanda(int idVenda)
    {
        return await _imprimirRepository.VisualizarComanda(idVenda); 
    }

    public async Task<List<int>> PedidosPendentes()
    {
        return await _imprimirRepository.PedidosPendentes();
    }

    public async Task MarcarImpresso(int id)
    {
        await _imprimirRepository.MarcarImpresso(id);
    }

    public async Task Reimprimir(int idVenda)
    {
        await _imprimirRepository.Reimprimir(idVenda); 
    }
}