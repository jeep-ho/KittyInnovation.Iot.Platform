using KittyInnovation.Iot.Platform.Data;
using KittyInnovation.Iot.Platform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDal user = new UserDal();
            //user.Connect();
            //user.Add(new User { UserName = "hezp", Password = "hezp", Phone = "15989894692", IsSys = 1, CreateTime = DateTime.Now });
            var item = user.GetUser(1);
            Console.WriteLine(string.Format("用户：{0}，日志数：{1}条.", item.UserName, item.Logs.Count));

            //Console.WriteLine(string.Format("用户：{0}.", item.UserName));

            LogDal log = new LogDal();
            log.Add(new Log { Info = DateTime.Now.ToString("yyyyMMddhhmmss"), Ip = "127.0.0.1", LogTime = DateTime.Now, UserId = 1 });

            var temp = log.GetLog(1);
            Console.WriteLine(string.Format("日志编号：{0},对应用户:{1}", temp.Id, temp.User.UserName));

            Console.WriteLine(NHibernateHelper.GetCurrentSession().IsOpen);

            var session1 = NHibernateHelper.GetCurrentSession();
            var session2 = NHibernateHelper.GetCurrentSession();
            Console.WriteLine(session1 == session2);

            var hq1 = " from Log where UserId=?";
            NHibernate.IQuery query = NHibernateHelper.GetCurrentSession().CreateQuery(hq1);
            query.SetParameter(0, 2);
            IList<Log> logs = query.List<Log>();
            foreach (var mlog in logs)
            {
                Console.WriteLine(string.Format(" LogId:{0},LogTime:{1}", mlog.Id, mlog.LogTime));
            }

            Console.ReadLine();

        }
    }
}
