public class CatalogoService
{
    private readonly CatalogoRepository _catalogoRepository;

    public CatalogoService(CatalogoRepository catalogoRepository)
    {
        _catalogoRepository = catalogoRepository;
    }
    
    public List<Catalogo> MostrarCatalogo(int filtro)
    {
        return _catalogoRepository.MostrarCatalogo(filtro); 
    }

    public List<CondicoesPagamento> MostrarCondicoesPagamento()
    {
        return _catalogoRepository.MostrarCondicoesPagamento();
    }

    public void AdicionarCondicaoPagamento(CondicoesPagamento condicaoPagamento)
    {
        if (string.IsNullOrWhiteSpace(condicaoPagamento.Condicao))
        {
            throw new ArgumentException("A condição de pagamento não pode ser vazia.");
        }

        _catalogoRepository.AdicionarCondicaoPagamento(condicaoPagamento);
    }

    public void RemoverCondicaoPagamento(int id)
    {
        _catalogoRepository.RemoverCondicaoPagamento(id);
    }

    public void AlterarCondicaoPagamento(CondicoesPagamento condicaoPagamento)
    {
        _catalogoRepository.AlterarCondicaoPagamento(condicaoPagamento);
    }

    public void AtivarInativarCondicaoPagamento(int id, bool ativo)
    {
        _catalogoRepository.AtivarInativarCondicaoPagamento(id, ativo);
    }
}