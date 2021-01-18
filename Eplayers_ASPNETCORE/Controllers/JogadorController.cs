using System;
using Eplayers_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eplayers_ASPNETCORE.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            ViewBag.jogadores = jogadorModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador   = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Nome      = form["Nome"];
            novoJogador.Email     = form["Email"];
            novoJogador.Senha     = form["Senha"];

            jogadorModel.Create(novoJogador);
            ViewBag.jogadores = jogadorModel.ReadAll();

            return LocalRedirect("~/Jogador");
        }
    }
}