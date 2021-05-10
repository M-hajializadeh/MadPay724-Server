using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace MadPay724.Data.DTOs.Site.Admin
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده صحیح نیست")]
        public string UserName { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3,ErrorMessage = "پسورد باید بین 3 تا 20 کاراکتر باشد")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
