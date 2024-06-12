namespace Memory.Model.States
{
    public class BoardFinishedState : BoardStateBaseClass
    {
        public BoardFinishedState(MemoryBoard board) : base(board)
        {
        }

        public override BoardStates BoardState => BoardStates.Finished;

        public override void AddPreview(Tile tile)
        {
            // no op
        }

        public override void TileAnimationEnded(Tile tile)
        {
            // no op
        }
    }
}