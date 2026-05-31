public class LoginService
{
    private readonly LoginRepository _loginRepository;
    public LoginService(LoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    public async Task<UsuarioLogin> ExecutarLogin(string usuario, string senha)
    {
        return await _loginRepository.ValidarCredenciais(usuario, senha);
    }
}