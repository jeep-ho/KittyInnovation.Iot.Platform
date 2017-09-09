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
            var item = user.GetUser(2);
            Console.WriteLine(item.UserName);
            Console.ReadLine();

        }
    }
}
