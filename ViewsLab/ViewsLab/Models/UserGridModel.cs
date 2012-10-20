using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewsLab.Domain;

namespace ViewsLab.Models
{
    public class UserGridModel
    {
        public IEnumerable<User> Users { get; set; }
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}