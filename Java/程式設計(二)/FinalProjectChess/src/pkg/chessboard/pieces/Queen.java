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

public class Queen extends Piece{
	
	private final static int[] MOVE_VECTOR_COORDINATES = {-9, -8, -7, -1, 1, 7, 8, 9};

	public Queen(final int piecePos, final ColorOfPieces pieceCol) {
		super(PieceType.QUEEN, piecePos, pieceCol, true);
	}
	
	public Queen(final int piecePos, final ColorOfPieces pieceCol, final boolean firstMove) {
		super(PieceType.QUEEN, piecePos, pieceCol, true);
	}


	@Override
	public Collection<Move> calculateMoves(final ChessBoard board) {
		// TODO Auto-generated method stub
		final List<Move> legalMoves = new ArrayList<>();
		
		for(final int coordinateOffset: MOVE_VECTOR_COORDINATES) {
			
			int destinationCoordinate = this.piecePos;
			
			while(BoardUtils.isValidTileCoordinate(destinationCoordinate)) {
				if (isAFileExclusion(destinationCoordinate, coordinateOffset) ||
	                    isHFileExclusion(destinationCoordinate, coordinateOffset)) {
	                    break;
	                }
				
				destinationCoordinate += coordinateOffset;
				
				if(BoardUtils.isValidTileCoordinate(destinationCoordinate)) {
					
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
						break;
					}
				}
				
			}
		}
		
		return Collections.unmodifiableList(legalMoves);
	}
	
	@Override
	public Queen movePiece(final Move move) {
		// TODO Auto-generated method stub
		return new Queen(move.getDestinationCoordinate(), move.getMovedPiece().getPieceCol());
	}

	
	@Override
	public String toString() {
		return Piece.PieceType.QUEEN.toString();
	}
	
	private static boolean isAFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.A_FILE[currentPosition] && ((candidateOffset == -9) || (candidateOffset == 7) || (candidateOffset == -1));
	}
	
	private static boolean isHFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.H_FILE[currentPosition] && ((candidateOffset == -7) || (candidateOffset == 9) || (candidateOffset == 1));
	}

}
