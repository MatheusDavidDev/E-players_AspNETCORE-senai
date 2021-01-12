using System;
using Eplayers_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Eplayers_ASPNETCORE.Controllers
{
    [Route("Equipe")]
    // http://localhost:5000/Equipe
    // http://www.seuendereco/Equipe
    public class EquipeController : Controller
    {
        //Criamos uma instancia de quipeModel
        Equipe equipeModel = new Equipe();
        
        [Route("Listar")]
        public IActionResult Index()
        {
            // Listamos todas as equipes e enviamos para a View, atraves da ViewBag 
            ViewBag.Equipes = equipeModel.ReadAll();
            return  View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            // Chamamos o metodo Create para salvar a novaEquipe no CSV
            equipeModel.Create(novaEquipe);
            // Atualiza a lista de equipes na View 
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}