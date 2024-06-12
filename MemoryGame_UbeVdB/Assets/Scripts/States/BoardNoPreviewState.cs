using System;
using System.Collections.Generic;

namespace Memory.Model.States
{
    public class BoardNoPreviewState : BoardStateBaseClass
    {
        public BoardNoPreviewState(MemoryBoard board) : base(board)
        {
            //if (board.Players != null && board.Players.Count > 0)
            //{
            //    board.ActivePlayer += 1;
            //    if (board.ActivePlayer >= board.Players.Count)
            //    {
            //        board.ActivePlayer = 0;
            //    }

            //    foreach (Player player in board.Players)
            //    {
            //        player.IsActive = false;
            //    }

            //    if (board.Players.Count > 0)
            //    {
            //        board.Players[board.ActivePlayer].IsActive = true;
            //    }
            //}

            Board.PreviewingTiles = new List<Tile>();
        }
        
        public override BoardStates BoardState => BoardStates.NoPreview;

        public override void AddPreview(Tile tile)
        {
            if (tile.State.TileState != TileStates.Hidden)
            {
                return;
            }

            tile.SetState(new TilePreviewState(tile));
            Board.PreviewingTiles.Add(tile);

            Board.State = new BoardOnePreviewState(Board);
        }

        public override void TileAnimationEnded(Tile tile)
        {        
            // no op
        }
    }
}