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
    /*-------------------Przechowywanie rejestrów------------------*/
    public class Rejest
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Rejest(string n, int v)
        {
            this.Name = n;
            this.Value = v;
        }
        public override string ToString()
        {
            return ToHex(Value);
        }
        public static string ToHex(int Value)
        {
            return ((byte)Value).ToString("x2").ToUpper();
        }
    }
    /*-------------------Przypisanie rejestrów do klasy Rejest------------------*/
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
        }
        /*----------------------------------------------------------------*/
        public int FindFromRejest(string rejestrName)
        {
            switch (rejestrName)
            {
                case "AH": return 0;
                case "AL": return 1;
                case "BH": return 2;
                case "BL": return 3;
                case "CH": return 4;
                case "CL": return 5;
                case "DH": return 6;
                case "DL": return 7;
                default: return -1;
            }
        }
        /*-------------------Losowanie Rejestrów------------------*/
        public string randomRejestr()
        {
            Random losuj = new Random();
            return Rejest.ToHex(losuj.Next(0, 256));
        }
        /*-------------------Wybór rozkazu------------------*/
        public bool WhatToDo(string program, string rej1, string rej2)
        {
            switch(program)
            {
                case "MOV":
                       Mov(rej1, rej2);
                    break;
                case "XCHG":
                        XCHG(rej1, rej2);
                    break;
                case "INC":
                    Inc(rej1);
                    break;
                case "DEC":
                    Dec(rej1);
                    break;
                case "NOT":
                    Not(rej1);
                    break;
                case "NEG":
                    Not(rej1);
                    Inc(rej1);
                    break;
                case "AND":
                    And(rej1, rej2);
                    break;
                case "OR":
                    Or(rej1, rej2);
                    break;
                case "XOR":
                    Xor(rej1, rej2);
                    break;
                case "ADD":
                    Add(rej1, rej2);
                    break;
                case "SUB":
                    Sub(rej1, rej2);
                    break;
                default:
                    throw new Exception();
            }
            return true;
        }

        /*------------------------------Operacje dwu elementowe----------------------------------------*/
        public void Mov(string rej1, string rej2)
        { 
            rejestr[FindFromRejest(rej1)].Value = rejestr[FindFromRejest(rej2)].Value;
        }

        public void XCHG(string rej1, string rej2)
        {
            var tmp = rejestr[FindFromRejest(rej1)].Value;
            rejestr[FindFromRejest(rej1)].Value = rejestr[FindFromRejest(rej2)].Value;
            rejestr[FindFromRejest(rej2)].Value = tmp;
        }
        public void Add(string rej1, string rej2)
        {
            rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value + (byte)rejestr[FindFromRejest(rej2)].Value;
        }
        public void Sub(string rej1, string rej2)
        {
            rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value - (byte)rejestr[FindFromRejest(rej2)].Value;
        }
        public void And(string rej1, string rej2)
        {
            rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value & (byte)rejestr[FindFromRejest(rej2)].Value;
        }
        public void Or(string rej1, string rej2)
        {
            rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value | (byte)rejestr[FindFromRejest(rej2)].Value;
        }
        public void Xor(string rej1, string rej2)
        {
            rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value ^ (byte)rejestr[FindFromRejest(rej2)].Value;
        }
        /*------------------------------Operacje jedno elementowe----------------------------------------*/
        public void Inc(string rej1)
        {
            rejestr[FindFromRejest(rej1)].Value++;
        }

        public void Dec(string rej1)
        {
            rejestr[FindFromRejest(rej1)].Value--;
        }

        public void Not(string rej1)
        {          
            rejestr[FindFromRejest(rej1)].Value = ~((byte)(rejestr[FindFromRejest(rej1)].Value));
        }
    }
}
