using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{

    class EnhancementList
    {
        private List<Enhancement> Enhancements;
        private int ticketCounter;
        private string fileLocation;


        //nlog coming in
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public EnhancementList(String file)
        {
            //step 1 read from file
            logger.Info("Program started");

            Enhancements = new List<Enhancement>();
            ticketCounter = -1;

            this.fileLocation = file;
            if (!File.Exists(file))
            {
                StreamWriter swTemp = new StreamWriter(file);
                swTemp.WriteLine("TicketID,Summary,Status,Priority,Submitted,Assigned,Watching,Cost,Reason,Estimate");
                swTemp.Close();
            }
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');

                if (ticketCounter >= 0)
                {
                    Enhancement tempTicket = new Enhancement(int.Parse(arr[0]), arr[1], arr[2], arr[3], arr[4], arr[5], arr[6],double.Parse(arr[7], System.Globalization.NumberStyles.Currency), arr[8] ,DateTime.Parse(arr[9]));
                    Enhancements.Add(tempTicket);
                }

                ticketCounter++;
            }
            sr.Close();
            logger.Info("Program completed reading phase.");
            logger.Info("Found " + ticketCounter + " enhancements");
        }

        public void createEnhancement()
        {
            //step 2 ask user to input information
            string[] usersTicket = new string[10]; //change for each specific ticket type

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

            //Enhancement specifics:
            double userCost = 0;
            bool costLoop;
            do
            {
                costLoop = false;

                Console.WriteLine("What is the cost?");
                Console.WriteLine("Write as American currency");
                input = Console.ReadLine();
                try
                {
                    userCost = double.Parse(input, System.Globalization.NumberStyles.Currency);
                }
                catch
                {
                    logger.Error("Input conversion failed.");
                    logger.Info("Did you use the correct format?");
                    costLoop = true;
                }
            } while (costLoop);
            


            Console.WriteLine("What is the reason for the enhancement?");
            input = Console.ReadLine();
            usersTicket[7] = input;


            DateTime usersDate;
            usersDate = DateTime.Now;

            bool dateLoop;
            do
            {
                dateLoop = false;

                Console.WriteLine("What is the estimated day of completion?");
                Console.WriteLine("(M/d/yyyy)");
                input = Console.ReadLine();
                try
                {
                    usersDate = DateTime.Parse(input);
                }
                catch
                {
                    logger.Error("Input conversion failed.");
                    logger.Info("Did you use the correct format?");
                    dateLoop = true;
                }
            } while (dateLoop);



            //--------------------------------------------ticketID------summary--------status--------priority-------submitter------assinged-------watching
            Enhancement customTicket = new Enhancement(int.Parse(usersTicket[0]), usersTicket[1], usersTicket[2], usersTicket[3], usersTicket[4], usersTicket[5], usersTicket[6], userCost,usersTicket[7], usersDate);
            Enhancements.Add(customTicket);
            logger.Info("Created ticket: " + customTicket.Format());


            //step 3 output changes to file

            StreamWriter sw = new StreamWriter(fileLocation);
            sw.WriteLine("TicketID,Summary,Status,Priority,Submitted,Assigned,Watching,Cost,Reason,Estimate");
            foreach (Enhancement t in Enhancements)
            {
                sw.WriteLine(t.Format());
            }
            sw.Close();
            Console.ReadKey();
            logger.Info("Program ended");
        }

    }
}
