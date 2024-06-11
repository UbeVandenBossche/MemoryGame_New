using Memory.Model.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{
    public class TileStateBaseClass : ITileState
    {
        protected TileStates _state;
        public TileStates state { get => _state; }

        protected Tile _tileReference;
        public Tile TileReference { get => _tileReference; }

        public TileStateBaseClass(Tile TileReference)
        {
            _tileReference = TileReference;
        }
    }
}
