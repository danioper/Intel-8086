using System;

namespace Procesor__Biblioteka
{
    public class Intel8086
    {
        public static int IsHex()
        {
            try
            {
                int hexInt = Convert.ToInt32(Console.ReadLine(), 16);
                return hexInt;
            }
            catch
            {
                Console.WriteLine("Podano wartość poza zakresem hex, podaj liczbę jeszcze raz");
                return Intel8086.IsHex();
            }
        }
    }

    public class Procesor
    {
        public int[] rejestry = new int[8];

        public Procesor(){
            rejestry[0] = Intel8086.IsHex();
            rejestry[1] = Intel8086.IsHex();
            rejestry[2] = Intel8086.IsHex();
            rejestry[3] = Intel8086.IsHex();
            rejestry[4] = Intel8086.IsHex();
            rejestry[5] = Intel8086.IsHex();
            rejestry[6] = Intel8086.IsHex();
            rejestry[7] = Intel8086.IsHex();
            WhatToDo();
        }

        public string WhatToDo()
        {
            string program = Console.ReadLine();
            switch(program)
            {
                case "MOV":
                    Console.WriteLine("HEJ");
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
            return 0;
        }

        public int XCH()
        {
            return 0;
        }

        public override string ToString()
        {
            return $" AL = {Convert.ToString(rejestry[0], 16).ToUpper()}   AH = {Convert.ToString(rejestry[1], 16).ToUpper()}\n" +
                   $" BL = {Convert.ToString(rejestry[2], 16).ToUpper()}   BH = {Convert.ToString(rejestry[3], 16).ToUpper()}\n" +
                   $" CL = {Convert.ToString(rejestry[4], 16).ToUpper()}   CH = {Convert.ToString(rejestry[5], 16).ToUpper()}\n" +
                   $" DL = {Convert.ToString(rejestry[6], 16).ToUpper()}   DH = {Convert.ToString(rejestry[7], 16).ToUpper()}\n";
        }
    }
}
