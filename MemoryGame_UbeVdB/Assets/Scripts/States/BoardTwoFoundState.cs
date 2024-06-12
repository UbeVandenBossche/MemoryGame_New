using Memory.Model;
using System.Linq;

namespace Memory.Model.States
{
    public class BoardTwoFoundState : BoardStateBaseClass
    {
        public BoardTwoFoundState(MemoryBoard board) : base(board)
        {
            //board.Players[board.ActivePlayer].Score++;
        }

       public override BoardStates BoardState => BoardStates.TwoFound;

        public override void AddPreview(Tile tile)
        {
            // no op
        }

        

        public override void TileAnimationEnded(Tile tile)
        {
            if (Board.PreviewingTiles[Board.PreviewingTiles.Count - 1] == tile)
            {
                if (Board.Tiles.Where(t => t.State.TileState == TileStates.Hidden).Count() < 2)
                {
                    Board.State = new BoardFinishedState(Board);
                }
                else
                {
                    Board.State = new BoardNoPreviewState(Board);
                }
            }
        }

       
    }
}