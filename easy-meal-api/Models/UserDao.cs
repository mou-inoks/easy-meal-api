using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easy_meal_api.Models
{
    public class UserDao
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }    

    }
}
