using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice_Class4
{
    public enum Priority
    {
        Critical,
        HighImportance,
        NonCritical
    }

    class Ticket
    {
        //STEP 1. Declare properties
        public string ClientName { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool Resolved { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateResolved { get; set; }

        //STEP 2. Constructor
        public Ticket(string clientName, string description, Priority priority)
        {
            //set our properties
            this.ClientName = clientName;
            this.Description = description;
            this.Priority = priority;
            this.Resolved = false;
            this.DateEntered = DateTime.Now;
        }

        //Step 3. Methods and Functions
        public void ResolveTicket()
        {
            this.Resolved = true;
            this.DateResolved = DateTime.Now;
        }

        public string GetTicketInfo()
        {
            return this.ClientName + " - " + this.Description 
                + " - " + this.Priority + "\nResolved: " 
                + this.Resolved;
        }
    }
}
