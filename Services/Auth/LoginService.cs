public class LoginService
{
    private readonly LoginRepository _loginRepository;
    public LoginService(LoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    public async Task<Usuario> ObterUsuarioPorEmail(string email)
    {
        return await _loginRepository.ObterUsuarioPorEmail(email);
    }
}