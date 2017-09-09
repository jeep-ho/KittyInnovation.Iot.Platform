using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Data
{
    public class NHibernateHelper
    {

        //会话工厂
        public static ISessionFactory factory = null;
        static NHibernateHelper()
        {
            //读取配置文件，根据配置文件创建一个会话工厂，而这个就是从<session-factory>节点中读取的信息
            factory = new Configuration().Configure().BuildSessionFactory();
        }
        //定义一个打开数据库链接的方法
        public static ISession OpenSession()
        {
            //通过工厂打开一个Session(会话)
            return factory.OpenSession();
        }

    }
}
