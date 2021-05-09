using System;
using System.ComponentModel.DataAnnotations;

namespace MadPay724.Data.Models
{
    public class Photo:BaseEntity<string>
    {
        public Photo()
        {
            ID = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
        [Required]
        public string Url { get; set; }
        public string Description { get; set; }
        [Required]
        public string Alt { get; set; }
        [Required]
        public bool IsMain { get; set; }
        public string UserID { get; set; }

        public User User { get; set; }
    }
}