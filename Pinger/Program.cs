using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
  class Program
  {
    static private void PingAll(List<string> ips)
    {
      ips.AsParallel().Select(ip => { Console.WriteLine("Try " + ip); Ping ping = new Ping(); ping.PingCompleted += Ping_PingCompleted; ping.SendAsync(ip, 2000);  return string.Empty; } );
    }
    static private void Ping_PingCompleted(object sender, PingCompletedEventArgs e)
    {
      if (e.Error == null && e.Reply != null)
        Console.WriteLine(e.Reply.Address.ToString() + " - Ok!");
      else Console.WriteLine(e.Reply.Address.ToString() + " - Bad!");
    }

    static void Main(string[] args)
    {
      List<string> ips = new List<string>();
      for (int i = 45; i < 50; i++)
      {
        ips.Add("109.252.44." + i.ToString());
      }
      PingAll(ips);
      Console.ReadKey();
    }
  }
}
