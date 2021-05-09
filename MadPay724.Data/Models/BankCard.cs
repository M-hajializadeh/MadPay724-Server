using System;
using System.ComponentModel.DataAnnotations;

namespace MadPay724.Data.Models
{
    public class BankCard: BaseEntity<string>
    {
        public BankCard()
        {
            ID = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        [Required]
        public string BankName { get; set; }
        public string Shaba { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string ExpireDateMonth { get; set; }
        [Required]
        public string ExpireDateYear { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}