using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Ticket : Vehicle
    {
        public int Ticket_No { private set; get; }
        public string In_Time { private set; get; }
        public string Out_Time { private set; get; }
        public int Assigned_Slot { private set; get; }

        public Ticket(int Ticket_No, string In_Time, string Out_Time, int Assigned_Slot,string Vehicle_Number,int Parking_Vehicle_Type) : base(Vehicle_Number,Parking_Vehicle_Type)
        {
            this.Ticket_No = Ticket_No;
            this.In_Time = In_Time;
            this.Out_Time = Out_Time;
            this.Assigned_Slot = Assigned_Slot;
        }

        public void Out_Time_Set(string Out_Time)
        {
            this.Out_Time = Out_Time;
        }

    }
}
