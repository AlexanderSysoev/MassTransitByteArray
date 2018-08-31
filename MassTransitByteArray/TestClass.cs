using System;
using System.Threading.Tasks;
using MassTransit;
using NUnit.Framework;

namespace MassTransitByteArray
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public async Task Test()
        {
            var busControl = Bus.Factory.CreateUsingInMemory(config =>
            {
            });

            busControl.Start();

            var sendEndpoint = await busControl.GetSendEndpoint(new Uri("http://test.ru"));

            Assert.DoesNotThrowAsync(async () =>
            {
                await sendEndpoint.Send<SomeContract>(new
                {
                    Bytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
                });
            });
        }
    }

    public interface SomeContract
    {
        byte[] Bytes { get; set; }
    }
}
