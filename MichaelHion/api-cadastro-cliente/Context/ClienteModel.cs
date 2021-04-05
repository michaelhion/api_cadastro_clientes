using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_cadastro_cliente.Context
{
    [Table("ClientesModel")]
    public class ClienteModel
{
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption
            .Identity)]
        public string Id { get; set; }

        [Column("FirstName")]
        [Required]
        public string FirstName { get; set; }

        [Column("Surname")]
        public string Surname { get; set; }

        [Column("Age")]
        [Required]
        public int Age { get; set; }

        [Column("CreationDate")]
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
