package pkg.chessboard.pieces;

import java.util.Collection;
import pkg.chessboard.ColorOfPieces;
import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.Move;

public abstract class Piece {
	
	protected final int piecePos;
	protected final ColorOfPieces pieceColor;
	protected final boolean isFirstMove;
	protected final PieceType pieceType;
	private final int cachedHashCode;
	
	Piece(final PieceType pieceType, 
			final int piecePos, 
			final ColorOfPieces pieceCol, 
			final boolean firstMove){
		this.pieceType = pieceType;
		this.pieceColor = pieceCol;
		this.piecePos = piecePos;
		this.isFirstMove = firstMove;
		this.cachedHashCode = computedHashCode();
	}
	
	private int computedHashCode() {
		int result = pieceType.hashCode();
		result = 31 * result + pieceColor.hashCode();
		result = 31 * result + piecePos;
		result = 31 * result + (isFirstMove ? 1 : 0);
		return result;
	}

	@Override
	public boolean equals(final Object other) {
		if(this == other) {
			return true;
		}
		if(!(other instanceof Piece)) {
			return false;
		}
		final Piece otherPiece = (Piece) other;
		return piecePos == otherPiece.getPiecePos() && pieceType == otherPiece.getPieceType() && 
				pieceColor == otherPiece.getPieceCol() && isFirstMove == otherPiece.isFirstMove;
	}
	
	@Override
	public int hashCode() {
		return this.cachedHashCode;
	}
	
	public int getPiecePos() {
		return this.piecePos;
	}
	
	public ColorOfPieces getPieceCol() {
		return this.pieceColor;
	}
	
	public boolean isFirstMove() {
		return this.isFirstMove;
	}
	
	public PieceType getPieceType() {
		return this.pieceType;
	}
	
	public int getPieceVal() {
		return this.pieceType.getPieceVal();
	}

	
	public abstract Collection<Move> calculateMoves(final ChessBoard board);
	
	public abstract Piece movePiece(Move move);
	
	public enum PieceType {
		
		PAWN("P", 1) {
			@Override
			public boolean isKing() {
				// TODO Auto-generated method stub
				return false;
			}

			@Override
			public boolean isRook() {
				// TODO Auto-generated method stub
				return false;
			}
		},
		KNIGHT("N", 3) {
			@Override
			public boolean isKing() {
				// TODO Auto-generated method stub
				return false;
			}

			@Override
			public boolean isRook() {
				// TODO Auto-generated method stub
				return false;
			}
		},
		BISHOP("B", 3) {
			@Override
			public boolean isKing() {
				// TODO Auto-generated method stub
				return false;
			}

			@Override
			public boolean isRook() {
				// TODO Auto-generated method stub
				return false;
			}
		},
		ROOK("R", 5) {
			@Override
			public boolean isKing() {
				// TODO Auto-generated method stub
				return false;
			}

			@Override
			public boolean isRook() {
				// TODO Auto-generated method stub
				return true;
			}
		},
		QUEEN("Q", 9) {
			@Override
			public boolean isKing() {
				// TODO Auto-generated method stub
				return false;
			}

			@Override
			public boolean isRook() {
				// TODO Auto-generated method stub
				return false;
			}
		},
		KING("K", 0) {
			@Override
			public boolean isKing() {
				// TODO Auto-generated method stub
				return true;
			}

			@Override
			public boolean isRook() {
				// TODO Auto-generated method stub
				return false;
			}
		};
		
		private String pieceName;
		private int pieceValue;
		
		PieceType(final String pieceName, final int pieceValue) {
			this.pieceName = pieceName;
			this.pieceValue = pieceValue;
		}

		@Override
		public String toString() {
			return this.pieceName;
		}
		
		public int getPieceVal() {
			return this.pieceValue;
		}

		public abstract boolean isKing() ;

		public abstract boolean isRook();
	}

	
}
