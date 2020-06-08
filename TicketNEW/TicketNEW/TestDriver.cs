using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{
    class TestDriver
    {
        
        public static void Main()
        {
            TaskList taskList = new TaskList("Task.csv");
            BugDefectList bugList = new BugDefectList("Tickets.csv");
            EnhancementList enhancementList = new EnhancementList("Enhancements.csv");

            Console.WriteLine("1) Add Bug or Defect Ticket");
            Console.WriteLine("2) Add Task Ticket");
            Console.WriteLine("3) Add Enhancement Ticket");
            Console.WriteLine("Any key to stop");
            String input = Console.ReadLine();
            int menuChoice = 0;
            try
            {
                menuChoice = int.Parse(input);
            }
            catch { }


            switch (menuChoice)
            {
                case 1:
                    bugList.createBugDefect();
                    break;
                case 2:
                    taskList.createTask();
                    break;
                case 3:
                    enhancementList.createEnhancement();
                    break;
            }

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }

    }
}
