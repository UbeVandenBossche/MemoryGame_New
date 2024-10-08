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

        public List<Player> Players = new List<Player>();
        public int ActivePlayer = 0;

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

            State = new BoardNoPreviewState(this);
            MakeTiles();
           // AssignMemoryCardIDs();
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

        public void AssignMemoryCardIDss(int count)
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

        public void AssignMemoryCardIDs(List<int> memoryCardIDs)
        {
            bool sameIDPossible = false;
            //memoryCardIDs = memoryCardIDs.Shuffle();
            //List<Tile> shuffledTiles = Tiles.Shuffle();

            Random random = new Random();
            List<Tile> _tempTiles = new List<Tile>(Tiles);
            List<int> _tempMemoryCardIDs = memoryCardIDs;

            //for (int i = 0; i < memoryCardIDs; i++)
            //{
            //    _tempMemoryCardIDs.Add(i);
            //}

            while (_tempTiles.Count > 0)
            {
                if (_tempTiles.Count == 1)
                {
                    _tempTiles[0].MemoryCardID = _tempMemoryCardIDs[random.Next(0, _tempMemoryCardIDs.Count)];
                    _tempTiles.Remove(_tempTiles[0]);
                }
                else
                {
                    Tile tempTile1 = _tempTiles[random.Next(0, _tempTiles.Count)];
                    _tempTiles.Remove(tempTile1);
                    Tile tempTile2 = _tempTiles[random.Next(0, _tempTiles.Count)];
                    _tempTiles.Remove(tempTile2);


                    int randomMemoryID = _tempMemoryCardIDs[random.Next(0, _tempMemoryCardIDs.Count)];
                    tempTile1.MemoryCardID = randomMemoryID;
                    tempTile2.MemoryCardID = randomMemoryID;

                    if (!sameIDPossible)
                    {
                        _tempMemoryCardIDs.Remove(randomMemoryID);
                    }
                }
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
