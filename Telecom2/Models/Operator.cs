using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class Operator : Person
    {
        public int OperatorID { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}