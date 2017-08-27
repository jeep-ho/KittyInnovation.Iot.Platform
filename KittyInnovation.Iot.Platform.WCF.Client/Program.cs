using KittyInnovaton.Iot.Platfrom.WCF.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;

namespace KittyInnovation.Iot.Platform.WCF.Client
{
    public class Program
    {
        static void Main()
        {
            ChannelFactory<IOrderService> factory = new ChannelFactory<IOrderService>(typeof(IOrderService).FullName);
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Parallel.For(0, 100, index =>
            {
                IOrderService orderService = factory.CreateChannel();

                orderService.CreateOrder("编号" + index.ToString("D2"));
            });

            watch.Stop();

            Console.WriteLine("==============================================");
            Console.WriteLine(watch.Elapsed);
            Console.ReadKey();
        }
    }
}