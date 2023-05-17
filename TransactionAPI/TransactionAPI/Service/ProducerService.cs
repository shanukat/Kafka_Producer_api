using Confluent.Kafka;
using Newtonsoft.Json;
using TransactionAPI.Models;

namespace TransactionAPI.Service
{
    public class ProducerService
    {
        private ProducerConfig _producerconfiguration;
        private string _topic;

        public ProducerService(ProducerConfig producerconfiguration, string topic)
        {
            _producerconfiguration = producerconfiguration;
            _topic = topic;
        }




        /// <summary>
        /// This Method use the producers can simply publish messages to Kafka Topic from anywhere
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<int> SentMessages(TransactionDetails transaction)
        {
            int result = 0;
           
            string message = JsonConvert.SerializeObject(transaction);
            //var topic = _topic;
            using (var producer = new ProducerBuilder<Null, string>(_producerconfiguration).Build())
            {
                try
                {
                    //var pConfg = new Dictionary<string, object>()
                    // {
                    //    { "bootstrap.servers", "localhost:9092" },
                    //    { "default.topic.config", new Dictionary<string, object>()
                    //        {
                    //            { "message.timeout.ms", 5000 }
                    //        }
                    //    },
                    //    { "message.send.max.retries", 0 }
                    // };


                    await producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });// creating a new message to kafkaTopic
                     //producer.Flush(TimeSpan.FromSeconds(10));

                    result = 1;

                }
                catch (Exception ex)
                {
                    result = 0;
                    throw;
                }
            }

            return result;
        }


    }
}
