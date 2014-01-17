using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class OpenCode
    {
        public int OpenCodeID { get; set; }

        [Display(Name = "Код открытия")]
        [Range(1, 8)]
        public int COpen { get; set; }

        public string FCOpen
        {
            get
            {
                switch (COpen)
                {
                    case 1: return COpen.ToString() + "-" + "не звонит звонок";
                    case 2: return COpen.ToString() + "-" + "низкое качество звука";
                    case 3: return COpen.ToString() + "-" + "нет синхронизации";
                    case 4: return COpen.ToString() + "-" + "нет зуммера";
                    case 5: return COpen.ToString() + "-" + "прерывание связи при разговоре";
                    case 6: return COpen.ToString() + "-" + "не доходят звонки к абоненту";
                    case 7: return COpen.ToString() + "-" + "нет выхода на МГ/МН";
                    case 8: return COpen.ToString() + "-" + "ненадлежащее состояние сооружений связи";
                }
                return null;
            }
        }

        public virtual ICollection<Request> Requests { get; set; }
    }
}