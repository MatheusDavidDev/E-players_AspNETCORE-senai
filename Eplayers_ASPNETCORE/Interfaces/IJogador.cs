using System.Collections.Generic;
using Eplayers_ASPNETCORE.Models;

namespace Eplayers_ASPNETCORE.Interfaces
{
    public interface IJogador
    {
         void Create(Jogador j);

         List<Jogador> ReadAll();

         void Update (Jogador j);

         void Delete(int id);

    }
}