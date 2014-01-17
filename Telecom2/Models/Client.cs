using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class Client : Person
    {
        public int ClientID { get; set; }

        
        [Display(Name = "Телефон")]
        [RegularExpression(@"^[0-9]{7}$", ErrorMessage = "Введенный номер имеет недопустимый формат.")]
        public string Phone { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Address { get; set; }

        [Display(Name = "Район")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Region { get; set; }

        
        public virtual ICollection<Operator> Operators { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual Engineer Engineer { get; set; }
    }
}