using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class GameStateService
    {
        public List<Ship> PlayerShips { get; set; } = new();
        public int[,] PlayerGrid { get; set; } = new int[10, 10];
        public bool HasShipsPlaced => PlayerShips.Count > 0 && PlayerShips.All(s => s.IsPlaced);

        public void SetPlayerShips(List<Ship> ships, int[,] grid)
        {
            PlayerShips = ships.Where(s => s.IsPlaced).ToList();
            PlayerGrid = (int[,])grid.Clone();
            
            // Debug output
            Console.WriteLine($"GameState: Stored {PlayerShips.Count} ships");
            foreach (var ship in PlayerShips)
            {
                Console.WriteLine($"Ship: {ship.Name} at ({ship.StartRow},{ship.StartCol}) horizontal:{ship.IsHorizontal}");
            }
        }

        public void ClearGameState()
        {
            PlayerShips.Clear();
            PlayerGrid = new int[10, 10];
        }
    }
}