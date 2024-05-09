using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public static class Temp
    {
        public static bool bSearchState = false;
        public static List<string> lSearch = new List<string>();
        public static int iSearchCount = 0;
    }

    public class ManagePageNumber
    {
        public Int32 PerPage { get; set; }
        public Int32 PageNo { get; set; }
        public Int32 TotalRec { get; set; }
        public Int32 MaxPage { get; set; }
        public Int32 SkipRec { get; set; }
        public Int32 FirstRec { get; set; }
        public Int32 LastRec { get; set; }

        public Int32 PerPageItm { get; set; }
        public Int32 PageNoItm { get; set; }
        public Int32 TotalRecItm { get; set; }
        public Int32 MaxPageItm { get; set; }
        public Int32 SkipRecItm { get; set; }
        public Int32 FirstRecItm { get; set; }
        public Int32 LastRecItm { get; set; }

        public Int32 PerPageSubItm { get; set; }
        public Int32 PageNoSubItm { get; set; }
        public Int32 TotalRecSubItm { get; set; }
        public Int32 MaxPageSubItm { get; set; }
        public Int32 SkipRecSubItm { get; set; }
        public Int32 FirstRecSubItm { get; set; }
        public Int32 LastRecSubItm { get; set; }
    }
}
