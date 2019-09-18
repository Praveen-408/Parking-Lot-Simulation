using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class Vehicle
    {
        public string Vehicle_No { private set; get; }
        public int Vehicle_Type { private set; get; }

        public Vehicle(string Vehicle_No, int Vehicle_Type)
        {
            this.Vehicle_No = Vehicle_No;
            this.Vehicle_Type = Vehicle_Type;
        }
    }
}
