using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Slot 
    {
        public int Slot_Type { private set; get; }
        public int Slot_No { private set; get; }
        public bool Slot_Availability { private set; get; }

        public Slot(int Slot_Type, int Slot_No, bool Slot_Availability)
        {
            this.Slot_Type = Slot_Type;
            this.Slot_No = Slot_No;
            this.Slot_Availability = Slot_Availability;
        }


        public bool Check_Slot_Availability()
        {
            return this.Slot_Availability;
        }

        public int Return_Slot_Type()
        {
            return this.Slot_Type;
        }

        public int Park_Vehicle()
        {
            this.Slot_Availability = false;
            return this.Slot_No;
        }

        public void UnPark_Vehicle(int Slot_No)
        {
            if (this.Slot_No == Slot_No)
            {
                this.Slot_Availability = true;
            }
        }
        
    }
}
