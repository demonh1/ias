using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public abstract class Person
    {
        
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Поле {0} заполняется кириллицей с большой буквы")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Данное поле должно иметь от 2 до 30 символов.")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Поле {0} заполняется кириллицей с большой буквы")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Данное поле должно иметь от 2 до 20 символов.")]
        public string FirstMidName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [RegularExpression(@"^[А-Я]+[а-яА-Я''-'\s]*$", ErrorMessage = "Поле {0} заполняется кириллицей с большой буквы")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Данное поле должно иметь от 2 до 40 символов.")]
        public string SecondName { get; set; }
    }
}