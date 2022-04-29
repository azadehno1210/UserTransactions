using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInfoProjects.Model;
using UserInfoProjects.Services;

namespace UserInfoProjects
{
    public class UserTrans : IUserTrans
    {
        private readonly AppDbContext _dbcontext;
        private int totalValue = 0;

        public UserTrans(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public int IncreaseMe( int value)
        {
            totalValue += value;
           
            return totalValue;
        }
        public List<UserTransActionResult> GetuserTransActionResults()
        {

            int totalsumvalue = 0;

            var res = from temp in (
                  (from uinfo in _dbcontext.userInfos
                   join utrans in _dbcontext.userTrans on new { PersonID = uinfo.PersonID } equals new { PersonID = utrans.PersonId }
                   group new { utrans, uinfo } by new
                   {
                       Column1 = utrans.TransactionDate.Date,
                       uinfo.Name,
                       uinfo.Family,
                       utrans.PersonId
                   } into g
                   select new
                   {
                       PersonId = g.Key.PersonId,
                       g.Key.Name,
                       g.Key.Family,
                       StartDate = g.Key.Column1,
                       enddate = g.Max(p => p.utrans.TransactionDate.Date),
                       SumValue = (int?)g.Sum(p => p.utrans.Price)
                   }))
                      orderby
                        temp.PersonId,
                        temp.StartDate
                      select new UserTransActionResult
                      {
                          Id = temp.PersonId,
                          Name = temp.Name,
                          Family = temp.Family,
                          StartDate = temp.StartDate.Date.ToString(),
                          EndDate = (
                          ((from UT in _dbcontext.userTrans
                            where
                                UT.PersonId == Convert.ToInt32(temp.PersonId) &&
                                UT.TransactionDate.Date > temp.StartDate.Date
                            select UT.TransactionDate.Date.ToString()
                            ))).FirstOrDefault()
                          ,
                          Sum = (int)temp.SumValue,
                          Total = ((from TT in _dbcontext.userTrans
                                    where
                                        TT.PersonId == Convert.ToInt32(temp.PersonId) &&
                                       TT.TransactionDate.Date <= temp.StartDate

                                    select TT.Price
                            )).Sum()
                          

                      };
          

            return res.ToList();
        }
    


}

}
