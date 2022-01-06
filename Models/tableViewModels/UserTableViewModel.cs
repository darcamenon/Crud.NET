using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_MVC.Models.tableViewModels
{
    public class UserTableViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
    }
}   