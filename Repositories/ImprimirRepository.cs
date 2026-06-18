using Dapper;

public class ImprimirRepository : ConexaoDapper
{
    public ImprimirRepository(IConfiguration configuration) : base(configuration) { }

    public async Task Reimprimir(int idVenda)
    {
        var sql = @"
            UPDATE vendas
            SET impresso = false
            WHERE id = @idVenda";

        using var connection = CreateConnection();
            
        connection.Execute(sql, new { idVenda });
    }

    public async Task<List<ReimpressaoDTO>> VisualizarComanda(int idVenda)
    {
        var sql = @"select 
                v.id, 
                v.hora_venda as HoraVenda, 
                c.quantidade,
                c.produto,
                c.valor_calculado as ValorCalculado, 
                v.total,
                v.observacao
            from vendas v
            inner join comandas c
                on c.id_venda = v.id
            where v.id = @idVenda";

        using var connection = CreateConnection(); 

        return connection.Query<ReimpressaoDTO>(sql, new {idVenda}).ToList();
    }

    public async Task<List<int>> PedidosPendentes()
    {
        var sql = @"
            SELECT id
            FROM vendas
            WHERE impresso = false
            ORDER BY id";

        using var connection = CreateConnection();

        return (await connection.QueryAsync<int>(sql)).ToList();
    }

    public async Task MarcarImpresso(int id)
    {
        var sql = @"
            UPDATE vendas
            SET impresso = true
            WHERE id = @id";

        using var connection = CreateConnection();

        await connection.ExecuteAsync(sql, new { id });
    }
}