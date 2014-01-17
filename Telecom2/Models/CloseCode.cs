using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class CloseCode
    {
        public int CloseCodeID { get; set; }


        [Display(Name = "Код закрытия")]
        [Range(0, 2)]
        public int CClose { get; set; }

        public string FCClose
        {
            get
            {
                if (CClose == 0) return "none";
                else if (CClose == 1) return CClose.ToString() + "-" + "повреждение устранено, услуга заработала";
                else if (CClose == 2) return CClose.ToString() + "-" + "клиент выполнит действия позднее";
                else return null;
            }
        }
        public virtual ICollection<Request> Requests { get; set; }
    }
}