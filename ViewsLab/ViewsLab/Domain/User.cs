
namespace ViewsLab.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> datejoined { get; set; }
    }
}
