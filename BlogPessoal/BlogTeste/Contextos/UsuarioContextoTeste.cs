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
    public class UsuarioContextoTeste
    {
        #region Atributos
        private BlogPessoalContexto _contexto;
        #endregion

        #region Métodos
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
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

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
            "mjfrnc@gmail.com");

            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void LerListaDeUsuariosRetornaTresUsuarios()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Paulo Augusto",
                Email = "pauloacl@email.com",
                Senha = "31071997",
                Foto = "URLFOTOPAULO",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Mariana Scavone",
                Email = "mariscavone@email.com",
                Senha = "11122000",
                Foto = "URLFOTOMARI",
            });
            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Vivian Turini",
                Email = "vivturini@email.com",
                Senha = "23011995",
                Foto = "URLFOTOVIV",
            });
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.ToList();

            Assert.AreEqual(3, resultado.Count);
        }
        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT3")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Jaqueline Tavares",
                Email = "jaqtavares@email.com",
                Senha = "27091996",
                Foto = "URLFOTOJAQ",
            });
            _contexto.SaveChanges();


            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
            "jaqtavares@email.com");
            auxiliar.Nome = "Jaqueline Tavares";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Jaqueline Tavares");

            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void DeletaUsuarioRetornaUsuarioInesistente()
        {

            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT4")
            .Options;
            _contexto = new BlogPessoalContexto(opt);

            _contexto.Usuarios.Add(new Usuario
            {
                Nome = "Rafael Candeias",
                Email = "rafaelcandeias@email.com",
                Senha = "134652",
                Foto = "URLFOTORAFAEL",
            });
            _contexto.SaveChanges();

            var auxiliar = _contexto.Usuarios.FirstOrDefault(u => u.Email ==
            "rafaelcandeias@email.com");
            _contexto.Usuarios.Remove(auxiliar);
            _contexto.SaveChanges();

            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Nome == "Rafael Candeias");

            Assert.IsNull(resultado);
        }
        #endregion
    }
}