using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Raymaker.RedisTutorial.Models
{
    public class RedisSubscriber : BackgroundService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisSubscriber(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = this.connectionMultiplexer.GetSubscriber();
            return subscriber.SubscribeAsync(channel: "messages", handler: ((channel, value)
                  =>
              {
                  Console.WriteLine($"The message content was '{value}'");
              }));
        }
    }
}
