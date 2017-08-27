using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Rabbitmq.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "hezp";
            factory.Password = "123456";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("direct_logs", "direct");//交换机
                    var severity = (args.Length > 0) ? args[0] : "info";   
                    string message = GetMessage(args);
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    properties.Persistent = true;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("direct_logs", severity, properties, body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);

                    //channel.QueueDeclare("hello", true, false, false, null);
                    //string message = GetMessage(args);
                    //var properties = channel.CreateBasicProperties();
                    //properties.DeliveryMode = 2;
                    //properties.Persistent = true;
                    //var body = Encoding.UTF8.GetBytes(message);
                    //channel.BasicPublish("", "hello", properties, body);
                    //Console.WriteLine(" set {0}", message);            
                }
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        private static string GetMessage(string[] args)
        {
           return (args.Length > 1)
                        ? string.Join(" ", args.Skip(1).ToArray()) : Guid.NewGuid().ToString();
        }
    }
}
