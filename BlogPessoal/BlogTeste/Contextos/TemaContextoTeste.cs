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
    public class TemaContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovoTemaRetornaTemaInserido()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_TCT1")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Temas.Add(new Tema
            {
                Descricao = "CSHARP"
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Temas.FirstOrDefault(t => t.Descricao ==
            "CSHARP");

            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void LerListaDeTemasRetornaTresTemas()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_TCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Temas.Add(new Tema
            {
                Descricao = "CSHARP"
            });
            _contexto.Temas.Add(new Tema
            {
                Descricao = "Java"
            });
            _contexto.Temas.Add(new Tema
            {
                Descricao = "Go"
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Temas.ToList();

            Assert.AreEqual(3, resultado.Count);
        }
        [TestMethod]
        public void AtualizarTemaRetornaTemaAtualizado()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_TCT3")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Temas.Add(new Tema
            {
                Descricao = "COBOL"
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Descricao == "COBOL");
            auxiliar.Descricao = "Python";
            _contexto.Temas.Update(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Temas.FirstOrDefault(t => t.Descricao ==
            "Python");

            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void DeletaTemaRetornaTemaInesistente()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_TCT4")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Temas.Add(new Tema
            {
                Descricao = "Typescript"
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Descricao ==
            "Typescript");
            _contexto.Temas.Remove(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Temas.FirstOrDefault(t => t.Descricao ==
            "Typescript");

            Assert.IsNull(resultado);
        }
        #endregion
    }
}