using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace E_Day_2.Models
{

    [Table("Client")]
    public class Client
    {
        [Key]
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string ClientName { get; set; }

        public ICollection<Book> Books {get; set;}
    }
}