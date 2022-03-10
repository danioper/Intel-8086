using System;

namespace Intel_8086
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj AH");
            int ah = isHex(Console.ReadLine());
            Console.WriteLine("Podaj AL");
            int al = isHex(Console.ReadLine());
            Console.WriteLine("Podaj BH");
            int bh = isHex(Console.ReadLine());
            Console.WriteLine("Podaj BL");
            int bl = isHex(Console.ReadLine());
            Console.WriteLine("Podaj CH");
            int ch = isHex(Console.ReadLine());
            Console.WriteLine("Podaj CL");
            int cl = isHex(Console.ReadLine());
            Console.WriteLine("Podaj DH");
            int dh = isHex(Console.ReadLine());
            Console.WriteLine("Podaj DL");
            int dl = isHex(Console.ReadLine());
            Console.WriteLine($"{ah},{al},{bl}");
        }

        static int isHex(string hex)
        {
                int hexInt = Convert.ToInt32(hex, 16);
                return hexInt;
        }
    }
}
