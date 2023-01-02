using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easy_meal_api.Models
{
    public class RepasDao
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingrédients { get; set; }
    }
}
