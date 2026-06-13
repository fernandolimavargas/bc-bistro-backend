using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class ImprimirController : ControllerBase
{
    private ImprimirService _imprimirService;

    public ImprimirController(ImprimirService imprimirService)
    {
        _imprimirService = imprimirService;
    }

    [HttpGet("reimprimir/{idVenda:int}")] 
    public async Task<IActionResult> Reimprimir([FromRoute] int idVenda)
    {
        try
        {
            var dados = await _imprimirService.Reimprimir(idVenda);
            return Ok(new
            {
                dados
            }); 
        } catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpPost("imprimir")]
    public async Task<IActionResult> Imprimir([FromBody] ReimpressaoDTO imprimir)
    {
        try
        {
            //var dados = await _imprimirService.Imprimir(imprimir);
            return Ok(new
            {
               // dados
            }); 
        } catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpGet("pendentes")]
    public async Task<IActionResult> Pendentes()
    {
        try
        {
            var dados = await _imprimirService.PedidosPendentes();

            return Ok(dados);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("marcar_impresso/{id}")]
    public async Task<IActionResult> MarcarImpresso(int id)
    {
        try
        {
            await _imprimirService.MarcarImpresso(id);

            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}