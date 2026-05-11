using System.Numerics;

public class VendasHistoricos
{
    public int Id { get; set; }
    public DateTime HoraVenda { get; set; }
    public decimal TotalVenda { get; set; }
    public decimal TotalDoDia { get; set; }
    public List<ProdutosVendidos> ProdutosVendidos { get; set; }
}

public class ProdutosVendidos
{
    public string Produto { get; set; }
    public string Categoria { get; set; }
    public decimal ValorUnidade { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorCalculado { get; set; }
}
