using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{
    class Program
    {

        //nlog coming in
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {


            //step 1 read from file
            logger.Info("Program started");

            ArrayList TicketArray = new ArrayList();
            int ticketCounter = -1;

            string file = "Tickets.csv";
            if (!File.Exists(file))
            {
                StreamWriter swTemp = new StreamWriter(file);
                swTemp.WriteLine("TicketID,Summary,Status,Priority,Submitted,Assigned,Watching");
                swTemp.Close();
            }
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');

                if (ticketCounter >= 0)
                {
                    Ticket tempTicket = new Ticket(int.Parse(arr[0]), arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                    TicketArray.Add(tempTicket);
                }

                ticketCounter++;
            }
            sr.Close();
            logger.Info("Program completed reading phase.");
            logger.Info("Found " + ticketCounter + " tickets");
            //step 2 ask user to input information
            string[] usersTicket = new string[7];

            Console.WriteLine("Your ticket number is {0}", ticketCounter + 1);
            usersTicket[0] = (ticketCounter + 1).ToString();

            Console.WriteLine("What is the ticket summary?");
            string input = Console.ReadLine();
            usersTicket[1] = input;

            Console.WriteLine("What is the ticket status?");
            input = Console.ReadLine();
            usersTicket[2] = input;

            Console.WriteLine("What is the ticket priority?");
            input = Console.ReadLine();
            usersTicket[3] = input;

            Console.WriteLine("Who is the ticket submitter?");
            input = Console.ReadLine();
            usersTicket[4] = input;

            Console.WriteLine("Who is the ticket assinged to?");
            input = Console.ReadLine();
            usersTicket[5] = input;



            bool whosWatchin = true; //this is the value to keep the watching list going
            string watchers = "";
            Console.WriteLine("Is anyone watching the ticket? Y/N");
            input = Console.ReadLine().ToUpper();
            if (input == "N") whosWatchin = false;
            while (whosWatchin)
            {
                whosWatchin = false;
                Console.WriteLine("Who is watching?");
                watchers += Console.ReadLine();
                Console.WriteLine("Is anyone else watching? Y/N");
                input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    whosWatchin = true;
                    watchers += "|";
                }
            }
            usersTicket[6] = watchers;


            //--------------------------------------------ticketID------summary--------status--------priority-------submitter------assinged-------watching
            Ticket customTicket = new Ticket(int.Parse(usersTicket[0]), usersTicket[1], usersTicket[2], usersTicket[3], usersTicket[4], usersTicket[5], usersTicket[6]);
            TicketArray.Add(customTicket);
            logger.Info("Created ticket: " + customTicket.formatOut());


            //step 3 output changes to file

            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("TicketID,Summary,Status,Priority,Submitted,Assigned,Watching");
            foreach (Ticket t in TicketArray)
            {
                sw.WriteLine(t.formatOut());
            }
            sw.Close();
            Console.ReadKey();
            logger.Info("Program ended");
        }
    }
}
