using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInfoProjects.Model
{
    public class UserTransActionResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public int Sum { get; set; }
        public int? Total { get; set; }
    }
}
