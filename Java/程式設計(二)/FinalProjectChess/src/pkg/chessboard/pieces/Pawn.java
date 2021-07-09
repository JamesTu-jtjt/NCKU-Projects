package pkg.chessboard.pieces;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import pkg.chessboard.ColorOfPieces;
import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.BoardUtils;
import pkg.chessboard.board.Move;

public class Pawn extends Piece{
	
	private final static int[] MOVE_COORDINATES = {8, 16, 7, 9};

	public Pawn(final int piecePos, final ColorOfPieces pieceCol) {
		super(PieceType.PAWN, piecePos, pieceCol, true);
	}
	public Pawn(final int piecePos, final ColorOfPieces pieceCol, final boolean firstMove) {
		super(PieceType.PAWN, piecePos, pieceCol, firstMove);
	}

	@Override
	public Collection<Move> calculateMoves(ChessBoard board) {
		
		final List<Move> moves = new ArrayList<>();
		
		for(final int candidateOffset: MOVE_COORDINATES) {
			final int destinationCoordinate = this.piecePos + this.getPieceCol().getDirection() * candidateOffset;
			
			if(!BoardUtils.isValidTileCoordinate(destinationCoordinate)) {
				continue;
			}
			
			if(candidateOffset == 8 && !board.getSquare(destinationCoordinate).squareOccupied()) {
				if(this.pieceColor.isPromotion(destinationCoordinate)) {
					moves.add(new Move.PromotionMove(new Move.PawnMove(board, this, destinationCoordinate)));
				} else {
					moves.add(new Move.PawnMove(board, this, destinationCoordinate));
				}
			}else if(candidateOffset == 16 && this.isFirstMove() && 
					((BoardUtils.RANK_7[this.piecePos] && this.getPieceCol().isBlack()) || 
					(BoardUtils.RANK_2[this.piecePos] && this.getPieceCol().isWhite()))) {
				final int behindDestinationCoordinate = this.piecePos + (this.pieceColor.getDirection() * 8);
				if(!board.getSquare(behindDestinationCoordinate).squareOccupied() && 
						!board.getSquare(destinationCoordinate).squareOccupied()) {
					moves.add(new Move.PawnJumpMove(board, this, destinationCoordinate));
				}
			} else if(candidateOffset == 7 && 
					!((BoardUtils.H_FILE[this.piecePos] && this.pieceColor.isWhite()) ||
					(BoardUtils.A_FILE[this.piecePos] && this.pieceColor.isBlack()))) {
				if(board.getSquare(destinationCoordinate).squareOccupied()) {
					final Piece pieceOnCandidate = board.getSquare(destinationCoordinate).getPiece();
					if(this.pieceColor != pieceOnCandidate.getPieceCol()) {
						if(this.pieceColor.isPromotion(destinationCoordinate)) {
							moves.add(new Move.PromotionMove(new Move.PawnCaptureMove(board, this, destinationCoordinate, pieceOnCandidate)));
						} else {
							moves.add(new Move.PawnCaptureMove(board, this, destinationCoordinate, pieceOnCandidate));
						}
					}
				}else if(board.getEnPassantPawn() != null) {
					if(board.getEnPassantPawn().getPiecePos() == (this.piecePos + (this.pieceColor.getOppositeDirection()))) {
						final Piece pieceOnCandidate = board.getEnPassantPawn();
						if(this.pieceColor != pieceOnCandidate.pieceColor) {
							moves.add(new Move.EnPassantMove(board, this, destinationCoordinate, pieceOnCandidate));
						}
					}
				}
				
			}else if(candidateOffset == 9 && 
					!((BoardUtils.H_FILE[this.piecePos] && this.pieceColor.isBlack()) ||
					(BoardUtils.A_FILE[this.piecePos] && this.pieceColor.isWhite()))) {
				if(board.getSquare(destinationCoordinate).squareOccupied()) {
					final Piece pieceOnCandidate = board.getSquare(destinationCoordinate).getPiece();
					if(this.pieceColor != pieceOnCandidate.getPieceCol()) {
						if(this.pieceColor.isPromotion(destinationCoordinate)) {
							moves.add(new Move.PromotionMove(new Move.PawnCaptureMove(board, this, destinationCoordinate, pieceOnCandidate)));
						} else {
							moves.add(new Move.PawnCaptureMove(board, this, destinationCoordinate, pieceOnCandidate));
						}
					}
				}else if(board.getEnPassantPawn() != null) {
					if(board.getEnPassantPawn().getPiecePos() == (this.piecePos - (this.pieceColor.getOppositeDirection()))) {
						final Piece pieceOnCandidate = board.getEnPassantPawn();
						if(this.pieceColor != pieceOnCandidate.pieceColor) {
							moves.add(new Move.EnPassantMove(board, this, destinationCoordinate, pieceOnCandidate));
						}
					}
				}
			}
		}
		return Collections.unmodifiableList(moves);
	}
	
	@Override
	public Pawn movePiece(final Move move) {
		return new Pawn(move.getDestinationCoordinate(), move.getMovedPiece().getPieceCol());
	}

	
	@Override
	public String toString() {
		return Piece.PieceType.PAWN.toString();
	}
	
	public Piece getPromotionPiece() {
		return new Queen(this.piecePos, this.pieceColor, false);
	}

}
