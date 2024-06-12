namespace Memory.Model.States
{
    public class TileHiddenState : TileStateBaseClass
    {
        public TileHiddenState(Tile tile) : base(tile)
        {
        }

        public override TileStates TileState
        {
            get
            {
                return TileStates.Hidden;
            }
        }
    }
}