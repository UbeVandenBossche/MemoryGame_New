using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Model.States
{
    public interface IBoardState
    {
        public BoardStates BoardState { get; }

        public MemoryBoard Board { get; }

        public void AddPreview(Tile tile);
        public void TileAnimationEnded(Tile tile);
        
    }
}