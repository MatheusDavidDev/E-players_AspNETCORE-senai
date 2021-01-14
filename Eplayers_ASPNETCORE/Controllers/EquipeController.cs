using System;
using System.IO;
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

        // http://localhost:5000/Listar
        [Route("Listar")]
        public IActionResult Index()
        {
            // Listamos todas as equipes e enviamos para a View, atraves da ViewBag 
            ViewBag.Equipes = equipeModel.ReadAll();
            return  View();
        }

        // http://localhost:5000/Cadastar
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] );
            novaEquipe.Nome     = form["Nome"];
            
                // Upload Inicio

                // Verificamos se o usuario selecionou um arquivo
                if (form.Files.Count > 0)
                {
                    // Recebemos o arquivo que o usuario enviou e armazenamos na variavel file
                    var file   = form.Files[0];
                    var folder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/Equipes");

                    // Verificamos se o diretorio (pasta) ja existe 
                    // se nao, a criamos
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    
                                // LocalHost:5001 esse e o nosso dominio                   Equipes   imagem.jpg
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", folder, file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    novaEquipe.Imagem  = file.FileName;
                }
                else
                {
                    novaEquipe.Imagem  = "padrao.png";
                }



                // Upload Final

            // Chamamos o metodo Create para salvar a novaEquipe no CSV
            equipeModel.Create(novaEquipe);
            // Atualiza a lista de equipes na View 
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe/Listar");
        }

        // http://localhost:5000/Equipe/1
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}