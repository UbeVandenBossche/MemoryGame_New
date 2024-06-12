namespace Memory.Model.States
{
    public class TilePreviewState : TileStateBaseClass
    {
        public TilePreviewState(Tile tile) : base(tile)
        {
        }

        public override TileStates TileState
        {
            get
            {
                return TileStates.Preview;
            }
        }
    }
}