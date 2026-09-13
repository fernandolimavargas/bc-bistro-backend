public class ResultadoFinalizacaoVenda
{
    public int IdVenda { get; set; }

    public List<AtualizacaoEstoque> Estoques { get; set; } = new();
}