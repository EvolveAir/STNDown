using System;
using System.Net.NetworkInformation;

namespace STNDown.Models
{
    public class CheckedServer
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }

        public PingResult Check()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            try
            {
                PingReply reply = pingSender.Send(this.Location, 5000);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                    return new PingResult { Success = true };
                }
                else
                {
                    Console.WriteLine(reply.Status);
                    return new PingResult { Success = false };
                }
            }
            catch (PingException s)
            {
                return new PingResult { Success = false };
            }
        }
    }
}
