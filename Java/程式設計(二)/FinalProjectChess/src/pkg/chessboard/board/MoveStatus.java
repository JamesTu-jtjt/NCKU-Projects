package pkg.chessboard.board;

public enum MoveStatus {
	DONE {
		@Override
		public boolean isDone() {
			return true;
		}

		@Override
		public boolean isIllegal() {
			// TODO Auto-generated method stub
			return false;
		}
	}, 
	ILLEGAL_MOVE {
		@Override
		public boolean isDone() {
			return false;
		}

		@Override
		public boolean isIllegal() {
			// TODO Auto-generated method stub
			return true;
		}
	};
	public abstract boolean isDone();

	public abstract boolean isIllegal();
}
