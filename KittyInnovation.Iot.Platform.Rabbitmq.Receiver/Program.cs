using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Rabbitmq.Receiver
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
                    channel.ExchangeDeclare("direct_logs","direct");
                    var queueName = channel.QueueDeclare().QueueName;
                    if (args.Length < 1)
                    {
                        Console.Error.WriteLine("Usage: {0} [info] [warning] [error]",
                        Environment.GetCommandLineArgs()[0]);
                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                        Environment.ExitCode = 1;
                        return;
                    }
                    foreach (var severity in args)
                    {
                        channel.QueueBind(queueName, "direct_logs",severity);
                    }
                    Console.WriteLine(" [*] Waiting for logs.");
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += Consumer_Received;
                    channel.BasicConsume(queueName, true, consumer);


                    //channel.QueueDeclare("hello", true, false, false, null);
                    //channel.CreateBasicProperties().Persistent = true;
                    //channel.BasicQos(0, 1, false);
                    //var consumer = new EventingBasicConsumer(channel);
                    //consumer.Received += Consumer_Received;
                    //channel.BasicConsume("hello", false, consumer);
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(" [x] Received {0}", message);

            int dots = message.Split('.').Length - 1;
            Thread.Sleep(dots * 1000);

            Console.WriteLine(" [x] Done");
        }
    }
}
