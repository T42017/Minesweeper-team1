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
            
            
            
            
            
            
           
            for(int i=0; i < SizeY; i++)
            {
            
                _bus.WriteLine();
                for(int b=0; b < SizeX; b++)
                {

                    if(_grid[i, b].IsOpen==true)
                    {
                     switch(_grid[i, b].NrOfNeighbours)
                        {
                        case 1:
                        _bus.Write("1 ");

                        break;

                            case 2:
                        _bus.Write("2 ");

                        break;

                            case 3:
                        _bus.Write("3 ");
                        break;

                            case 4:
                        _bus.Write("4 ");
                        break;

                            case 5:
                       _bus.Write("5 ");
                       break ;

                            case 6:
                      _bus.Write("6 ");
                      break;

                            case 7:
                        _bus.Write("7 ");
                         break;

                            case 8:
                          _bus.Write("8 ");
                          break;

             


                        }
                    }
                    else if(_grid[i, b].IsFlagged == true)
                    {
                        _bus.Write("! ");
                    }
                    else if (_grid[i, b].HasMine == true)
                    {
                        _bus.Write("X ");
                    }
                    else
                    {
                        _bus.Write("? ");
                    }



                }
        }

        }

        #region MoveCursor Methods

        public void MoveCursorUp()
        {
            

            
                if (PosY <= 0)
                {

                }
                else
                {
                    PosY--;
                }
               
            

            

        }

        public void MoveCursorDown()
        {
            

            
                if (PosY == SizeY-1)
                {

                }
                else
                {
                    PosY++;
                }
             

            
            }

        public void MoveCursorLeft()
            {
                

                
                    if (PosX <= 0)
                    {

                    }  
                    else
                    {
                        PosX--;
                    }
                    
                }
            


        public void MoveCursorRight()
        {
           

      
                
                 if (PosX == SizeX-1)
                {

                }
                else
                {
                    PosX++;
                }
                
            
        }
        #endregion

    }
}
