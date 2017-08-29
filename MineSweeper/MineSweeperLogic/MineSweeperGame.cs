using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLogic
{
    public class MineSweeperGame
    {
        private PositionInfo[,] _grid;
        private IServiceBus _bus;
        
        #region Constructor

        public MineSweeperGame(int sizeX, int sizeY, int nrOfMines, IServiceBus bus)
        {
            _grid = new PositionInfo[sizeX, sizeY];
            NumberOfMines = nrOfMines;
            State = GameState.Playing;
            _bus = bus;
            ResetBoard();
        }
        #endregion

        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public int SizeX => _grid.GetLength(0);
        public int SizeY => _grid.GetLength(1);

        public int NumberOfMines { get; }
        public GameState State { get; private set; }

        public PositionInfo GetCoordinate(int x, int y)
        {
            return _grid[x, y];
        }

        public void FlagCoordinate()
        {
        }

        public void ClickCoordinate()
        {
        }

        #region Reset board

        public void ResetBoard()
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    _grid[x, y] = new PositionInfo()
                    {
                        X = x,
                        Y = y,
                        IsOpen = false,
                        IsFlagged = false
                    };
                }
            }
            PlaceNumberOfMines(NumberOfMines);
            State = GameState.Playing;
        }

        private void PlaceNumberOfMines(int nrOfMines)
        {
            if (nrOfMines <= 0)
                return;

            int placedMines = 0;

            do
            {
                int x = _bus.Next(SizeX);
                int y = _bus.Next(SizeY);
                if (!_grid[x, y].HasMine)
                {
                    _grid[x, y].HasMine = true;
                    placedMines++;
                }
            }
            while (placedMines != nrOfMines);
        }

        private int GetNumberOfNeighbours(PositionInfo cell)
        {
            if (cell.X == 0 && cell.Y == 0)
            {
                
            }
            return 0;
        }

        #endregion

        public void DrawBoard()
        {
            int[,] data = new int[PosX, PosY];
            
            PosX = 2;
            PosY = 2;
            String text;
            text = "";
            
            for(int i=0; i < PosY; i++)
            {
            
                _bus.WriteLine();
                for(int b=0; b < PosX; b++)
                {
                    
                    switch ("?")
                    {
                        case ".":
                            text = ".";
                            break;
                        case "!":
                            text = "!";
                            break;
                        case "X":
                            text = "X";
                            break;
                        case "?":
                            text = "?";
                            break;
                        case "1":
                            text = "1";
                            break;
                        case "2":
                            text = "2";
                            break;
                        case "3":
                            text = "3";
                            break;
                        case "4":
                            text = "4";
                            break;
                        case "5":
                            text = "5";
                            break;
                        case "6":
                            text = "6";
                            break;
                        case "7":
                            text = "7";
                            break;
                        case "8":
                            text = "8";
                            break;
                           
                    }
                    _bus.Write(text);
                }
            }
            
        }

        #region MoveCursor Methods

        public void MoveCursorUp()
        {
        }

        public void MoveCursorDown()
        {
        }

        public void MoveCursorLeft()
        {
        }

        public void MoveCursorRight()
        {
        }

        #endregion

    }
}
