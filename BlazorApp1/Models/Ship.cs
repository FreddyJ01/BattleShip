using System;
using System.Collections.Generic;

namespace BlazorApp1.Models
{
    public enum ShipOrientation
    {
        Horizontal,
        Vertical
    }

    public class Ship
    {
        public string Type { get; set; }
        public int Length { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public ShipOrientation Orientation { get; set; }
        public bool IsPlaced { get; set; }
        public List<(int row, int col)> Coordinates { get; set; }

        public Ship(string type, int length)
        {
            Type = type;
            Length = length;
            IsPlaced = false;
            Coordinates = new List<(int, int)>();
        }

        public void SetPosition(int row, int col, ShipOrientation orientation)
        {
            Row = row;
            Col = col;
            Orientation = orientation;
            UpdateCoordinates();
        }

        private void UpdateCoordinates()
        {
            Coordinates.Clear();
            for (int i = 0; i < Length; i++)
            {
                if (Orientation == ShipOrientation.Horizontal)
                {
                    Coordinates.Add((Row, Col + i));
                }
                else
                {
                    Coordinates.Add((Row + i, Col));
                }
            }
        }
    }

    public class ShipManager
    {
        public List<Ship> Ships { get; set; }
        public Ship SelectedShip { get; set; }
        public int[,] Grid { get; set; }

        public ShipManager()
        {
            Grid = new int[10, 10];
            Ships = new List<Ship>
            {
                new Ship("Carrier", 5),
                new Ship("Destroyer", 4),
                new Ship("Corvette", 3),
                new Ship("Submarine", 2)
            };
        }

        public bool CanPlaceShip(Ship ship, int row, int col, ShipOrientation orientation)
        {
            // Check if ship would fit on the grid
            for (int i = 0; i < ship.Length; i++)
            {
                int checkRow = orientation == ShipOrientation.Horizontal ? row : row + i;
                int checkCol = orientation == ShipOrientation.Horizontal ? col + i : col;

                // Check bounds
                if (checkRow < 0 || checkRow >= 10 || checkCol < 0 || checkCol >= 10)
                    return false;

                // Check if cell is already occupied by another ship
                if (Grid[checkRow, checkCol] == 1)
                    return false;
            }

            return true;
        }

        public bool PlaceShip(Ship ship, int row, int col, ShipOrientation orientation)
        {
            if (!CanPlaceShip(ship, row, col, orientation))
                return false;

            // Remove ship from current position if already placed
            if (ship.IsPlaced)
            {
                RemoveShipFromGrid(ship);
            }

            // Place ship at new position
            ship.SetPosition(row, col, orientation);
            ship.IsPlaced = true;

            // Update grid
            foreach (var (shipRow, shipCol) in ship.Coordinates)
            {
                Grid[shipRow, shipCol] = 1;
            }

            return true;
        }

        public void RemoveShipFromGrid(Ship ship)
        {
            if (!ship.IsPlaced) return;

            foreach (var (row, col) in ship.Coordinates)
            {
                Grid[row, col] = 0;
            }
            ship.IsPlaced = false;
        }

        public Ship GetShipAtPosition(int row, int col)
        {
            return Ships.FirstOrDefault(ship => 
                ship.IsPlaced && ship.Coordinates.Contains((row, col)));
        }

        public void RotateShip(Ship ship)
        {
            if (!ship.IsPlaced) return;

            var newOrientation = ship.Orientation == ShipOrientation.Horizontal 
                ? ShipOrientation.Vertical 
                : ShipOrientation.Horizontal;

            if (CanPlaceShip(ship, ship.Row, ship.Col, newOrientation))
            {
                RemoveShipFromGrid(ship);
                PlaceShip(ship, ship.Row, ship.Col, newOrientation);
            }
        }
    }
}