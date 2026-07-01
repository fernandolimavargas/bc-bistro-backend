public class Comanda
{
    public int Id {get;set;}
    public string Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnidade { get; set; }
    public decimal ValorCalculado { get; set; }
    public decimal ValorTotal { get; set; }
}