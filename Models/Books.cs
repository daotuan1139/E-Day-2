using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace E_Day_2.Models
{

    [Table("Book")]
    public class Book
    {
        [Key]
        [Required]
        public int BookID { get; set; }
        [Required]
        public string BookName { get; set; }

        public int ClientID { get; set; }

        public ICollection<Author> Authors {get; set;}
        
        public Client Client {get; set;}
    }
}