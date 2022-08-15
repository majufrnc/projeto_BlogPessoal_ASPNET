using BlogAPI.Scr.Contextos;
using BlogAPI.Scr.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTeste.Contextos
{
    [TestClass]
    public class PostagemContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovaPostagemRetornaPostagemInserida()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT1")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Maju França",
                Email = "mjfrnc@gmail.com",
                Senha = "13121997",
                Foto = "URLFOTOMAJU",
            });
            _contexto.SaveChanges();

            _contexto.Temas.Add(new Tema
            {
                Descricao = "GATINHOS EXPLOSIVOS"
            });
            _contexto.SaveChanges();

            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "O MELHOR JOGO JÁ CRIADO",
                Descricao = "Um simples jogo físico de cartas, Exploding Kittens coloca os jogadores em situações complicadas enquanto tentam evitar serem mandados pelos ares por gatinhos curiosos e seus materiais explosivos favoritos. A cada novo card sacado, os participantes ganham a chance de distrair os bichanos de diversas formas ou de passar a bomba para as mãos do próximo infeliz.",
                Foto = "URLDAFOTOGE",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
                "mjfrnc@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "JOGOS")
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Postagens.FirstOrDefault(p => p.Titulo ==
            "O MELHOR JOGO JÁ CRIADO");

            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void LerListaDePostagensRetornaTresPostagens()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Maju França",
                Email = "mjfrnc@gmail.com",
                Senha = "13121997",
                Foto = "URLFOTOMAJU",
            });
            _contexto.SaveChanges();

            _contexto.Temas.Add(new Tema
            {
                Descricao = "JOGOS DE TABULEIRO"
            });
            _contexto.SaveChanges();

            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "Vários tipos de jogos",
                Descricao = "Quest, War, Catan, 7 wonders, Interpol, Detetive",
                Foto = "URLDAFOTOJOGOS",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
                "mjfrnc@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "JOGOS")
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Postagens.ToList();

            Assert.AreEqual(1, resultado.Count);
        }
        [TestMethod]
        public void AtualizarPostagenRetornaPostagenAtualizado()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT3")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Maju França",
                Email = "mjfrnc@gmail.com",
                Senha = "13121997",
                Foto = "URLFOTOMAJU",
            });
            _contexto.SaveChanges();

            _contexto.Temas.Add(new Tema
            {
                Descricao = "JOGOS ONLINE"
            });
            _contexto.SaveChanges();

            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "Jogos online, quais opções?",
                Descricao = "CS, COD, LOL, Transformice, FF etc",
                Foto = "URLDAFOTOJO",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email == "mjfrnc@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "JOGOS ONLINE")
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Postagens.FirstOrDefault(p => p.Id == 1);
            auxiliar.Descricao = "Jogos online";
            _contexto.Postagens.Update(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Postagens.FirstOrDefault(p => p.Id == 1);

            Assert.AreEqual("Jogos online",
            resultado.Descricao);
        }
        [TestMethod]
        public void DeletaPostagemRetornaPostagemInesistente()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_PCT4")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Maju França",
                Email = "mjfrnc@gmail.com",
                Senha = "13121997",
                Foto = "URLFOTOMAJU",
            });
            _contexto.SaveChanges();

            _contexto.Temas.Add(new Tema
            {
                Descricao = "JOGOS"
            });
            _contexto.SaveChanges();

            _contexto.Postagens.Add(new Postagem
            {
                Titulo = "Cursos online de Tatuagem",
                Descricao = "Bora assistir esses cursos e ficar foda",
                Foto = "URLDAFOTOCURSOS",
                Criador = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
                "mjfrnc@gmail.com"),
                Tema = _contexto.Temas.FirstOrDefault(t => t.Descricao == "CURSOS")
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Postagens.FirstOrDefault(p => p.Titulo ==
            "Cursos online de Tatuagem");
            _contexto.Postagens.Remove(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Postagens.FirstOrDefault(p => p.Titulo ==
            "Cursos online de Tatuagem");

            Assert.IsNull(resultado);
        }
        #endregion
    }
}