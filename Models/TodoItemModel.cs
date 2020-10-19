using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Todos")]
    public class TodoItemModel
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string groupName { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
    }
}