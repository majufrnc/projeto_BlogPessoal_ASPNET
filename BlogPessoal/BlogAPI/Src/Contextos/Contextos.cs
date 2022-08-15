using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameWorkCore;


namespace BlogAPI.Src.Contextos
{
    public class BlogPessoalContexto : DbContext
    {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set }
        public DbSet<Tema> Temas { get; set }
        public DbSet<Postagem> Posstagens { get; set }

        #endregion

        #region Construtores
        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {

        }
        #endregion
    }

}
