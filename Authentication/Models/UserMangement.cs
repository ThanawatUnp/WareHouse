using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Models
{
    public class UserMangement
    {
        [Key]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        public char reset_state { get; set; }

        public string language { get; set; }

        public string action { get; set; }

        public string sub_action { get; set; }

        public string token { get; set; }

        public string user_define1 { get; set; }

        public string user_define2 { get; set; }

        public string user_define3 { get; set; }
    }
}
