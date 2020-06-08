using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{
    public class Task : Ticket
    {
        //Task specific properties
        //ProjectName, DueDate

        public string projectName { get; set; }
        public DateTime dueDate { get; set; }


        public Task(int ticketID,string summary,string status,string priority, string submitter, string assinged, string watching,string projectName,DateTime dueDate)
        {
            this.ticketID = ticketID;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assinged = assinged;
            this.watching = watching;

            this.projectName = projectName;
            this.dueDate = dueDate;
        }

        public override string Format()
        {
            return ticketID.ToString() + "," + summary + "," + status + "," + priority + "," + submitter + "," + assinged + "," + watching+","
                +projectName+","+dueDate.ToString("M/d/yyyy");
        }

    }
}
