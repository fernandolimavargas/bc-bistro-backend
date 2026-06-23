using Dapper;

public class ProdutoRepository: ConexaoDapper
{
    public ProdutoRepository(IConfiguration configuration) : base(configuration) { }

    public List<Produtos> BuscarProdutos()
    {
        var sqlProdutos = @" 
            SELECT 
                p.ID, 
                Nome as Produto, 
                Preco, 
                p.Categoria as IdCategoria,
                ic.categoria as Categoria,
                p.disponivel as Ativo,
                p.descricao as Descricao
                FROM produtos p 
                INNER JOIN inf_categorias ic
                    on ic.id = p.categoria
                order by p.id";

        var connection = CreateConnection();
        return connection.Query<Produtos>(sqlProdutos).ToList();
    }

    public async Task AdicionarProduto(Produtos produto)
    {
        var parameters = new
        {
            Produto = produto.Produto,
            Preco = produto.Preco,
            Categoria = produto.IdCategoria, 
            Descricao = produto.Descricao

        };
        var sqlProduto = @"INSERT INTO produtos (nome, preco, categoria, disponivel, descricao) 
            VALUES (@Produto, @Preco, @Categoria, true, @Descricao)";

        var connection = CreateConnection();
        connection.Execute(sqlProduto, parameters);
    }
    
    public async Task AlterarProduto(Produtos produto)
    {
        var parameters = new
        {
            IdProduto = produto.Id,
            Produto = produto.Produto,
            Preco = produto.Preco,
            Categoria = produto.IdCategoria, 
            Descricao = produto.Descricao
        };

        var sqlAlterarProduto = @"UPDATE produtos SET
                            nome = @Produto, 
                            preco = @Preco,
                            categoria = @Categoria
                            descricao = @Descricao
                            where id = @IdProduto";

        var connection = CreateConnection();
        connection.Execute(sqlAlterarProduto, parameters);
    }

    public void AtivarInativarProduto(int idProduto, bool ativo)
    {
        var sql = @"UPDATE produtos SET 
            disponivel = @ativo
            WHERE id = @idProduto";

        var connection = CreateConnection();
        connection.Execute(sql, new {idProduto, ativo});
    }
}