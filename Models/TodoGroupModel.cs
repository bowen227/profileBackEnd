using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Todo_Groups")]

    public class TodoGroupModel
    {
        [Key]
        public int id { get; set; }
        public string groupName { get; set; }
        public string userId { get; set; }
    }
}