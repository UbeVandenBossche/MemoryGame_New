using Memory.Model.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Memory.Model.States
{
    public interface ITileState
    {
        public TileStates TileState { get; }

        public Tile TileReference { get; }

    }
}
