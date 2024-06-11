using Memory.Model.States;
using Memory.Models.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Model.States
{
    public class HiddenState : TileStateBaseClass
    {
        public HiddenState(Tile TileReference) : base(TileReference)
        {
            base._tileReference = TileReference;
            base._state = TileStates.Hidden;

        }
    }
}
