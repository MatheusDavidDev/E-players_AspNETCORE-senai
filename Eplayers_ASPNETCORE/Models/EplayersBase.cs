using System.Collections.Generic;
using System.IO;

namespace Eplayers_ASPNETCORE.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFile(string _path)
        {
            // Database/Equipe.csv
            string folder = _path.Split("/")[0];
            

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path))
            {
                File.Create(_path);
            }
        }

        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> linhas = new List<string>();

            // Using -> Responsavel por abrir e fechar o arquivo automaticamente
            // StreamReader - > Le os dados em um arquivo
            using(StreamReader file = new StreamReader(path))
            {
                string linha;

                // Percorrer as linhas com um laco while
                while( (linha = file.ReadLine()) != null )
                {
                    linhas.Add(linha);
                }
            }
            
            return linhas; 
        }

        public void RewriteCSV(string path, List<string> linhas)
        {
            // StreamWriter -> Escreve dados em um arquivo
            using(StreamWriter output  = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    output.Write(item +'\n');
                }
            }
        }

        
    }
}