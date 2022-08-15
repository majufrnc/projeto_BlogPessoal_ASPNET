using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogAPI.Src.Modelos
{

[Table("tb_temas")]
public class Tema
    {
    #region Atributos

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Descricao { get; set; }

    [JsonIgnore, InverseProperty("Tema")]
    public List<Postagem> PostagensRelacionadas { get; set; }

        #endregion
    }
}
