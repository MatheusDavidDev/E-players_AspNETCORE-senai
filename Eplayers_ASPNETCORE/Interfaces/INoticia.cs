using System.Collections.Generic;
using Eplayers_ASPNETCORE.Models;

namespace Eplayers_ASPNETCORE.Interfaces
{
    public interface INoticia
    {
          //Metodos de CRUD - Contrato
        void Create(Noticia a);

        List<Noticia> ReadAll();

        void Update(Noticia a);

        void Delete(int id);
    }
}