package pkg.chessboard.pieces;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import pkg.chessboard.ColorOfPieces;
import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.BoardUtils;
import pkg.chessboard.board.Move;
import pkg.chessboard.board.Square;

public class Knight extends Piece {
	
	
	private final static int[] MOVE_COORDINATES = {-17, -15, -10, -6, 6, 10, 15, 17};

	public Knight(final int piecePos, final ColorOfPieces pieceCol) {
		super(PieceType.KNIGHT, piecePos, pieceCol, true);
	}
	
	public Knight(final int piecePos, final ColorOfPieces pieceCol, final boolean firstMove) {
		super(PieceType.KNIGHT, piecePos, pieceCol, firstMove);
	}

	@Override
	public Collection<Move> calculateMoves(final ChessBoard board) {
		// TODO Auto-generated method stub
		
		final List<Move> legalMoves = new ArrayList<>();
		
		for(final int candidateOffset: MOVE_COORDINATES) {
			final int destinationCoordinate = this.piecePos + candidateOffset;
			
			if(BoardUtils.isValidTileCoordinate(destinationCoordinate)) {
				
				if(isAFileExclusion(this.piecePos, candidateOffset) || 
						isBFileExclusion(this.piecePos, candidateOffset) ||
						isGFileExclusion(this.piecePos, candidateOffset) ||
						isHFileExclusion(this.piecePos, candidateOffset)) {
					continue;
				}
				
				final Square destinationSquare = board.getSquare(destinationCoordinate);
				
				if(!destinationSquare.squareOccupied()) {
					legalMoves.add(new Move.PositionalMove(board, this, destinationCoordinate));
				}
				else {
					final Piece pieceAtDestination = destinationSquare.getPiece();
					final ColorOfPieces pieceAlliance = pieceAtDestination.getPieceCol();
					
					if(this.pieceColor != pieceAlliance) {
						legalMoves.add(new Move.MajorCaptureMove(board, this, destinationCoordinate, pieceAtDestination));
					}
				}
			}
		}
		
		return Collections.unmodifiableList(legalMoves);
	}
	
	@Override
	public Knight movePiece(final Move move) {
		// TODO Auto-generated method stub
		return new Knight(move.getDestinationCoordinate(), move.getMovedPiece().getPieceCol());
	}

	
	@Override
	public String toString() {
		return Piece.PieceType.KNIGHT.toString();
	}
	
	private static boolean isAFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.A_FILE[currentPosition] && ((candidateOffset == -17) || (candidateOffset == -10) ||
				(candidateOffset == 6) || (candidateOffset == 15));
	}
	
	private static boolean isBFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.B_FILE[currentPosition] && ((candidateOffset == -10) || (candidateOffset == 6));
	}
	
	private static boolean isGFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.G_FILE[currentPosition] && ((candidateOffset == -6) || (candidateOffset == 10));
	}
	
	private static boolean isHFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.H_FILE[currentPosition] && ((candidateOffset == -15) || (candidateOffset == -6) ||
				(candidateOffset == 10) || (candidateOffset == 17));
	}

}
