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

public class King extends Piece{
	
	private final static int[] MOVE_COORDINATES = {-9, -8, -7, -1, 1, 7, 8, 9};

	public King(final int piecePos, final ColorOfPieces pieceCol) {
		super(PieceType.KING, piecePos, pieceCol, true);
	}
	
	public King(final int piecePos, final ColorOfPieces pieceCol, final boolean firstMove) {
		super(PieceType.KING, piecePos, pieceCol, firstMove);
	}

	@Override
	public Collection<Move> calculateMoves(ChessBoard board) {
		// TODO Auto-generated method stub
		final List<Move> legalMoves = new ArrayList<>();
		
		for(final int candidateOffset : MOVE_COORDINATES) {
			final int destinationCoordinate = this.piecePos + candidateOffset;
			
			if(isAFileExclusion(this.piecePos, candidateOffset) || 
				isHFileExclusion(this.piecePos, candidateOffset)) {
				continue; 
			}
			
			if(BoardUtils.isValidTileCoordinate(destinationCoordinate)) {
				final Square candidateDestinationTile = board.getSquare(destinationCoordinate);
				
				if(!candidateDestinationTile.squareOccupied()) {
					legalMoves.add(new Move.PositionalMove(board, this, destinationCoordinate));
				}
				else {
					final Piece pieceAtDestination = candidateDestinationTile.getPiece();
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
	public King movePiece(final Move move) {
		// TODO Auto-generated method stub
		return new King(move.getDestinationCoordinate(), move.getMovedPiece().getPieceCol());
	}

	
	@Override
	public String toString() {
		return Piece.PieceType.KING.toString();
	}
	
	private static boolean isAFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.A_FILE[currentPosition] && ((candidateOffset == -9) || (candidateOffset == -1) ||
				(candidateOffset == 7));
	}
	
	private static boolean isHFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.H_FILE[currentPosition] && ((candidateOffset == -7) || (candidateOffset == 1) ||
				(candidateOffset == 9));
	}
	
}
