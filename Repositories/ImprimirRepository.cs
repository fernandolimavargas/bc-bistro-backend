using Dapper;

public class ImprimirRepository : ConexaoDapper
{
    public ImprimirRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<List<ReimpressaoDTO>> Reimprimir(int idVenda)
    {
        var sqlReimprimir = @"select 
            v.id, 
            v.hora_venda as HoraVenda, 
            c.quantidade,
            c.produto,
            c.valor_calculado as ValorCalculado, 
            v.total
        from vendas v
        inner join comandas c
            on c.id_venda = v.id
        where v.id = @idVenda";


        using var connection = CreateConnection();

        var resultado = await connection.QueryAsync<ReimpressaoDTO>(
        sqlReimprimir,
        new { idVenda }
        );

        return resultado.ToList();

    }
}