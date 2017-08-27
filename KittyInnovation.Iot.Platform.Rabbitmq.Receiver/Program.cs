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
                    channel.QueueDeclare("rpc_queue", false, false, false, null);
                    channel.BasicQos(0, 1, false);
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume("rpc_queue", false, consumer);
                    Console.WriteLine(" [x] Awaiting RPC request.");

                    consumer.Received += (model, ea) => {
                        string response = null;
                        var body = ea.Body;
                        var props = ea.BasicProperties;
                        var replyProps = channel.CreateBasicProperties();
                        replyProps.CorrelationId = props.CorrelationId;

                        try
                        {
                            var message = Encoding.UTF8.GetString(body);
                            int n = int.Parse(message);
                            Console.WriteLine(" [.] fib（{0}）", message);
                            response = fib(n).ToString();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("[.]" + ex.Message);
                            response = string.Empty;
                        }
                        finally
                        {
                            var responseBytes = Encoding.UTF8.GetBytes(response);
                            channel.BasicPublish("",props.ReplyTo,replyProps,responseBytes);
                            channel.BasicAck(ea.DeliveryTag, false);
                        }    
                    };


                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int fib(int n)
        {
            if (n == 0 || n == 1) return n;
            return fib(n - 1) + fib(n - 2);
        }
    }
}
