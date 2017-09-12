using KittyInnovation.Iot.Platform.Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Data
{
    public class UserDal
    {
        public void Connect()
        {
            ISession session = NHibernateHelper.OpenSession();
            using (session)
            {
                Console.WriteLine("是否已经打开数据库链接?" + session.IsOpen);
            }
            Console.WriteLine("数据库是否已经关闭链接?" + session.IsOpen);
        }

        public void Add(User entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(entity);
            }
        }

        public User GetUser(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var user = session.Get<User>(id);
                NHibernateUtil.Initialize(user.Logs);
                return user;
            }
            //var session = NHibernateHelper.OpenSession();
            //return session.Get<User>(id);
        }
    }
}
