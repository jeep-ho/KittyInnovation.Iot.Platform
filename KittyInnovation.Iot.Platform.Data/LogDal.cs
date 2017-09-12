using KittyInnovation.Iot.Platform.Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Data
{
    public class LogDal
    {

        public void Add(Log entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(entity);
            }
        }

        public Log GetLog(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var log = session.Get<Log>(id);
                NHibernateUtil.Initialize(log.User);
                return log;
            }
            //var session = NHibernateHelper.OpenSession();
            //return session.Get<Log>(id);
        }
    }
}
