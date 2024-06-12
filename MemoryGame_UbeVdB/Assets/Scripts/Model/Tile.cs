using Memory;
using Memory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Memory.Model.States;

namespace Memory.Model
{
    public class Tile : ModelBaseClass
    {
        public int Row;
        public int Column;

        public MemoryBoard Board;
        public ITileState State;
        private int _memoryCardId;
        public int MemoryCardID
        {
            get { return _memoryCardId; }
            set
            {
                if (_memoryCardId == value)
                    return;
                _memoryCardId = value;
                OnPropertyChanged();
            }
        }


        public Tile(int row, int column, MemoryBoard board)
        {
            Row = row;
            Column = column;
            Board = board;
        }

        public override string ToString()
        {
            return $"Tile({Row},{Column})";
        }

        public void SetState(ITileState state)
        {

        }


    }
}
