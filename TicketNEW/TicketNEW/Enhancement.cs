using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNEW
{
    public class Enhancement : Ticket
    {
        //Enhancement specific properties:
        //Software, Cost, Reason, Estimate

        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public DateTime estimate { get; set; }


        public Enhancement(int ticketID, string summary, string status, string priority, string submitter, string assinged, string watching,double cost,string reason,DateTime estimate)
        {
            this.ticketID = ticketID;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assinged = assinged;
            this.watching = watching;

            this.cost = cost;
            this.reason = reason;
            this.estimate = estimate;
        }

        public override string Format()
        {
            return ticketID.ToString() + "," + summary + "," + status + "," + priority + "," + submitter + "," + assinged + "," + watching+","
                +cost.ToString("c")+","+reason+","+estimate.ToString("M/d/yyyy");
        }


    }
}
