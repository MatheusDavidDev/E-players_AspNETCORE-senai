using System.Collections.Generic;
using Eplayers_ASPNETCORE.Models;

namespace Eplayers_ASPNETCORE.Interfaces
{
    public interface IEquipe
    {
        //Metodos de CRUD - Contrato
        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);

    }
}