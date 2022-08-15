using BlogAPI.Scr.Contextos;
using BlogAPI.Scr.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Scr.Repositorios.Implementacoes
{
    public class TemaRepositorio : ITema
    {
        #region Atributos
        private readonly BlogPessoalContexto _contexto;
        #endregion Atributos

        #region Construtores
        public TemaRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion Construtores

        #region Métodos
        public async Task AtualizarTemaAsync(Tema tema)
        {
            var auxiliar = await PegarTemaPeloIdAsync(tema.Id);

            auxiliar.Descricao = tema.Descricao;

            _contexto.Temas.Update(auxiliar);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarTemaAsync(int id)
        {
            _contexto.Temas.Remove(await PegarTemaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        public async Task NovoTemaAsync(Tema tema)
        {
            await _contexto.Temas.AddAsync(new Tema { Descricao = tema.Descricao });
            await _contexto.SaveChangesAsync();
        }

        public async Task<Tema> PegarTemaPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Id do tema não encontrado");
            return await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == id);

            // funções auxiliares
            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Temas.FirstOrDefault(u => u.Id == id);
                return auxiliar != null;
            }
        }
        public async Task<List<Tema>> PegarTodosTemasAsync()
        {
            return await _contexto.Temas.ToListAsync();
        }
        #endregion Métodos
    }
}

