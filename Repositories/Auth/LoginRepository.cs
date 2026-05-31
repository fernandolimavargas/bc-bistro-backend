using Dapper;

public class LoginRepository : ConexaoDapper
{
    public LoginRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Usuario> ObterUsuarios(string email)
    {
        var sql = "SELECT Id, Email, Senha FROM Usuarios; ";
        var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Usuario>(sql);
    }

    public async Task<UsuarioLogin?> ValidarCredenciais(
    string usuario,
    string senha)
    {
        var sql = @"
            SELECT
                Id,
                Nome,
                Usuario
            FROM Usuarios
            WHERE Usuario = @Usuario
            AND Senha = @Senha";

        var connection = CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<UsuarioLogin>(
            sql,
            new
            {
                Usuario = usuario,
                Senha = senha
            });
    }

    public void CadastrarUsuario(string nome, string sobrenome, string usuario, string senha)
    {
        var sql = @"
            INSERT INTO Usuarios (Nome, Sobrenome, Usuario, Senha)
            VALUES (@Nome, @Sobrenome, @Usuario, @Senha)";

        var connection = CreateConnection();

        connection.Execute(sql, new
        {
            Nome = nome,
            Sobrenome = sobrenome,
            Usuario = usuario,
            Senha = senha
        });
    }
}