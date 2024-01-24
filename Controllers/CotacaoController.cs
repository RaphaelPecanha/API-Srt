using Microsoft.AspNetCore.Mvc;
using SRT.ServiceAPI.Context;
using System.Net;
using System.Net.Http;
using SRT.ServiceAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace SRT.ServiceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CotacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Cotacao>> Get()
        {
            var cotacao = _context.Cotacao.AsNoTracking().ToList();
            var statusCotacao = cotacao == null ? StatusCode(StatusCodes.Status404NotFound, "Lista de cotação não encontrada") : StatusCode(StatusCodes.Status200OK, cotacao);

            return statusCotacao;

        }

        [HttpGet("{id:int}", Name ="PostCotacao")]
        public ActionResult<Cotacao> Get(int id)
        {
            var cotacao = _context.Cotacao.AsNoTracking().FirstOrDefault(cot => cot.Id == id);
            var statusCotacao = cotacao == null ? StatusCode(StatusCodes.Status404NotFound, $"Cotação com ID: {id} não encontrada") : StatusCode(StatusCodes.Status200OK, cotacao);

            return statusCotacao;
        }

        [HttpGet("GetLstCotacaoEnviados")]
        public ActionResult<List<Cotacao>> GetLstCotacaoEnviados()
        {
            var cotacao = _context.Cotacao.AsNoTracking().ToList();
            List<Cotacao> lstCotacao = new List<Cotacao>();
            foreach (var cot in cotacao)
            {
                if (cot.Status == "Enviado" || cot.Status == "Enviar") lstCotacao.Add(cot);
            }

            var statusCotacao = lstCotacao == null ? StatusCode(StatusCodes.Status404NotFound, $"Lista de cotação não encontrada") : StatusCode(StatusCodes.Status200OK, lstCotacao);

            return statusCotacao;
        }

        [HttpGet("GetLstCotacaoEnviar")]
        public ActionResult<List<Cotacao>> GetLstCotacaoEnviar()
        {
            var cotacao = _context.Cotacao.AsNoTracking().ToList();
            List<Cotacao> lstCotacao = new List<Cotacao>();
            foreach (var cot in cotacao)
            {
                if (cot.Status == "Enviar") lstCotacao.Add(cot);
            }

            var statusCotacao = lstCotacao == null ? StatusCode(StatusCodes.Status404NotFound, $"Lista de cotação enviadas não encontrada") : StatusCode(StatusCodes.Status200OK, lstCotacao);

            return statusCotacao;

        }

        [HttpGet("GetCotacaoByData")]
        public ActionResult<List<Cotacao>> GetCotacaoByData(DateTime? dataInicial, DateTime? dataFinal)
        {
            var cotacao = _context.Cotacao.AsNoTracking().ToList();
            List<Cotacao> lstCotacao = new List<Cotacao>();
            if (dataInicial == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Lista de cotação enviadas não encontrada");
            }
            foreach(var cot in cotacao)
            {
                if (dataFinal is not null)
                {
                    if (cot.DataRegistro >= dataInicial && cot.DataRegistro <= dataFinal)
                    {
                        lstCotacao.Add(cot);
                        continue;
                    }
                }
                else if (cot.DataRegistro >= dataInicial) { lstCotacao.Add(cot); continue;  }
            }

            var statusCotacao = lstCotacao == null ? StatusCode(StatusCodes.Status404NotFound, $"Lista de cotações não encontrada") : StatusCode(StatusCodes.Status200OK, lstCotacao);
            return statusCotacao;
        }

        [HttpPut("AtualizarEnvioCotacao")]
        public ActionResult<Cotacao> AtualizarEnvioCotacao(int id)
        {
            var cotacao = _context.Cotacao.AsNoTracking().FirstOrDefault(cot => cot.Id == id);

            cotacao.Status = "Enviado";

            _context.Entry(cotacao).State = EntityState.Modified;
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, cotacao);
        }

        [HttpPost("IncluiCotacao")]
        public ActionResult<Cotacao> IncluiCotacao(Cotacao cotacao)
        {
            if (cotacao is null) { return BadRequest("Formato inválido ou nulo"); }
            _context.Cotacao.Add(cotacao);
            _context.SaveChanges();

            return new CreatedAtRouteResult("PostCotacao", new { id = cotacao.Id });
        }

        [HttpPut("CotacaoAtualizarStatus")]
        public ActionResult<Cotacao> CotacaoAtualizarStatus (int id, string status) 
        {
            var cotacao = _context.Cotacao.AsNoTracking().FirstOrDefault(cot => cot.Id == id);

            cotacao.Status = status;

            _context.Entry(cotacao).State = EntityState.Modified;
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, cotacao);
        }

    }

}
