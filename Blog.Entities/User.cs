using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // public Guid Id { get; set; }
        //Guid
        [StringLength(200)]
        [Required]
        public string UserName { get; set; }
        [StringLength(200)]
        [Required]
        public string Password { get; set; }
        [StringLength(500)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        [Required]
        public string Surname { get; set; }

        [StringLength(500)]
        public string Phone { get; set; }

        [StringLength(500)]
        [Required]
        public string EMail { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }

        public bool Auth { get; set; }
    }
}
