using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace E_Day_2.Models
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string BookName { get; set; }

        public int ClientID { get; set; } 

    }
}