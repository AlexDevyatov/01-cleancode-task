namespace CleanCode
{
	public class Chess
	{
		private readonly Board _board;

		public Chess(Board b)
		{
		    this._board = b;
		}

		public string GetWhiteStatus() {

			bool ok = false;
			foreach (Loc location1 in _board.Figures(Cell.White))
			{
			    foreach (Loc location2 in _board.Get(location1).Figure.Moves(location1, _board))
			    {
			        Cell oldDest = _board.PerformMove(location1, location2);
			        if (!CheckForWhite())
			            ok = true;
			        _board.PerformUndoMove(location1, location2, oldDest);
			    }

			}
		    if (CheckForWhite())
		    {
		        if (ok)
		            return "check";
		        return "mate";
		    }
		    if (ok)	
                return "ok";
			return "stalemate";
		}

		private bool CheckForWhite()
		{
			bool isWhite = false;
			foreach (Loc loc in _board.Figures(Cell.Black))
			{
				var cell = _board.Get(loc);
				var moves = cell.Figure.Moves(loc, _board);
				foreach (Loc to in moves)
				{
					if (_board.Get(to).IsWhiteKing)
						isWhite = true;
				}
			}
			if (isWhite)
                return true;
			return false;
		}
	}
}