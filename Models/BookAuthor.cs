using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace E_Day_2.Models
{

    [Table("BookAuthor")]
    public class BookAuthor
    {
        public Book Book{get;set;}

        public Author Author{get;set;}
        
    }
}