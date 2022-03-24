using System;
using System.Linq;
namespace Procesor__Biblioteka
{
    public class Intel8086
    {
        public static int IsHex()
        {
                int hexInt = Convert.ToInt32(Console.ReadLine(), 16);
                return hexInt;
        }

        public static int IsHex(string insertString)
        {
            int hexInt = Convert.ToInt32(insertString, 16);
            return hexInt;
        }
    }
    public class Rejest
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Rejest(string n, int v)
        {
            this.Name = n;
            this.Value = v;
        }
    }

    public class Procesor
    {
        public Rejest[] rejestr;
        public Procesor() { }
        public Procesor(string[] insert){
            rejestr = new Rejest[8];
            rejestr[0] = new Rejest("AL", Intel8086.IsHex(insert[0]));
            rejestr[1] = new Rejest("AH", Intel8086.IsHex(insert[1]));
            rejestr[2] = new Rejest("BL", Intel8086.IsHex(insert[2]));
            rejestr[3] = new Rejest("BH", Intel8086.IsHex(insert[3]));
            rejestr[4] = new Rejest("CL", Intel8086.IsHex(insert[4]));
            rejestr[5] = new Rejest("CH", Intel8086.IsHex(insert[5]));
            rejestr[6] = new Rejest("DL", Intel8086.IsHex(insert[6]));
            rejestr[7] = new Rejest("DH", Intel8086.IsHex(insert[7]));
            //WhatToDo();
        }

        public string WhatToDo()
        {
            string program = Console.ReadLine();
            switch(program)
            {
                case "MOV":
                        Mov();
                    break;
                case "XCH":
                        XCH();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa nazwa programu, upewnij się że nie wprowadziłeś literówki");
                    WhatToDo();
                    break;
            }
            return null;
        }

        public int Mov()
        {
            string x = Console.ReadLine().ToUpper();
            string y = Console.ReadLine().ToUpper();

            if (FindFromRejest(x) == -1 || FindFromRejest(y) == -1)
            {
                Console.WriteLine("Jeden z podanych rejestrów jest nieprawidłowy, podaj je ponownie");
                Mov();
            };

            return rejestr[FindFromRejest(x)].Value = rejestr[FindFromRejest(y)].Value;

        }

        public int? XCH()
        {
            string x = Console.ReadLine().ToUpper();
            string y = Console.ReadLine().ToUpper();

            if (FindFromRejest(x) == -1 || FindFromRejest(y) == -1)
            {
                Console.WriteLine("Jeden z podanych rejestrów jest nieprawidłowy, podaj je ponownie");
                Mov();
            };
            int tmp = rejestr[FindFromRejest(x)].Value;
            rejestr[FindFromRejest(x)].Value = rejestr[FindFromRejest(y)].Value;
            rejestr[FindFromRejest(y)].Value = tmp;

            return null;
        }

        public int FindFromRejest(string rejestrName)
        {
            switch (rejestrName)
            {
                case "AL": return 0;
                case "AH": return 1;
                case "BL": return 2;
                case "BH": return 3;
                case "CL": return 4;
                case "CH": return 5;
                case "DL": return 6;
                case "DH": return 7;
                default: return -1;
            }
        }

        public override string ToString()
        {
            return $" AL = {Convert.ToString(rejestr[0].Value, 16).ToUpper()}   AH = {Convert.ToString(rejestr[1].Value, 16).ToUpper()}\n" +
                   $" BL = {Convert.ToString(rejestr[2].Value, 16).ToUpper()}   BH = {Convert.ToString(rejestr[3].Value, 16).ToUpper()}\n" +
                   $" CL = {Convert.ToString(rejestr[4].Value, 16).ToUpper()}   CH = {Convert.ToString(rejestr[5].Value, 16).ToUpper()}\n" +
                   $" DL = {Convert.ToString(rejestr[6].Value, 16).ToUpper()}   DH = {Convert.ToString(rejestr[7].Value, 16).ToUpper()}\n";
        }
    }

}
