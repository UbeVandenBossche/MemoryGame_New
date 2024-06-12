using Memory.Model.States;
using Memory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace Memory.Model.States
{
    public class BoardOnePreviewState : BoardStateBaseClass
    {
        [SerializeField] private List<Material> _tileFronts;
        public BoardOnePreviewState(MemoryBoard board) : base(board)
        {

        }

       public override BoardStates BoardState => BoardStates.OnePreview;

        public override void AddPreview(Tile tile)
        {
            if (tile.State.TileState != TileStates.Hidden)
            {
                return;
            }

            Board.PreviewingTiles.Add(tile);

            if (Board.IsCombinationFound)
            {
                Board.State = new BoardTwoFoundState(Board);
                Board.PreviewingTiles[0].SetState(new TileFoundState(Board.PreviewingTiles[0]));
                Board.PreviewingTiles[1].SetState(new TileFoundState(Board.PreviewingTiles[1]));
            }
            else
            {
                Board.State = new BoardTwoPreviewState(Board);
                tile.SetState(new TilePreviewState(tile));
            }
        }

        public override void TileAnimationEnded(Tile tile)
        {
            //no op
        }
    }
}
