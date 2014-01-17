using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class Engineer : Person
    {
        
        public int EngineerID { get; set; }

        [Display(Name = "Подразделение")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(0, 9, ErrorMessage = "Поле {0} должно  содержать номер от 0 до 9")]
        public int RegionNumber { get; set; }

        public string FullRegion
        {
            get
            {
                switch (RegionNumber)
                {
                    case 0: return "none";
                    case 1: return RegionNumber.ToString() + "-" + "Выборгский";
                    case 2: return RegionNumber.ToString() + "-" + "Калининский";
                    case 3: return RegionNumber.ToString() + "-" + "Кировский";
                    case 4: return RegionNumber.ToString() + "-" + "Центральный";
                    case 5: return RegionNumber.ToString() + "-" + "Красногвардейский";
                    case 6: return RegionNumber.ToString() + "-" + "Пушкинский";
                    case 7: return RegionNumber.ToString() + "-" + "Петроградский";
                    case 8: return RegionNumber.ToString() + "-" + "Невский";
                    case 9: return RegionNumber.ToString() + "-" + "Приморский";

                }
                return null;
            }
        }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

    }
}