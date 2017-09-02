using KittyInnovation.Iot.Platform.WCF.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KittyInnovation.Iot.Platform.WCF.Host
{
    public class Program
    {
        static void Main()
        {
            ServiceHost productSvcHost = new ServiceHost(typeof(ProductService));
            ServiceHost orderSvcHost = new ServiceHost(typeof(OrderService));
            ServiceHost calcSvcHost = new ServiceHost(typeof(CalculatorService));
            productSvcHost.Open();
            orderSvcHost.Open();
            calcSvcHost.Open();

            Console.WriteLine("服务已启动...");
            Console.ReadLine();
        }
    }
}