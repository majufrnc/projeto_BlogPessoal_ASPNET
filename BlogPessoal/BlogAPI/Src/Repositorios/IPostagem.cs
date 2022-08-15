using BlogAPI.Scr.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios
{
    public interface IPostagem
    {
        Task<List<Postagem>> PegarTodasPostagensAsync();
        Task<Postagem> PegarPostagemPeloIdAsync(int id);
        Task NovaPostagemAsync(Postagem postagem);
        Task AtualizarPostagemAsync(Postagem postagem);
        Task DeletarPostagemAsync(int id);
    }
}