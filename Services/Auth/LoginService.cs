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

    public void CadastrarUsuario(string nome, string sobrenome, string usuario, string senha)
    {
        _loginRepository.CadastrarUsuario(nome, sobrenome, usuario, senha);
    }
}