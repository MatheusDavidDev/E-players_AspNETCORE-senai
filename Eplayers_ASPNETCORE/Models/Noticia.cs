using System.Collections.Generic;
using System.IO;
using Eplayers_ASPNETCORE.Interfaces;

namespace Eplayers_ASPNETCORE.Models
{
    public class Noticia : EplayersBase , INoticia
    {
        public int IdNoticia { get; set; }
        
        public string Titulo { get; set; }
        
        public string Texto { get; set; }
        
        public string Imagem { get; set; }

        private const string PATH = "Database/Noticia.csv";

        public Noticia()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Noticia a)
        {
            return $"{a.IdNoticia};{a.Titulo};{a.Texto};{a.Imagem}";
        }

        public void Create(Noticia a)
        {
            string[] linhas = { Prepare(a) };
            File.AppendAllLines(PATH, linhas);
        }

        public List<Noticia> ReadAll()
        {
            List<Noticia> noticias = new List<Noticia>();
            // Lemos todas as linhs do CSV
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //1;Titulo;Texto;img.jpg
                //[0] = 1
                //[1] = Titulo
                //[2] = Texto
                //[3] = Img.jpg
                string[] linha = item.Split(";");

                Noticia novaNoticia = new Noticia();
                novaNoticia.IdNoticia = int.Parse( linha[0] );
                novaNoticia.Titulo    = linha[1];
                novaNoticia.Texto     = linha[2];
                novaNoticia.Imagem    = linha[3];
                noticias.Add(novaNoticia);
            }

            return noticias;
        }

        public void Update(Noticia a)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // 1;Titulo;Texto;snk.jpg
            // Removemos as linhas com  codigo comparado
            linhas.RemoveAll(x => x.Split(";")[0] == a.IdNoticia.ToString());

            // Adicionamos na lista a equipe alterada
            linhas.Add( Prepare(a) );

            // Reescreve csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            // 2;Titulo;Texto;notic.jpg
            // Removemos as linhas com  codigo comparado
            // ToString -> Converte para texto (string)
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            // Reescreve csv com a lista alterada
            RewriteCSV(PATH, linhas);
        }
    }
}