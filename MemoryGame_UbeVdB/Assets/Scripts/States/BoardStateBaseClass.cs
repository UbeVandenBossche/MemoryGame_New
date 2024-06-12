using Memory.Model;
using Memory.Model.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardStateBaseClass : IBoardState
{
    public abstract BoardStates BoardState
    {
        get;
    }

    protected MemoryBoard _board;
    public MemoryBoard Board { get => _board; }

    public abstract void AddPreview(Tile tile);

    public BoardStateBaseClass(MemoryBoard board)
    {
        _board = board;
    }

    public abstract void TileAnimationEnded(Tile tile);
    
}
