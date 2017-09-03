using KittyInnovation.Iot.Platform.WCF.Server;
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
            ICallBackService callBackService = new CallBackService();
            InstanceContext instanceContext = new InstanceContext(callBackService);

            DuplexChannelFactory<ICalculatorService> calcfactory = new DuplexChannelFactory<ICalculatorService>(instanceContext, typeof(ICalculatorService).FullName);
            ChannelFactory<IOrderService> factory = new ChannelFactory<IOrderService>(typeof(IOrderService).FullName);
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Parallel.For(0, 100, index =>
            {
                //IOrderService orderService = factory.CreateChannel();
                //using (orderService as IDisposable)
                //{
                //    orderService.CreateOrder("编号" + index.ToString("D2"));
                //}

                ICalculatorService calcService = calcfactory.CreateChannel();

                calcService.Add(index, 10);

            });

            watch.Stop();

            Console.WriteLine("==============================================");
            Console.WriteLine(watch.Elapsed);
            Console.ReadKey();
        }
    }
}