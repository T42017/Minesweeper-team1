﻿using System;
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
