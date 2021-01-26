using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model1.EF;

namespace webapp.Area.Models
{
    public class ViewModel
    {
        web3 db = null;

        public ViewModel()
        {
            db = new web3();

        }
        public List<ulogin> ListAll()
        {
            var list = db.Database.SqlQuery<ulogin>("Sp_User_ListAll").ToList();
            return list;

        }




    }
}