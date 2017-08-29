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
            if (x < 0 || x >= SizeX || y < 0 || y >= SizeY)
                throw new IndexOutOfRangeException("Coordinate with given x and y is not in board.");
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
                        HasMine = false,
                        IsFlagged = false,
                    };
                }
            }
            PlaceNumberOfMines(NumberOfMines);
            foreach (var cell in _grid)
            {
                cell.NrOfNeighbours = GetNumberOfNeighbours(cell.X, cell.Y);
            }
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
                if (!GetCoordinate(x, y).HasMine)
                {
                    GetCoordinate(x, y).HasMine = true;
                    placedMines++;
                }
            }
            while (placedMines != nrOfMines);
        }

        public PositionInfo[] GetAdjacentCells(int x, int y)
        {
            var cells = new List<PositionInfo>();

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y ||
                        i < 0 || i >= SizeX ||
                        j < 0 || j >= SizeY)
                        continue;
                    cells.Add(GetCoordinate(i, j));
                }
            }
            return cells.ToArray();
        }

        private int GetNumberOfNeighbours(int x, int y)
        {
            /*
             X-1, Y
             X-1, Y-1
             X, Y-1
             X+1, Y-1
             X+1, Y
             X+1, Y+1
             X, Y+1
             X-1, Y+1
            */
            if (x < 0 || x >= SizeX ||
                y < 0 || y >= SizeY)
                throw new IndexOutOfRangeException("X and Y must exist as indices in the grid.");

            var neighbours = GetAdjacentCells(x, y);
            return neighbours.Count(neighbour => neighbour.HasMine);
        }

        #endregion

        public void DrawBoard()
        {
            
            
            
            int lenghtX = SizeX,lenghtY = SizeY;
           
           
            for(int i=0; i < lenghtY; i++)
            {
            
                _bus.WriteLine();
                for(int b=0; b < lenghtX; b++)
                {

                    if(_grid[b, i].IsOpen==true)
                    {
                     switch(_grid[b, i].NrOfNeighbours)
                        {
                        case 1:
                       if(PosX==b && PosY == i)
                                {
                                    _bus.Write("1 ", ConsoleColor.DarkCyan);
                                }
                                else { _bus.Write("1 "); }
                                    

                        break;

                            case 2:
                                if(PosX==b && PosY == i)
                                {
                                    _bus.Write("2 ",ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("2 ");
                                }

                        break;

                            case 3:
                                if (PosX == b && PosY == i)
                                {
                                    _bus.Write("3 ", ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("3 ");
                                }
                                break;

                            case 4:
                                if (PosX == b && PosY == i)
                                {
                                    _bus.Write("4 ", ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("4 ");
                                }
                                break;

                            case 5:
                                if (PosX == b && PosY == i)
                                {
                                    _bus.Write("5 ", ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("5 ");
                                }
                                break ;

                            case 6:
                                if (PosX == b && PosY == i)
                                {
                                    _bus.Write("6 ", ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("6 ");
                                }
                                break;

                            case 7:
                                if (PosX == b && PosY == i)
                                {
                                    _bus.Write("7 ", ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("7 ");
                                }
                                break;

                            case 8:
                                if (PosX == b && PosY == i)
                                {
                                    _bus.Write("8 ", ConsoleColor.DarkCyan);
                                }
                                else
                                {
                                    _bus.Write("8 ");
                                }
                                break;

             


                        }
                    }
                    else if(_grid[i, b].IsFlagged == true)
                    {
                        if (PosX == b && PosY == i)
                        {
                            _bus.Write("! ", ConsoleColor.DarkCyan);
                        }
                        else
                        {
                            _bus.Write("! ");
                        }
                    }
                    else if (_grid[i, b].HasMine == true)
                    {
                        if (PosX == b && PosY == i)
                        {
                            _bus.Write("X ", ConsoleColor.DarkCyan);
                        }
                        else
                        {
                            _bus.Write("X ");
                        }
                    }
                    else
                    {
                        if (PosX == b && PosY == i)
                        {
                            _bus.Write("? ", ConsoleColor.DarkCyan);
                        }
                        else
                        {
                            _bus.Write("? ");
                        }
                    }



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
