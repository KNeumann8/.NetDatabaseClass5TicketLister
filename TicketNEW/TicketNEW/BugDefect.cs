using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{
    class BugDefect : Ticket
    {
        //Severity is a Bug/Defect specific property:
        
        public string severity { get; set; }


        public BugDefect(int ticketID, string summary, string status, string priority, string submitter, string assinged, string watching,string severity)
        {
            this.ticketID = ticketID;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assinged = assinged;
            this.watching = watching;

            this.severity = severity;
        }

        public override string Format()
        {
            return ticketID.ToString() + "," + summary + "," + status + "," + priority + "," + submitter + "," + assinged + "," + watching+","
                +severity;
        }

    }
}
