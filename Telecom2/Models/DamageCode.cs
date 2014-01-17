using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class DamageCode
    {
        public int DamageCodeID { get; set; }

        [Display(Name = "Код повреждения")]
        [Range(0, 6)]
        public int CDamage { get; set; }

        public string FCDamage
        {
            get
            {
                switch (CDamage)
                {
                    case 0: return "none";
                    case 1: return CDamage.ToString() + "-" + "перезагрузка по питанию ONT";
                    case 2: return CDamage.ToString() + "-" + "исправлена схема подключения";
                    case 3: return CDamage.ToString() + "-" + "произведена замена ONT";
                    case 4: return CDamage.ToString() + "-" + "произведена замена оптического кабеля";
                    case 5: return CDamage.ToString() + "-" + "рекомендовано заменить ТА";
                    case 6: return CDamage.ToString() + "-" + "неправильный набор клиентом номера";

                }
                return null;
            }
        }

        public virtual ICollection<Request> Requests { get; set; }
    }
}