using System;

namespace DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string hello = Roket.NET.Cryptography.Base64Encode("helloworld");


            Console.WriteLine(hello);

            string news = Roket.NET.Cryptography.Base64Decode(hello);

            Console.WriteLine(news);

        }
    }
}
