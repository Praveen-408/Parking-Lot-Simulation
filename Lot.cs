using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Lot 
    {

        List<Slot> Slot_List;

        List<Ticket> Ticket_List;

        public Lot()
        {
            this.Ticket_List = new List<Ticket>();
            this.Slot_List = new List<Slot>();
        }

        public void Lot_Initialisation(int No_Of_Slots_Two_Wheelers, int No_Of_Slots_Four_Wheelers,int No_Of_Slots_Heavy_Vehicles)
        {
            int Loop_Variable, Slot_Id = 1;

            for (Loop_Variable = 1; Loop_Variable <= No_Of_Slots_Two_Wheelers; Loop_Variable++, Slot_Id++)
            {
                Slot_List.Add(new Slot((int)VehicleModel.Vehicle_Model.Two_Wheeler, Slot_Id, true));
            }
            for (Loop_Variable = 1; Loop_Variable <= No_Of_Slots_Four_Wheelers; Loop_Variable++, Slot_Id++)
            {
                Slot_List.Add(new Slot((int)VehicleModel.Vehicle_Model.Four_Wheeler, Slot_Id, true));
            }
            for (Loop_Variable = 1; Loop_Variable <= No_Of_Slots_Heavy_Vehicles; Loop_Variable++, Slot_Id++)
            {
                Slot_List.Add(new Slot((int)VehicleModel.Vehicle_Model.Heavy_Vehicle, Slot_Id, true));
            }
        }

        public List<Slot> Get_Lot()
        {
            return Slot_List;
        }

        public string Get_Vehicle_In_Slot(int Slot_Id)
        {
            foreach (Ticket Single_Ticket in Ticket_List)
            {
                if (Single_Ticket.Assigned_Slot == Slot_Id && Single_Ticket.Out_Time=="\0")
                    return Single_Ticket.Vehicle_No;
            }
            return "\0";
        }

        public bool Check_Slot_Availability(int Vehicle_Type)
        {
            foreach (Slot Single_Slot in Slot_List)
            {
                if (Single_Slot.Return_Slot_Type()== Vehicle_Type && Single_Slot.Check_Slot_Availability() == true)
                        return true;
            }
            return false;
        }
  
        public int Park_Vehicle(int Parking_Vehicle_Type, string Vehicle_Number)
        {
            int Assigned_Slot_Number = -1;
            int Ticket_Id;
            foreach (Slot Single_Slot in Slot_List)
            {
                if (Single_Slot.Return_Slot_Type() == Parking_Vehicle_Type && Single_Slot.Check_Slot_Availability() == true)
                {
                    Assigned_Slot_Number = Single_Slot.Park_Vehicle();
                    break;
                }
            }
            DateTime Present_Time = DateTime.Now;
            Random Random_value = new Random();
            Ticket_Id = Random_value.Next(1000, 9999);
            string InTime = Present_Time.ToString();
            Ticket_List.Add(new Ticket(Ticket_Id,InTime,"\0",Assigned_Slot_Number, Vehicle_Number, Parking_Vehicle_Type));
            return Ticket_Id;
        }

        public Ticket Unpark_Vehicle(string Vehicle_Number, int Ticket_Id)
        {
            foreach (Ticket Search_Ticket in Ticket_List)
            {
                if (Search_Ticket.Ticket_No == Ticket_Id && Search_Ticket.Vehicle_No == Vehicle_Number)
                {
                    foreach (Slot Single_Slot in Slot_List)
                    {
                        Single_Slot.UnPark_Vehicle(Search_Ticket.Assigned_Slot);
                    }
                    Set_OutTime_For_Ticket(Search_Ticket);
                    return Search_Ticket;
                }
            }
            return null;
        }
         
        public void Set_OutTime_For_Ticket(Ticket Search_Ticket)
        {
            DateTime Present_Time = DateTime.Now;
            string OutTime = Present_Time.ToString();
            Search_Ticket.Out_Time_Set(OutTime);
        }

    }
}
