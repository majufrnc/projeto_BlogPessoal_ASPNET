using BlogAPI.Scr.Contextos;
using BlogAPI.Scr.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios.Implementacoes
{
    public class PostagemRepositorio : IPostagem
    {
        #region Abributos
        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos

        #region Construtores
        public PostagemRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion Construtores

        #region Métodos
        public async Task AtualizarPostagemAsync(Postagem postagem)
        {
            if (!ExisteTemaId(postagem.Tema.Id)) throw new Exception("Id do tema não encontrado");

            var postagemExistente = await PegarPostagemPeloIdAsync(postagem.Id);
            postagemExistente.Titulo = postagem.Titulo;
            postagemExistente.Descricao = postagem.Descricao;
            postagemExistente.Foto = postagem.Foto;
            postagemExistente.Tema = await _contexto.Temas.FirstOrDefaultAsync(t => t.Id
            == postagem.Tema.Id);
            _contexto.Postagens.Update(postagemExistente);
            await _contexto.SaveChangesAsync();
            // funções auxiliares
            bool ExisteTemaId(int id)
            {
                var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Id == id);
                return auxiliar != null;
            }
        }
        public async Task<Postagem> PegarPostagemPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Id da postagem não encontrado");
            return await _contexto.Postagens
            .Include(p => p.Criador)
            .Include(p => p.Tema)
            .FirstOrDefaultAsync(p => p.Id == id);
            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Postagens.FirstOrDefault(u => u.Id == id);
                return auxiliar != null;
            }
        }
        public async Task DeletarPostagemAsync(int id)
        {
            _contexto.Postagens.Remove(await PegarPostagemPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }
        public async Task NovaPostagemAsync(Postagem postagem)
        {
            if (!ExisteUsuarioId(postagem.Criador.Id)) throw new Exception("Id do usuário não encontrado");
            if (!ExisteTemaId(postagem.Tema.Id)) throw new Exception("Id do tema nãoencontrado");
            await _contexto.Postagens.AddAsync(new Postagem
            {
                Titulo = postagem.Titulo,
                Descricao = postagem.Descricao,
                Foto = postagem.Foto,

                Criador = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == postagem.Criador.Id),

                Tema = await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == postagem.Tema.Id)
            });
            await _contexto.SaveChangesAsync();

            // funções auxiliares
            bool ExisteUsuarioId(int id)
            {
                var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
                return auxiliar != null;
            }
            bool ExisteTemaId(int id)
            {
                var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Id == id);
                return auxiliar != null;
            }
        }
        public async Task<List<Postagem>> PegarTodasPostagensAsync()
        {
            return await _contexto.Postagens
                .Include(p => p.Criador)
                .Include(p => p.Tema)
                .ToListAsync();
        }
        #endregion Métodos
    }
}