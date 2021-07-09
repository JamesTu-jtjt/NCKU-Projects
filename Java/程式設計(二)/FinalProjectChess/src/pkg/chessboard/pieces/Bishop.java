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

public class Bishop extends Piece {
	
	private final static int[] MOVE_VECTOR_COORDINATES = {-9, -7, 7, 9};

	public Bishop(final int piecePos, final ColorOfPieces pieceCol) {
		super(PieceType.BISHOP, piecePos, pieceCol, true);
	}
	
	public Bishop(final int piecePos, final ColorOfPieces pieceCol, final boolean firstMove) {
		super(PieceType.BISHOP, piecePos, pieceCol, firstMove);
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
						break;
					}
				}
				
			}
		}
		
		return Collections.unmodifiableList(legalMoves);
	}
	
	@Override
	public Bishop movePiece(final Move move) {
		// TODO Auto-generated method stub
		return new Bishop(move.getDestinationCoordinate(), move.getMovedPiece().getPieceCol());
	}
	
	@Override
	public String toString() {
		return Piece.PieceType.BISHOP.toString();
	}
	
	private static boolean isAFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.A_FILE[currentPosition] && ((candidateOffset == -9) || (candidateOffset == 7));
	}
	
	private static boolean isHFileExclusion(final int currentPosition, final int candidateOffset) {
		return BoardUtils.H_FILE[currentPosition] && ((candidateOffset == -7) || (candidateOffset == 9));
	}


}
