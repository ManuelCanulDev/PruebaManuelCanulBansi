using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WsApiExamen.Models
{
    [Table("tblExamen", Schema = "dbo")]
    public class Examen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idExamen { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
