using System;
using System.Linq;
namespace Procesor__Biblioteka
{
    public class Intel8086
    {
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
        public string ToString(bool a)
        {
            return ToHex(Value,true);
        }
        public static string ToHex(int Value)
        {
            return ((byte)Value).ToString("x2").ToUpper();
        }
        public static string ToHex(int Value,bool a)
        {
            return (Value).ToString("x4").ToUpper();
        }
    }
    public class Memory
    {
        public int Address { get; set; }
        public int MemValue { get; set; }

        public Memory(int a, int v)
        {
            this.Address = a;
            this.MemValue = v;
        }
        public override string ToString()
        {
            return ToHex(MemValue);
        }
        public string ToString(bool a)
        {
            return ToHex(MemValue, true);
        }
        public static string ToHex(int Value)
        {
            return ((byte)Value).ToString("x2").ToUpper();
        }
        public static string ToHex(int Value, bool a)
        {
            return (Value).ToString("x4").ToUpper();
        }
    }
    /*-------------------Przypisanie rejestrów do klasy Rejest------------------*/
    public class Procesor
    {
        public Rejest[] rejestr;
        public Memory[] mem;
        public Procesor() { }
        public Procesor(string[] insert){
            rejestr = new Rejest[12];
            rejestr[0] = new Rejest("AL", Intel8086.IsHex(insert[0]));
            rejestr[1] = new Rejest("AH", Intel8086.IsHex(insert[1]));
            rejestr[2] = new Rejest("BL", Intel8086.IsHex(insert[2]));
            rejestr[3] = new Rejest("BH", Intel8086.IsHex(insert[3]));
            rejestr[4] = new Rejest("CL", Intel8086.IsHex(insert[4]));
            rejestr[5] = new Rejest("CH", Intel8086.IsHex(insert[5]));
            rejestr[6] = new Rejest("DL", Intel8086.IsHex(insert[6]));
            rejestr[7] = new Rejest("DH", Intel8086.IsHex(insert[7]));
            rejestr[8] = new Rejest("SI", Intel8086.IsHex(insert[8]));
            rejestr[9] = new Rejest("DI", Intel8086.IsHex(insert[9]));
            rejestr[10] = new Rejest("BP", Intel8086.IsHex(insert[10]));
            rejestr[11] = new Rejest("BX", Intel8086.IsHex(insert[11]));
            mem = new Memory[65536];
            for (int i = 0; i < mem.Length; i++)
            {
                mem[i] = new Memory(MemrandomRejestr("4"),MemrandomRejestr());
            }
            
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
                case "SI": return 8;
                case "DI": return 9;
                case "BP": return 10;
                case "BX": return 11;
                default: return -1;
            }
        }
        /*-------------------Losowanie Rejestrów------------------*/
        public string randomRejestr()
        {
            Random losuj = new Random();
            return Rejest.ToHex(losuj.Next(0, 256));
        }
        public string randomRejestr(string a)
        {
            Random losuj = new Random();
            return Rejest.ToHex(losuj.Next(0, 65536), true);
        }
        public int MemrandomRejestr()
        {
            Random losuj = new Random();
            return losuj.Next(0, 256);
        }
        public int MemrandomRejestr(string a)
        {
            Random losuj = new Random();
            return losuj.Next(0, 65536);
        }
        /*-------------------Wybór rozkazu------------------*/
        public bool WhatToDoExtanded(string Prio,string program, string rej1, string rej2, string adresvalue, bool strona, string SD, string BP)
        {
            switch (Prio)
            {
                case "Działaj na rejestrach":
                    WhatToDo(program,rej1,rej2);
                    break;
                case "Adresowanie bezpośrednie rejestr do pamięci":
                    WhatToDoMemory(program, rej1, adresvalue, strona);
                    break;
                case "Adresowanie bezpośrednie pamięć do rejestru":
                    WhatToDoMemory(program, rej1, adresvalue, strona);
                    break;
                case "Adresowanie indeksowe rejestr do pamięci":
                    WhatToDoMemory(program, rej1, Locate(adresvalue, SD, BP, Prio), strona);
                    break;
                case "Adresowanie indeksowe pamięć do rejestru":
                    WhatToDoMemory(program, rej1, Locate(adresvalue, SD, BP, Prio), strona);
                    break;
                case "Adresowanie bazowe rejestr do pamięci":
                    WhatToDoMemory(program, rej1, Locate(adresvalue, SD, BP, Prio), strona);
                    break;
                case "Adresowanie bazowe pamięć do rejestru":
                    WhatToDoMemory(program, rej1, Locate(adresvalue, SD, BP, Prio), strona);
                    break;
                case "Adresowanie Indeksowo-bazowe rejestr do pamięci":
                    WhatToDoMemory(program, rej1, Locate(adresvalue, SD, BP, Prio), strona);
                    break;
                case "Adresowanie Indeksowo-bazowe pamięć do rejestru":
                    WhatToDoMemory(program, rej1, Locate(adresvalue, SD, BP, Prio), strona);
                    break;
                default:
                    throw new Exception();
            }
            return true;
        }
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
        public bool WhatToDoMemory(string program, string rej1, string memory, bool strona)
        {
            switch (program)
            {
                case "MOV":
                    MovMem(rej1, memory, strona);
                    break;
                case "XCHG":
                    XCHGMem(rej1, memory);
                    break;
                case "INC":
                    IncMem(memory);
                    break;
                case "DEC":
                    DecMem(memory);
                    break;
                case "NOT":
                    NotMem(memory);
                    break;
                case "NEG":
                    NotMem(memory);
                    IncMem(memory);
                    break;
                case "AND":
                    AndMem(rej1, memory, strona);
                    break;
                case "OR":
                    OrMem(rej1, memory, strona);
                    break;
                case "XOR":
                    XorMem(rej1, memory, strona);
                    break;
                case "ADD":
                    AddMem(rej1, memory, strona);
                    break;
                case "SUB":
                    SubMem(rej1, memory, strona);
                    break;
                default:
                    throw new Exception();
            }
            return true;
        }
        /*------------------------------Operacja lokalizacji--------------------------------*/
        public string Locate(string adresvalue, string SD, string BP, string Prio)
        {
            if (Prio == "Adresowanie indeksowe rejestr do pamięci" || Prio == "Adresowanie indeksowe pamięć do rejestru") 
            {
                int adres = (Convert.ToInt32(adresvalue, 16)) + (rejestr[FindFromRejest(SD)].Value);
                return adres.ToString("X");
            }
            if (Prio == "Adresowanie bazowe rejestr do pamięci" || Prio == "Adresowanie bazowe pamięć do rejestru")
            {
                int adres = (Convert.ToInt32(adresvalue, 16)) + (rejestr[FindFromRejest(BP)].Value);
                return adres.ToString("X");
            }
            if (Prio == "Adresowanie Indeksowo-bazowe rejestr do pamięci" || Prio == "Adresowanie Indeksowo-bazowe pamięć do rejestru")
            {
                int adres = (Convert.ToInt32(adresvalue, 16)) + (rejestr[FindFromRejest(SD)].Value) + (rejestr[FindFromRejest(BP)].Value);
                return adres.ToString("X");
            }
            return adresvalue;
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

        /*------------------------------Operacje dwu elementowe na pamięci----------------------------------------*/
        public void MovMem(string rej1, string rej2, bool strona)
        {
            if(strona == true)
                rejestr[FindFromRejest(rej1)].Value = mem[Convert.ToInt32(rej2, 16)].MemValue;
            else
                 mem[Convert.ToInt32(rej2, 16)].MemValue = rejestr[FindFromRejest(rej1)].Value;
        }

        public void XCHGMem(string rej1, string rej2)
        {
            var tmp = rejestr[FindFromRejest(rej1)].Value;
            rejestr[FindFromRejest(rej1)].Value = mem[Convert.ToInt32(rej2, 16)].MemValue;
            mem[Convert.ToInt32(rej2, 16)].MemValue = tmp;
        }
        public void AddMem(string rej1, string rej2, bool strona)
        {
            if (strona == true)
                rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value + (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
            else
                mem[Convert.ToInt32(rej2, 16)].MemValue = (byte)rejestr[FindFromRejest(rej1)].Value + (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
        }
        public void SubMem(string rej1, string rej2, bool strona)
        {
            if (strona == true)
                rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value - (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
            else
                mem[Convert.ToInt32(rej2, 16)].MemValue = (byte)rejestr[FindFromRejest(rej1)].Value - (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;

        }
        public void AndMem(string rej1, string rej2, bool strona)
        {
            if (strona == true)
                rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value & (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
            else
                mem[Convert.ToInt32(rej2, 16)].MemValue = (byte)rejestr[FindFromRejest(rej1)].Value & (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
        }
        public void OrMem(string rej1, string rej2, bool strona)
        {
            if (strona == true)
                rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value | (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
            else
                mem[Convert.ToInt32(rej2, 16)].MemValue = (byte)rejestr[FindFromRejest(rej1)].Value | (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
        }
        public void XorMem(string rej1, string rej2, bool strona)
        {
            if (strona == true)
                rejestr[FindFromRejest(rej1)].Value = (byte)rejestr[FindFromRejest(rej1)].Value ^ (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
            else
                mem[Convert.ToInt32(rej2, 16)].MemValue = (byte)rejestr[FindFromRejest(rej1)].Value ^ (byte)mem[Convert.ToInt32(rej2, 16)].MemValue;
        }
        /*------------------------------Operacje jedno elementowe----------------------------------------*/
        public void IncMem(string rej1)
        {
            mem[Convert.ToInt32(rej1, 16)].MemValue++;
        }

        public void DecMem(string rej1)
        {
            mem[Convert.ToInt32(rej1, 16)].MemValue--;
        }

        public void NotMem(string rej1)
        {
            mem[Convert.ToInt32(rej1, 16)].MemValue = ~((byte)(mem[Convert.ToInt32(rej1, 16)].MemValue));
        }
    }
}


