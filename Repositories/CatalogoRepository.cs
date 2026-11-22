using System.ComponentModel.Design;
using Dapper;

public class CatalogoRepository : ConexaoDapper
{
    public CatalogoRepository(IConfiguration configuration) : base(configuration) { }

    public List<Catalogo> MostrarCatalogo(int filtro = 0)
    {
        var where = "";
        var parameters = new DynamicParameters();

        if (filtro > 0)
        {
            where += " and p.Categoria = @Categoria";
            parameters.Add("Categoria", filtro);
        }
        

        var sqlProdutos = $@" 
            SELECT 
                p.ID, 
                Nome as Produto, 
                Preco, 
                p.Categoria as IdCategoria,
                ic.categoria as Categoria,
                p.disponivel,
                p.descricao as Descricao,
                p.quantidade_stock as QuantidadeStock
                FROM produtos p 
                INNER JOIN inf_categorias ic
                    on ic.id = p.categoria
                WHERE p.disponivel = true
                {where}
                ORDER BY p.Categoria, p.id";

        var connection = CreateConnection();
        return connection.Query<Catalogo>(sqlProdutos, parameters).ToList();
    }

    public List<CondicoesPagamento> MostrarCondicoesPagamento()
    {
        var sqlCondicoesPagamento = @"
            SELECT 
                id, 
                condicao as Condicao, 
                ativo as Ativo
            FROM metodos_pagamento
            WHERE ativo = true
            ORDER BY id";

        var connection = CreateConnection();
        return connection.Query<CondicoesPagamento>(sqlCondicoesPagamento).ToList();
    }

    public void AdicionarCondicaoPagamento(CondicoesPagamento condicaoPagamento)
    {
        var sql = @" INSERT INTO metodos_pagamento (condicao, ativo) 
            VALUES (@Condicao, @Ativo)";

        using var connection = CreateConnection();
        connection.Execute(sql, new { Condicao = condicaoPagamento.Condicao, Ativo = condicaoPagamento.Ativo });
    }

    public void RemoverCondicaoPagamento(int id)
    {
        var sql = @" DELETE FROM metodos_pagamento WHERE id = @Id";

        using var connection = CreateConnection();
        connection.Execute(sql, new { Id = id });
    }

    public void AlterarCondicaoPagamento(CondicoesPagamento condicaoPagamento)
    {
        var sql = @" UPDATE metodos_pagamento 
                        SET condicao = @Condicao
                    WHERE id = @Id";

        using var connection = CreateConnection();
        connection.Execute(sql, new { Condicao = condicaoPagamento.Condicao, Id = condicaoPagamento.Id });
    }

    public void AtivarInativarCondicaoPagamento(int id, bool ativo)
    {
        var sql = @" UPDATE metodos_pagamento 
                        SET ativo = @Ativo
                    WHERE id = @Id";

        using var connection = CreateConnection();
        connection.Execute(sql, new { Ativo = ativo, Id = id });
    }
}