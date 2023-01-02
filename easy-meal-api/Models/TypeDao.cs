using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easy_meal_api.Models
{
    public class TypeDao
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
