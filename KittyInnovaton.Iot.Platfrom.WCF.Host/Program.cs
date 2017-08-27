using KittyInnovaton.Iot.Platfrom.WCF.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KittyInnovaton.Iot.Platfrom.WCF.Host
{
    public class Program
    {
        static void Main()
        {
            ServiceHost productSvcHost = new ServiceHost(typeof(ProductService));
            ServiceHost orderSvcHost = new ServiceHost(typeof(OrderService));

            productSvcHost.Open();
            orderSvcHost.Open();

            Console.WriteLine("服务已启动...");
            Console.ReadLine();
        }
    }
}