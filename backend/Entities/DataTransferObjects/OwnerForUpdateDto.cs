using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entities.DataTransferObjects
{
    public class OwnerForUpdateDto
    {
        [Required(ErrorMessage = "Campo obrigatório: Nome")]
        [StringLength(60, ErrorMessage = "O Nome não pode ter mais de 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Data de Nascimento")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: Endereço")]
        [StringLength(100, ErrorMessage = "O Endereço não pode ter mais de 100 caracteres")]
        public string Adress { get; set; }
        
    }
}