using Memory.Model.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileState 
{
    public TileStates state { get; }

    public Tile TileReference { get; }

}
