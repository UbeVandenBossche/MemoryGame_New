using Memory;
using Memory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : ModelBaseClass
{
    public int Row;
    public int Column;

    public MemoryBoard Board;
    private int _memoryCardId;
    public int MemoryCardId
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


}
