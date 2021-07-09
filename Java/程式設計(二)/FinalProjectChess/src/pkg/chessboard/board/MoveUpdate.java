package pkg.chessboard.board;

import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.Move;

public class MoveUpdate {

	private final ChessBoard updatedBoard;
	private final Move move;
	private final MoveStatus moveStatus;
	
	public MoveUpdate(final ChessBoard transitionBoard, 
						final Move move, 
						final MoveStatus moveStatus) {
		this.updatedBoard = transitionBoard;
		this.move = move;
		this.moveStatus = moveStatus;
		
	}

	public MoveStatus getMoveStatus() {
		// TODO Auto-generated method stub
		return this.moveStatus;
	}

	public ChessBoard getBoard() {
		// TODO Auto-generated method stub
		return this.updatedBoard;
	}
}
