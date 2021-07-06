using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace E_Day_2.Models
{

    [Table("Author")]
    public class Author
    {
        [Key]
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public string AuthorName { get; set; }

        public ICollection<Book> Books {get; set;}
    }
}