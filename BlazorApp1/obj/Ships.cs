using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.obj
{
    public class Ships
    {
        Ship Carrier = new Ship("Carrier", 5);
        Ship Destroyer = new Ship("Destroyer", 4);
        Ship Corvette = new Ship("Corvette", 3);
        Ship SubMarine = new Ship("SubMarine", 2);
    
    
        string type;
        int length;
        static int totalShips = 0;

        public Ship(string type, int length)
        {
            this.type = type;
            this.length = length;
            totalShips++;
        }

        public void PlaceShip(string location)
        {
            OnClick(string(location));
            
        }
    }
}
