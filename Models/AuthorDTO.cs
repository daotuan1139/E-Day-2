using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace E_Day_2.Models
{
    public class AuthorDTO
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }

    }
}