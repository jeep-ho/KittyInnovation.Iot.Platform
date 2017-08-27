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
            for (int i = 0; i < 10000; i++)
            {
                var rpcClient = new RPCClient();
                Console.WriteLine(" [x] Requesting fib({0})",i);
                var response = rpcClient.Call(i.ToString());
                Console.WriteLine("[.] Get Result is '{0}'", response);
                rpcClient.Close();
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    class RPCClient
    {
        private IConnection connection;
        private IModel channel;
        private string replyQueueName;
        private QueueingBasicConsumer consumer;

        public RPCClient()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "hezp";
            factory.Password = "123456";
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(replyQueueName, true, consumer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string Call(string message)
        {
            var corrId = Guid.NewGuid().ToString();
            var props = channel.CreateBasicProperties();
            props.ReplyTo = replyQueueName;
            props.CorrelationId = corrId;

            var messageBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "rpc_queue", props, messageBytes);

            while (true)
            {
                var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                if(ea.BasicProperties.CorrelationId==corrId)
                {
                    return Encoding.UTF8.GetString(ea.Body);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            connection.Close();
        }
    }
}
