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

        public MineSweeperGame(int sizeX, int sizeY, int nrOfMines, IServiceBus bus)
        {
            _bus = bus;
        }

        private IServiceBus _bus;
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int SizeX { get; }
        public int SizeY { get; }
        public int NumberOfMines { get; }
        public GameState State { get; private set; }

        public PositionInfo GetCoordinate(int x, int y)
        {
            return null;
        }

        public void FlagCoordinate()
        {
        }

        public void ClickCoordinate()
        {
        }

        public void ResetBoard()
        {
        }

        public void DrawBoard()
        {
            
            
            
            for(int i=0; i < PosY; i++)
            {
            
                _bus.WriteLine();
                for(int b=0; b < PosX; b++)
                {
                    _bus.Write("dad");
                  
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
