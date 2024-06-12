using Memory.Model;
using Memory.Model.States;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Memory.Model
{

   
    public class MemoryBoard : ModelBaseClass
    {
        public int Rows;
        public int Columns;

        public List<Tile> Tiles = new List<Tile>();
        public List<Tile> PreviewingTiles = new List<Tile>();

        public IBoardState State;
        private bool _isCombinationFound;
        public bool IsCombinationFound
        {
            get
            {
                if (PreviewingTiles[0].MemoryCardID == PreviewingTiles[1].MemoryCardID)
                {
                    return true;
                }
                return false;
            }
        }

        public MemoryBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;


            MakeTiles();
            AssignMemoryCardIds();
        }

        private void MakeTiles()
        {
           for(int x = 0; x < Columns; x++)
            {
                for(int y = 0; y < Rows; y++)
                {
                    Tile tile = new Tile(x, y, this);
                    Tiles.Add(tile);
                }
            }
        }

        private void AssignMemoryCardIds()
        {
            List<Tile> remainingTiles = new List<Tile>(Tiles);
            Random rnd = new Random();
            int cycleNumber = 1;
            while (remainingTiles.Count > 0)
            {

                int number1 = 0;
                int number2 = 0;
                if (remainingTiles.Count > 1)
                {
                    while (number1 == number2)
                    {
                        number1 = rnd.Next(remainingTiles.Count);
                        number2 = rnd.Next(remainingTiles.Count);
                    }

                    //Tiles[FindIndexTiles(Tiles, remainingTiles[number1])].MemoryCardId = cycleNumber;
                    //Tiles[FindIndexTiles(Tiles, remainingTiles[number2])].MemoryCardId = cycleNumber;

                    remainingTiles[number1].MemoryCardID = cycleNumber;
                    remainingTiles[number2].MemoryCardID = cycleNumber;

                    if (number1 > number2)
                    {
                        remainingTiles.RemoveAt(number2);
                        remainingTiles.RemoveAt(number1 - 1);
                    }
                    else
                    {
                        remainingTiles.RemoveAt(number1);
                        remainingTiles.RemoveAt(number2 - 1);
                    }
                }
                else
                {
                    remainingTiles[0].MemoryCardID = cycleNumber;
                    remainingTiles.RemoveAt(0);
                }
                cycleNumber++;
            }

           

        }
        private int FindIndexTiles(List<Tile> list1, Tile tile)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].ToString().Equals(tile.ToString())) return i;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"MemoryBoard({Rows},{Columns})";
        }
    }
}
