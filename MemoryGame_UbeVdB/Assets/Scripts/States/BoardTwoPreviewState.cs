namespace Memory.Model.States
{
    public class BoardTwoPreviewState : BoardStateBaseClass
    {
        public BoardTwoPreviewState(MemoryBoard board) : base(board)
        {
        }

       public override BoardStates BoardState => BoardStates.TwoPreview;

        public override void AddPreview(Tile tile)
        {
            // no op
        }

        public override void TileAnimationEnded(Tile tile)
        {
            if (tile == Board.PreviewingTiles[1])
            {
                Board.State = new BoardTwoHidingState(Board);
                Board.PreviewingTiles[0].SetState(new TileHiddenState(Board.PreviewingTiles[0]));
                Board.PreviewingTiles[1].SetState(new TileHiddenState(Board.PreviewingTiles[1]));
            }
        }
    }
}
