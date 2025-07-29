using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace Ships;

public static void Main(string[] args)
{
    Ship Carrier = new Ship("Carrier", 5);
    Ship Destroyer = new Ship("Destroyer", 4);
    Ship Corvette = new Ship("Corvette", 3);
    Ship SubMarine = new Ship("SubMarine", 2);
}
public class Ship
{
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