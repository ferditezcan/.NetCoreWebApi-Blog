using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class Post
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       // public Guid Id { get; set; }
        //Guid
        [StringLength(200)]
        [Required]
        public string title { get; set; }

        [StringLength(500)]
        public string summary { get; set; }

        [Required]
        public int status { get; set; }

        [StringLength(65535)]
        [Required]
        public string content { get; set; }

        [Required]
        public string pictureUrl { get; set; }     // resimler farklı bir tabloya alınabilir  

        [Required]
        public DateTime? createdAt { get; set; }         

        [Required]
        public DateTime? updatedAt { get; set; }

        //[Required]
        //public string authorId { get; set; }

        //[Required]
        //public string categoryId { get; set; }

    }
}
