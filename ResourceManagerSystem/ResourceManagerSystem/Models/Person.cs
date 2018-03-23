using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Models
{
    public abstract class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CI { set; get; }

        [Display(Name="Nombre")]
        [Required(ErrorMessage ="El nombre no puede estar vacio")]
        public string Name { set; get; }

        [Display(Name = "Apellido paterno")]
        [Required(ErrorMessage = "El apellido paterno no puede estar vacio")]
        public string FirstName { set; get; }

        [Display(Name = "Apellido materno")]
        [Required(ErrorMessage = "El apellido materno no puede estar vacio")]
        public string LastName { set; get; }

        [Display(Name = "Telefono/Celular")]
        [Required(ErrorMessage = "El Telefono/Celular no puede estar vacio")]
        public int Phone { set; get; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electronico")]
        public string Email { set; get; }

        [NotMapped]
        public string CompleteName
        {
            get
            {
                return LastName + " " + FirstName + " " + Name;
            }
        }

    }
}
