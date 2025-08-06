using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class GameStateService
    {
        public ShipManager? PlayerShipManager { get; set; }
        
        public void SetPlayerShips(ShipManager shipManager)
        {
            // Create a deep copy of the ship manager to avoid reference issues
            PlayerShipManager = new ShipManager();
            
            // Copy the grid
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    PlayerShipManager.Grid[row, col] = shipManager.Grid[row, col];
                }
            }
            
            // Copy ships with their positions
            for (int i = 0; i < shipManager.Ships.Count; i++)
            {
                var originalShip = shipManager.Ships[i];
                var newShip = PlayerShipManager.Ships[i];
                
                newShip.IsPlaced = originalShip.IsPlaced;
                newShip.Orientation = originalShip.Orientation;
                newShip.Row = originalShip.Row;
                newShip.Col = originalShip.Col;
                
                // Copy coordinates
                newShip.Coordinates.Clear();
                newShip.Coordinates.AddRange(originalShip.Coordinates);
            }
        }
        
        public bool HasPlayerShips()
        {
            return PlayerShipManager != null && PlayerShipManager.Ships.All(s => s.IsPlaced);
        }
        
        public void ClearGameState()
        {
            PlayerShipManager = null;
        }
    }
}
