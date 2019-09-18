using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class ViewClass  
    {
        Lot Lot_Object = new Lot();

        public void LotReading()
        {
            Console.Clear();
            int No_Of_Slots_Two_Wheelers=0,No_Of_Slots_Four_Wheelers=0,No_Of_Slots_Heavy_Vehicles=0;
            Console.WriteLine("**********WELOCOME TO PARKING LOT SYSTEM***********\n\n");
            Console.Write("Enter The Number Of Slots To Be Assigned For 2 Wheelers :  ");
            try
            {
                No_Of_Slots_Two_Wheelers = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Entered Input is not an Integer.....Press any key to Enter Again");
                Console.ReadKey();
                LotReading();
                return;
            }
            Console.Write("\nEnter The Number Of Slots To Be Assigned For 4 Wheelers :  ");
            try
            {
                No_Of_Slots_Four_Wheelers = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered Input is not an Integer.....Press any key to Enter Again");
                Console.ReadKey();
                LotReading();
                return;
            }
            Console.Write("\nEnter The Number Of Slots To Be Assigned For Heavy Vehicles :  ");
            try
            {
                No_Of_Slots_Heavy_Vehicles = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered Input is not an Integer.....Press any key to Enter Again");
                Console.ReadKey();
                LotReading();
                return;
            }
            Console.WriteLine("\nSuccessfully Initialised the Slots....Press Any Key to move to next Step\n");
            Console.ReadKey();
            Lot_Object.Lot_Initialisation(No_Of_Slots_Two_Wheelers, No_Of_Slots_Four_Wheelers, No_Of_Slots_Heavy_Vehicles);
        }

        public void MainMenu()
        {
            Console.Clear();
            int Option_Choice=0;
            Console.WriteLine("----------MENU-----------\n");
            Console.WriteLine("1.Show Parking Lot Occupancy Details");
            Console.WriteLine("2.Park Vehicle");
            Console.WriteLine("3.Unpark Vehicle");
            Console.WriteLine("4.Exit");
            Console.Write("Enter a Valid Choice:    ");
            try
            {
                Option_Choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered Input is not an Integer.....Press any key to Enter Again");
                Console.ReadKey();
                MainMenu();
                return;
            }
            switch (Option_Choice)
            {
                case 1:
                    Console.Clear();
                    Lot_Display();
                    break;
                case 2:
                    Park_Vehicle();
                    break;
                case 3:
                    Console.Clear();
                    Unpark_Vehicle();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("\nWrong Choice.......Press Any Key To Go Again");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }

        public void Lot_Display()
        {            
            Console.WriteLine("Available Slots Are.......... \n");

            foreach (Slot Single_Slot in Lot_Object.Get_Lot())
            {
                Console.Write("Slot No :  " + Single_Slot.Slot_No + "    Slot Type :   " +(VehicleModel.Vehicle_Model)Single_Slot.Slot_Type+"      ");
                if (Single_Slot.Slot_Availability == false)
                {
                    string Vehicle_Id = Lot_Object.Get_Vehicle_In_Slot(Single_Slot.Slot_No);
                    Console.WriteLine("Vehicle Parked is :  " + Vehicle_Id);
                }
                else
                    Console.WriteLine("No Vehicle Is Parked");
            }
            Console.WriteLine("\n\n Press Any Key To Go Back To MainMenu");
            Console.ReadLine();
            Console.Clear();
            MainMenu();
        }

        public void Park_Vehicle()
        {
            Console.Clear();
            int Park_Vehicle_type = 0;
            bool Slot_Availability_Check;
            int Ticket_Id_Issued;
            string Vehicle_Number;
            Console.WriteLine("Enter The Vehicle Type to be Parked :   ");
            Console.WriteLine("1.Two Wheeler");
            Console.WriteLine("2.Four Wheeler");
            Console.WriteLine("3.Heavy Vehicle");
            try
            {
                Park_Vehicle_type = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entered Input is not an Integer.....Press any key to Enter Again");
                Console.ReadKey();
                Park_Vehicle();
                return;
            }
            if (Park_Vehicle_type < 1 || Park_Vehicle_type > 3)
            {
                Console.WriteLine("Entered Input is Wrong.....Press any Key to Go again");
                Console.ReadKey();
                Park_Vehicle();
                return;
            }
            Slot_Availability_Check = Lot_Object.Check_Slot_Availability(Park_Vehicle_type);
            if (Slot_Availability_Check == false)
            {
                Console.WriteLine("All The Slots are Filled.....Sorry For The Inconvinence....Press any Key to Exit");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter Vehicle Number  :   ");
            Vehicle_Number = Console.ReadLine();
            Ticket_Id_Issued = Lot_Object.Park_Vehicle(Park_Vehicle_type, Vehicle_Number);
            Console.WriteLine("Ticket Issued SuccessFully to " + Vehicle_Number + " and Ticket No Is : " + Ticket_Id_Issued);
            Console.WriteLine("Press Any Key To Go Back....");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        public void Unpark_Vehicle()
        {
            Ticket Found_Ticket;
            String Vehicle_Number;
            int Ticket_Number;
            Console.WriteLine("Enter The Vehicle No To Unpark :   ");
            Vehicle_Number = Console.ReadLine();
            Console.WriteLine("Enter The Ticket No To Unpark :  ");
            Ticket_Number = Convert.ToInt32(Console.ReadLine());
            Found_Ticket = Lot_Object.Unpark_Vehicle (Vehicle_Number, Ticket_Number);
            if (Found_Ticket == null)
            {
                Console.WriteLine("No Vehicle Found With Given Credentials.....Press any Key To Go Back");
                Console.ReadKey();
                Console.Clear();
            }
            else
                Show_Ticket(Found_Ticket);
            MainMenu();
        }

        public void Show_Ticket(Ticket Display_Ticket)
        {
                Console.WriteLine("Unparking SuccessFull...");
                Console.WriteLine("Press Any Key To Display Ticket....");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("--------Ticket is--------");
                Console.WriteLine("Assigned Slot is " + Display_Ticket.Assigned_Slot);
                Console.WriteLine("Ticket No is " + Display_Ticket.Ticket_No);
                Console.WriteLine("Vehicle No is " + Display_Ticket.Vehicle_No);
                Console.WriteLine("In Time is " + Display_Ticket.In_Time);
                Console.WriteLine("Out Time is " + Display_Ticket.Out_Time);
                Console.WriteLine("Enter Any Key to Go Back To MainMenu");
                Console.ReadKey();
                Console.Clear();
        }

        static void Main(String[] args)
        {
            ViewClass ini = new ViewClass();
            ini.LotReading();
            ini.MainMenu();
        }

    }
}
