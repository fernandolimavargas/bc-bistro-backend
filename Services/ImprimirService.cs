public class ImprimirService
{
    private readonly ImprimirRepository _imprimirRepository;

    public ImprimirService(ImprimirRepository imprimirRepository)
    {
        _imprimirRepository = imprimirRepository;
    }
    
    public async Task<List<ReimpressaoDTO>> Reimprimir(int idVenda)
    {
        return await _imprimirRepository.Reimprimir(idVenda); 
    }
}