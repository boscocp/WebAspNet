using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyCoreApplication.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int CPF { get; set; }
    }
}