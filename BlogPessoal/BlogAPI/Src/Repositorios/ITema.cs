using BlogAPI.Scr.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios
{
    public interface ITema
    {
        Task<List<Tema>> PegarTodosTemasAsync();
        Task<Tema> PegarTemaPeloIdAsync(int id);
        Task NovoTemaAsync(Tema tema);
        Task AtualizarTemaAsync(Tema tema);
        Task DeletarTemaAsync(int id);
    }

}