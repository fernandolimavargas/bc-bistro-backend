using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class CatalogoController: ControllerBase 
{

    private readonly CatalogoService _catalogoService;

    public CatalogoController (CatalogoService catalogoService)
    {
        _catalogoService = catalogoService;
    }

    [HttpGet("mostrar_catalogo/{filtro:int}")]
    public IActionResult MostrarCatalogo([FromRoute] int filtro = 0)
    {
        try
        {
            return Ok(_catalogoService.MostrarCatalogo(filtro));
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("mostrar_condicoes_pagamento")]
    public IActionResult MostrarCondicoesPagamento()
    {
        try
        {
            return Ok(_catalogoService.MostrarCondicoesPagamento());
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("adicionar_condicao_pagamento")]
    public IActionResult AdicionarCondicaoPagamento([FromBody] CondicoesPagamento condicaoPagamento)
    {
        try
        {
            _catalogoService.AdicionarCondicaoPagamento(condicaoPagamento);
            return Ok("Condição de pagamento adicionada com sucesso");
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("remover_condicao_pagamento/{id:int}")]
    public IActionResult RemoverCondicaoPagamento([FromRoute] int id)
    {
        try
        {
            _catalogoService.RemoverCondicaoPagamento(id);
            return Ok("Condição de pagamento removida com sucesso");
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("alterar_condicao_pagamento")]
    public IActionResult AlterarCondicaoPagamento([FromBody] CondicoesPagamento condicaoPagamento)
    {
        try
        {
            _catalogoService.AlterarCondicaoPagamento(condicaoPagamento);
            return Ok("Condição de pagamento alterada com sucesso");
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("ativar_inativar_condicao_pagamento")]
    public IActionResult AtivarInativarCondicaoPagamento([FromQuery] int idCondicaoPagamento, bool ativo)
    {
        try
        {
            _catalogoService.AtivarInativarCondicaoPagamento(idCondicaoPagamento, ativo);
            return Ok($"Condição de pagamento {(ativo ? "Ativada" : "Inativada")} com sucesso");
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

     
    
}