using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telecom2.Models
{
    public class Request
    {

        private DateTime _date = DateTime.Now;
        private DateTime? _runDateTime;
        private int? _day;

        protected IList<string> ls = new List<string>();

        protected static Random rand = new Random();

        protected enum RunDates
        {
            rdMorning = 1,
            rdEvening
        }

        public int RequestID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public int OperatorID { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public int ClientID { get; set; } 

        public DateTime RDate
        {
            set { _date = value; }
            get { return _date; }

        }


        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public int OpenCodeID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public int DamageCodeID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public int CloseCodeID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public int EngineerID { get; set; }

        public DateTime? RunDate
        {
            get { return _runDateTime; }
            set { _runDateTime = value; }
        }

        public string runDate()
        {
            var interval = new TimeSpan(9, 0, 0);
            var interval1 = new TimeSpan(14, 0, 0);
            var interval2 = new TimeSpan(18, 0, 0);
            var today = DateTime.Today;
            var time = today + interval;
            var time1 = today + interval1;

            if (RunDate == null)
            {
                if (RunTime == 1)
                    return time.AddDays(1).ToShortDateString()+" " + interval.ToString() + "-" + interval1.ToString();
                if (RunTime == 2)
                    return time1.AddDays(1).ToShortDateString()+ " "+ interval1.ToString() + "-" + interval2.ToString();
            }
            else
            {
                if (RunTime == 1)
                    return (RunDate + interval).ToString() + "-" + interval1.ToString();
                if (RunTime == 2)
                    return (RunDate + interval1).ToString() + "-" + interval2.ToString();
            }
            return null;
        }
        

        public int localTimeEng(int from, int to)
        {
            int local = 0;
            local = rand.Next(from, to);
            return local;
        }

        public string runDateTime()
        {
            var interval = new TimeSpan(localTimeEng(9, 14), localTimeEng(0, 59), localTimeEng(0, 59));
            var interval1 = new TimeSpan(localTimeEng(14, 18), localTimeEng(0, 59), localTimeEng(0, 59));
            var today = DateTime.Today;
            var time = today + interval;
            var time1 = today + interval1;

            if (RunDate == null)
            {
                if (RunTime == 1)
                    return time.AddDays(1).ToString();
                if (RunTime == 2)
                    return time1.AddDays(1).ToString();
            }
            else
            {
                if (RunTime == 1)
                    return (RunDate + interval).ToString();
                if (RunTime == 2)
                    return (RunDate + interval1).ToString();
            }
            return null;
        }
       

        [Range(1, 2, ErrorMessage = "Значение должно быть либо 1(утро), либо 2(вечер)")]
        public int? RunTime
        {
            get
            {
                if (_day == null) return null;
                else if (_day == 1)
                    return (int)RunDates.rdMorning;
                else
                    return (int)RunDates.rdEvening;
            }
            set { _day = value; }
        }

        [DisplayFormat(NullDisplayText = "none")]
        public string RunDay
        {
            get
            {
                if (RunTime == null) return null;
                if (RunTime == (int)RunDates.rdEvening)
                {
                    return runDate() + " " + "Вечер";
                }
                if (RunTime == (int)RunDates.rdMorning)
                {
                    return runDate() + " " + "Утро";
                }
                return null;
            }
        }

        public string Comment { get; set; }
        public string CommentEngi { get; set; }

        public IList<string> Log
        {
            set
            {
                ls.Add(RDate.ToShortDateString() + Operator.LastName + Comment);
                 
            }
            get { return ls; }
        }

        public string FullComment
        {
            get { return RDate.ToString() + " " + Operator.LastName + Environment.NewLine + Comment; }
        }

        public string FullCommentEngi
        {
            get 
            {   
                if (CommentEngi != null)
                return runDateTime() + " " + Engineer.LastName + Environment.NewLine + CommentEngi;
            return null;
            }
        }

        public virtual Operator Operator { get; set; }
        public virtual Client Client { get; set; }
        public virtual Engineer Engineer { get; set; }

        public virtual OpenCode OpenCode { get; set; }
        public virtual DamageCode DamageCode { get; set; }
        public virtual CloseCode CloseCode { get; set; }

    }
}