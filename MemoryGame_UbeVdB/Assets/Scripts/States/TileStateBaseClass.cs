using Memory.Model.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Model.States
{
    public abstract class TileStateBaseClass : ITileState
    {
        public abstract TileStates TileState
        {
            get;
        }

        protected Tile _tileReference;
        public Tile TileReference { get => _tileReference; }

        public TileStateBaseClass(Tile TileReference)
        {
            _tileReference = TileReference;
        }
    }
}
