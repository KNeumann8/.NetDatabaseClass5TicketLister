using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{
    public abstract class Ticket
    {
        //Default Ticket Properties:
        //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching

        public int ticketID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assinged { get; set; }
        public string watching { get; set; } //do I want this as a list... hmmmm


        public virtual string Format()
        {
            return ticketID.ToString() + "," + summary + "," + status + "," + priority + "," + submitter + "," + assinged + "," + watching;
        }


    }
}
