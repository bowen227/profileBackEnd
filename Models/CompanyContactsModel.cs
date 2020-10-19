using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("Company_Contacts")]
    public class CompanyContactsModel
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string companyName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string title { get; set; }
    }
}