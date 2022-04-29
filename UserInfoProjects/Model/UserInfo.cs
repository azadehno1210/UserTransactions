using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInfoProjects.Model
{
    public class UserInfo
    {
        [Key, Column(Order = 1)]
       
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
