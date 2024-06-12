namespace Memory.Model.States
{
    public class TileFoundState : TileStateBaseClass
    {
        public TileFoundState(Tile tile) : base(tile)
        {
        }

        public override TileStates TileState
        {
            get
            { 
                return TileStates.Found;
            }
        }
    }
}