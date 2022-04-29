using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserInfoProjects.Model
{
    public class UserTransaction
    {
        [Key, Column(Order = 1)]
       
        public int TransactionId { get; set; }
        public int PersonId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Price { get; set; }

    }
}
