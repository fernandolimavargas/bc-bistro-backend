using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class Login : ControllerBase
{
    private readonly LoginService _loginService;

    public Login(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("ExecutarLogin")]
    public async Task<IActionResult> Entrar([FromBody] LoginRequest request)
    {
        // Aqui você pode implementar a lógica de autenticação, por exemplo:
        if (string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Senha))
        {
            return BadRequest("Usuário e senha são obrigatórios.");
        }

        var usuario = await _loginService.ExecutarLogin(request.Usuario, request.Senha);
        if (usuario != null)
        return Ok(new
        {
            usuario = new
            {
                id = usuario.Id,
                nome = usuario.Nome,
                usuario = usuario.Usuario
            }
        });

        return Unauthorized();
    }

    [HttpPost("CadastrarUsuario")]
    public IActionResult CadastrarUsuario([FromBody] CadastrarUsuario request)
    {
        // Aqui você pode implementar a lógica de cadastro de usuário, por exemplo:
        if (string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Senha))
        {
            return BadRequest("Usuário e senha são obrigatórios.");
        }

        _loginService.CadastrarUsuario(request.Nome, request.Sobrenome, request.Usuario, request.Senha);

        return Ok("Usuário cadastrado com sucesso.");
    }
}