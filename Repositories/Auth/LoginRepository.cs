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
}