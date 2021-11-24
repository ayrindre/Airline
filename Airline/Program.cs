using System;
using System.Collections.Generic;

namespace Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            Airline airline1 = new Airline();
            airline1.Menu();
        }
    }
    public abstract class rules
    {
        public abstract void Menu();
        public abstract void AirplaneInformation();
        public abstract void BuyTicket();
        public abstract bool RefundTicket(int id);
        public abstract void print(int id, string n, string code, string D, DateTime Date);
        public abstract void print();

    }
    public class Passenger
    {
        public int idticket;
        private string namepassenger;
        public string NamePassenger { get { return namepassenger; } set { namepassenger = value; } }
        private string codemeli;
        public string CodeMeli { get { return codemeli; } set { codemeli = value; } }
        public string OriginPassenger;
        public string DestinationPassenger;
        public DateTime DateBuy;

    }
    public class Airline : rules
    {
        public string NameAirplane;
        public string Origin;
        public string Destination;
        public int Capacity;
        public static int capacitypassenger = 0;
        public static int id = 0;

        public static List<Airline> listAirline = new List<Airline>();
        public static List<Passenger> listpassenger = new List<Passenger>();


        public override void Menu()
        {
            string select;
            string y;
            const string UNDERLINE = "\x1B[4m";
            const string RESET = "\x1B[0m";
            do
            {
                System.Console.WriteLine($"          | {UNDERLINE}Airplane{RESET} Information |             | {UNDERLINE}Buy{RESET} Tickets |              | {UNDERLINE}Remove{RESET} Tickets |              | {UNDERLINE}Show{RESET} All Tickets |        \n");
                System.Console.Write("Enter : ");
                select = Console.ReadLine().ToLower();
                System.Console.WriteLine();
                switch (select)
                {
                    case "airplane":
                        AirplaneInformation();
                        break;
                    case "remove":
                        System.Console.Write("\nEnter Your Id Ticket For Remove : ");
                        int id = int.Parse(Console.ReadLine());
                        RefundTicket(id);
                        break;
                    case "buy":
                        BuyTicket();
                        break;
                    case "show":
                        print();
                        break;
                    default:
                        System.Console.WriteLine("-------------- not availble -----------");
                        break;
                }
                System.Console.WriteLine();
                System.Console.Write("Do you have request? ( Y - N ) :  ");
                y = Console.ReadLine().ToLower();
                System.Console.WriteLine();
            } while (y == "y");
        }

        public override void BuyTicket()
        {

            string c;
            bool c1 = false;
            do
            {
                Passenger a = new Passenger();
                System.Console.Write("Enter Name passenger : ");
                a.NamePassenger = Console.ReadLine();
                System.Console.Write("Enter Code Melli Passenger (10 DIGIT): ");
                a.CodeMeli = Console.ReadLine();
                System.Console.Write("Enter starting city: ");
                a.OriginPassenger = Console.ReadLine();
                System.Console.Write("Enter Destination city: ");
                a.DestinationPassenger = Console.ReadLine();
                a.DateBuy = DateTime.Now;
                System.Console.WriteLine($"Ticket registration date : {a.DateBuy.ToString()}");
                foreach (var item in listAirline)
                {
                    if (a.OriginPassenger == item.Origin && a.DestinationPassenger == item.Destination)
                    {
                        capacitypassenger ++;
                    }
                }

                foreach (var item in listAirline)
                {
                    if (item.Capacity >= capacitypassenger && a.OriginPassenger == item.Origin && a.DestinationPassenger == item.Destination)
                    {
                        id++;
                        a.idticket = id;
                        listpassenger.Add(a);
                        c1 = true;
                    }
                }
                if (c1 == true)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("---------------------- Buy Tickets anjam shod  ----------------------------");
                    System.Console.WriteLine();
                    print(a.idticket, a.NamePassenger, a.CodeMeli, a.DestinationPassenger, a.DateBuy);
                }
                else if (c1==false)
                {
                    System.Console.WriteLine("---------------------- Zarfiat Full Ast ----------------------------");
                    id--;
                    capacitypassenger--;
                }
                System.Console.WriteLine();
                System.Console.Write("Do you want a ticket again ? ( Y - N ) : ");
                c = Console.ReadLine().ToLower();
                System.Console.WriteLine();

            } while (c == "y");

        }

        public override bool RefundTicket(int id)
        {
            foreach (var item in listpassenger)
            {
                var moghayese = DateTime.Now.Minute - item.DateBuy.Minute;
                if (id == item.idticket)
                {
                    if (moghayese <= 1)
                    {
                        listpassenger.Remove(item);
                        System.Console.WriteLine("-------------------Ba Movafaghiat Remove Shod ------------------");
                        return true;
                    }

                }
            }
            return false;
            System.Console.WriteLine("---------------- Sorry 1 minute gozashte ---------------- ");
        }

        public override void AirplaneInformation()
        {
            string check;
            do
            {
                Airline b = new Airline();
                System.Console.Write("\nEnter Name Airplane : ");
                b.NameAirplane = Console.ReadLine();
                System.Console.Write("Enter starting city: ");
                b.Origin = Console.ReadLine();
                System.Console.Write("Enter Destination city: ");
                b.Destination = Console.ReadLine();
                System.Console.Write("Enter Capacity Airplane : ");
                b.Capacity = int.Parse(Console.ReadLine());
                listAirline.Add(b);

                System.Console.WriteLine();
                System.Console.WriteLine("____________________________");
                System.Console.Write("Do you add? ( Y - N )  : ");
                check = Console.ReadLine().ToLower();
                System.Console.WriteLine("____________________________");
                System.Console.WriteLine();


            } while (check == "y");
            System.Console.WriteLine("------------------------------------------------------------------------");
        }

        public override void print(int id, string n, string code, string D, DateTime Date)
        {
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("          ==================== Get Your Tickets ===================");
            System.Console.WriteLine($"                Ticke Id : {id}");
            System.Console.WriteLine($"                Name : {n}    {code}");
            System.Console.WriteLine($"                Destination : {D}");
            System.Console.WriteLine($"                Date Buy : {Date}");
            System.Console.WriteLine("          =========================================================");
            Console.ResetColor();
            System.Console.WriteLine();
        }

        public override void print()
        {
            foreach (var item in listpassenger)
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"          ===================== Tickets {item.idticket} ==================");
                System.Console.WriteLine();
                System.Console.WriteLine($"                Ticke Id : {item.idticket}");
                System.Console.WriteLine($"                Name : {item.NamePassenger}    {item.CodeMeli}");
                System.Console.WriteLine($"                Starting city : {item.OriginPassenger}\n                Destination city : {item.DestinationPassenger}");
                System.Console.WriteLine($"                Date Buy : {item.DateBuy}");
                System.Console.WriteLine();
                System.Console.WriteLine("          ======================================================");
                Console.ResetColor();
                System.Console.WriteLine();
            }
        }
    }
}
