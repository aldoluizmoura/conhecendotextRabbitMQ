using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Send
    {
        public static void Main(string text)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               
                var body = Encoding.UTF8.GetBytes(text);

                channel.BasicPublish(exchange: "",
                                      routingKey: "hello",
                                      basicProperties: null,
                                      body: body);

                Console.WriteLine("[x] sent {0}", text);
            }

            Console.WriteLine(" Press [enter] to exit");
            Console.ReadLine(); 
            
        }
    }
}
