using BlogAPI.Src.Modelos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogAPI.Scr.Modelos
{
    [Table("tb_postagens")]
    public class Postagem
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        [ForeignKey("fk_usuario")]

        public Usuario Criador { get; set; }
        [ForeignKey("fk_tema")]
        public Tema Tema { get; set; }

        #endregion
    }

}