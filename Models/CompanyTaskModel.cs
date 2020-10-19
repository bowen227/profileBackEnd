using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string company { get; set; }
        public string task { get; set; }
        public bool completed { get; set; }
    }
}