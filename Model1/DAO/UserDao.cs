using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model1.EF;
using System.Data.SqlClient;
using System.Data.Sql;




namespace Model1.DAO
{
    public class UserDao
    {
        web3 db = null;

        public UserDao()
        {
            db = new web3();

        }

        public long Insert(ulogin entity)
        {
            db.ulogins.Add(entity);
            db.SaveChanges();
            return entity.uid;

        }
        public ulogin GetById(string userName)
        {
            return db.ulogins.SingleOrDefault(x => x.username == userName);
        }

        public bool AdminLogin(string userName , string passW)
        {
            var result = db.ulogins.Count(x => x.username == userName && x.pass == passW &&  x.Admin == true ) ;
            if (result > 0)
                return true; 
            else
                return false;
        }
        public bool UserLogin(string userName, string passW)
        {
            var result = db.ulogins.Count(x => x.username == userName && x.pass == passW && x.Admin == false);
            if (result > 0)
                return true;
            else
                return false;
        }
        public ulogin ViewDetail(int id)
        {
            return db.ulogins.Find(id);
        }

        public long Insert1 (ulogin entity)
        {
            db.ulogins.Add(entity);
            db.SaveChanges();
            return entity.uid;

        }
        public bool Update(ulogin entity)
        {
            try
            {
                var user = db.ulogins.Find(entity.uid);
                user.username = entity.username;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                object[] parameters =
                { new SqlParameter ("@id",id), };
                int res = db.Database.ExecuteSqlCommand("Sp_Delete_Users @id", parameters);
                return true;

            }
            catch
            {
                return false;
            }


        }
    }
}
