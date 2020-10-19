using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Companies")]
    public class CompanyModel
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string companyName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
    }
}