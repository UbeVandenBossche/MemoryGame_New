


namespace Memory.Model.States
{
        public class BoardTwoHidingState : BoardStateBaseClass
    {
                public BoardTwoHidingState(MemoryBoard board) : base(board)
                {
                }
               
                public override BoardStates BoardState => BoardStates.TwoHiding;
               
                public override void AddPreview(Tile tile)
                {
                    // no op
                }
               
                public override void TileAnimationEnded(Tile tile)
                {
                    Board.PreviewingTiles.Remove(tile);
                    if (Board.PreviewingTiles.Count == 0)
                    {
                        Board.State = new BoardNoPreviewState(Board);
                    }
                }
    }          
}