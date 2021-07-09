package pkg.chessboard.board;

import pkg.chessboard.board.ChessBoard.Builder;
import pkg.chessboard.pieces.Pawn;
import pkg.chessboard.pieces.Piece;
import pkg.chessboard.pieces.Rook;

public abstract class Move {

	protected final ChessBoard board;
	protected final Piece movedPiece;
	protected final int destinationCoordinate;
	protected final boolean firstMove;
	
	public static final Move NULL_MOVE = new NullMove();
	
	Move(final ChessBoard board,
			final Piece movedPiece, 
			final int destinationCoordinate) {
		this.board = board;
		this.movedPiece = movedPiece;
		this.destinationCoordinate = destinationCoordinate;
		this.firstMove = movedPiece.isFirstMove();
	}
	private Move(final ChessBoard board, final int destinationCoordinate) {
		this.board = board;
		this.movedPiece = null;
		this.destinationCoordinate = destinationCoordinate;
		this.firstMove = false;
	}
	
	
	@Override 
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + this.destinationCoordinate;
		result = prime * result + this.movedPiece.hashCode();
		result = prime * result + this.movedPiece.getPiecePos();
		result = result + (firstMove ? 1 : 0);
		return result;
	}
	
	@Override 
	public boolean equals(final Object other) {
		if(this == other) {
			return true;
		}
		if(!(other instanceof Move)) {
			return false;
		}
		final Move otherMove = (Move) other;
		return getCurrentCoordinate() == otherMove.getCurrentCoordinate() &&
				getDestinationCoordinate() == otherMove.getDestinationCoordinate() &&
				getMovedPiece().equals(otherMove.getMovedPiece());
	}
	
	public ChessBoard getBoard() {
		return this.board;
	}
	
	public int getCurrentCoordinate() {
		return this.movedPiece.getPiecePos();
	}
	
	public int getDestinationCoordinate() {
		return this.destinationCoordinate;
	}
	
	public Piece getMovedPiece() {
		return this.movedPiece;
	}
	
	public boolean isCapture() {
		return false;
	}
	
	public boolean isCastlingMove() {
		return false;
	}
	
	public Piece getCapturedPiece() {
		return null;
	}
	
	
	public ChessBoard execute() {
		final ChessBoard.Builder builder = new Builder();
		// Setting pieces other than moved Piece
		for(final Piece piece : this.board.currentPlayer().getActivePieces()) {
			if(!this.movedPiece.equals(piece)) {
				builder.setPiece(piece);
			}
		}
		for(final Piece piece : this.board.currentPlayer().getOtherPlayer().getActivePieces()) {
			builder.setPiece(piece);
		}
		//move moved piece! 
		builder.setPiece(this.movedPiece.movePiece(this));
		builder.setMoveMaker(this.board.currentPlayer().getOtherPlayer().getCol());
		return builder.build();
	}
	
	
	public static final class PositionalMove extends Move{

		public PositionalMove(final ChessBoard board, final Piece movedPiece, final int destinationCoordinate) {
			super(board, movedPiece, destinationCoordinate);
			// TODO Auto-generated constructor stub
		}
		
		@Override
		public boolean equals(final Object other) {
			return  this == other || other instanceof PositionalMove && super.equals(other);
		}
		
		@Override
		public String toString() {
			return movedPiece.getPieceType().toString() + BoardUtils.getPositionCoordinate(this.destinationCoordinate);
		}
		
	}
	
	public static class CaptureMove extends Move{
		
		final Piece capturedPiece;
		
		public CaptureMove(final ChessBoard board, 
					final Piece movedPiece, 
					final int destinationCoordinate, 
					final Piece capturedPiece) {
			super(board, movedPiece, destinationCoordinate);
			this.capturedPiece = capturedPiece;
			// TODO Auto-generated constructor stub
		}
		
		@Override
		public int hashCode() {
			return this.capturedPiece.hashCode() + super.hashCode();
		}
		
		@Override
		public boolean equals(final Object other) {
			if(this == other) {
				return true;
			}
			if(!(other instanceof CaptureMove)) {
				return false;
			}
			final CaptureMove otherCaptureMove = (CaptureMove) other;
			return super.equals(otherCaptureMove) && getCapturedPiece().equals(otherCaptureMove.getCapturedPiece());
		}
		
		@Override
		public boolean isCapture() {
			return true;
		}
		
		@Override
		public Piece getCapturedPiece() {
			return this.capturedPiece;
		}
		
		@Override
		public String toString() {
			return movedPiece.getPieceType().toString() + "x" + BoardUtils.getPositionCoordinate(this.destinationCoordinate);
		}
	}
	
	public static final class MajorCaptureMove extends CaptureMove {
		
		public MajorCaptureMove(final ChessBoard board, 
					final Piece movedPiece, 
					final int destinationCoordinate, 
					final Piece capturedPiece) {
			super(board, movedPiece, destinationCoordinate, capturedPiece);
		}
		
		@Override
		public boolean equals(final Object other) {
			return this == other || other instanceof MajorCaptureMove || super.equals(other);
		}
		
		@Override
		public String toString() {
			return movedPiece.getPieceType().toString() + "x" + BoardUtils.getPositionCoordinate(this.destinationCoordinate);
		}
	}
	
	public static class PawnMove extends Move{

		public PawnMove(final ChessBoard board, final Piece movedPiece, final int destinationCoordinate) {
			super(board, movedPiece, destinationCoordinate);
		}
		
		@Override
		public boolean equals(final Object other) {
			return this == other || other instanceof PawnMove || super.equals(other);
		}
		
		@Override 
		public String toString() {
			return BoardUtils.getPositionCoordinate(this.destinationCoordinate);
		}
	}
	
	public static class PawnCaptureMove extends CaptureMove{

		public PawnCaptureMove(final ChessBoard board, 
						final Piece movedPiece, 
						final int destinationCoordinate, 
						final Piece capturedPiece) {
			super(board, movedPiece, destinationCoordinate, capturedPiece);
		}
		
		@Override
		public boolean equals(final Object other) {
			return this == other || other instanceof PawnCaptureMove || super.equals(other);
		}
		
		@Override
		public String toString() {
			return BoardUtils.getPositionCoordinate(this.movedPiece.getPiecePos()).substring(0, 1) + "x" + 
					BoardUtils.getPositionCoordinate(this.destinationCoordinate);
		}
	}
	
	public static final class EnPassantMove extends PawnCaptureMove{

		public EnPassantMove(final ChessBoard board, 
						final Piece movedPiece, 
						final int destinationCoordinate, 
						final Piece capturedPiece) {
			super(board, movedPiece, destinationCoordinate, capturedPiece);
			// TODO Auto-generated constructor stub
		}
		
		@Override
		public boolean equals(final Object other) {
			return this == other || other instanceof EnPassantMove || super.equals(other);
		}
		
		@Override
		public ChessBoard execute() {
			final Builder builder = new Builder();
			for(final Piece piece :this.board.currentPlayer().getActivePieces()) {
				if(!this.movedPiece.equals(piece)) {
					builder.setPiece(piece);
				}
			}
			for(final Piece piece : this.board.currentPlayer().getOtherPlayer().getActivePieces()) {
				if(!piece.equals(this.getCapturedPiece())) {
					builder.setPiece(piece);
				}
			}
			builder.setPiece(this.movedPiece.movePiece(this));
			builder.setMoveMaker(this.board.currentPlayer().getOtherPlayer().getCol());
			return builder.build();
		}
	}
	
	public static class PromotionMove extends Move{
		
		final Move wrappedMove;
		final Pawn promotedPawn;
		
		public PromotionMove(final Move wrappedMove) {
			super(wrappedMove.getBoard(), wrappedMove.getMovedPiece(), wrappedMove.getDestinationCoordinate());
			this.wrappedMove = wrappedMove;
			this.promotedPawn = (Pawn) wrappedMove.getMovedPiece();
		}
		
		@Override
        public int hashCode() {
            return wrappedMove.hashCode() + (31 * promotedPawn.hashCode());
        }

        @Override
        public boolean equals(final Object other) {
            return this == other || other instanceof PromotionMove && (super.equals(other));
        }
		
		@Override
		public ChessBoard execute() {
			
			final ChessBoard promotedBoard = this.wrappedMove.execute();
			final ChessBoard.Builder builder = new Builder();
			for(final Piece piece : promotedBoard.currentPlayer().getActivePieces()) {
				if(!this.promotedPawn.equals(piece)) {
					builder.setPiece(piece);
				}
			}
			for(final Piece piece : promotedBoard.currentPlayer().getOtherPlayer().getActivePieces()) {
				builder.setPiece(piece);
			}
			builder.setPiece(this.promotedPawn.getPromotionPiece().movePiece(this));
			builder.setMoveMaker(promotedBoard.currentPlayer().getCol());
			return builder.build();
		}
		
		@Override 
		public boolean isCapture() {
			return this.wrappedMove.isCapture();
		}
		
		@Override
		public Piece getCapturedPiece() {
			return this.wrappedMove.getCapturedPiece();
		}
		
		@Override
        public String toString() {
            return BoardUtils.getPositionCoordinate(this.movedPiece.getPiecePos()) + "-" +
                   BoardUtils.getPositionCoordinate(this.destinationCoordinate) + "=Q";
        }
		
	}
	
	public static final class PawnJumpMove extends PawnMove{

		public PawnJumpMove(final ChessBoard board, final Piece movedPiece, final int destinationCoordinate) {
			super(board, movedPiece, destinationCoordinate);
			// TODO Auto-generated constructor stub
		}
		
		@Override
        public boolean equals(final Object other) {
            return this == other || other instanceof PawnJumpMove && super.equals(other);
        }
		
		@Override 
		public ChessBoard execute() {
			final Builder builder = new Builder();
			for(final Piece piece : this.board.currentPlayer().getActivePieces()) {
				if(!this.movedPiece.equals(piece)) {
					builder.setPiece(piece);
				}
			}
			for(final Piece piece : this.board.currentPlayer().getOtherPlayer().getActivePieces()) {
				builder.setPiece(piece);
			}
			final Pawn jumpedPawn = (Pawn) this.movedPiece.movePiece(this);
			builder.setPiece(jumpedPawn);
			builder.setEnPassantPawn(jumpedPawn);
			builder.setMoveMaker(this.board.currentPlayer().getOtherPlayer().getCol());
			return builder.build();
		}
	}
	
	static abstract class CastlingMove extends Move{
		
		protected final Rook castleRook; 
		protected final int castleRookStart;
		protected final int castleRookDestination;

		public CastlingMove(final ChessBoard board, final Piece movedPiece, 
							final int destinationCoordinate, 
							final Rook castleRook, 
							final int castleRookStart, 
							final int castleRookDestination) {
			super(board, movedPiece, destinationCoordinate);
			this.castleRook = castleRook;
			this.castleRookStart = castleRookStart;
			this.castleRookDestination = castleRookDestination;
		}
		
		public Rook getCastleRook() {
			return this.castleRook;
		}
		
		@Override
		public boolean isCastlingMove() {
			return true;
		}
		
		@Override
		public ChessBoard execute() {
			final Builder builder = new Builder();
			for(final Piece piece : this.board.currentPlayer().getActivePieces()) {
				if(!this.movedPiece.equals(piece) && !this.castleRook.equals(piece)) {
					builder.setPiece(piece);
				}
			}
			for(final Piece piece : this.board.currentPlayer().getOtherPlayer().getActivePieces()) {
				builder.setPiece(piece);
			}
			builder.setPiece(this.movedPiece.movePiece(this));
			// TODO look into first move of normal pieces
			builder.setPiece(new Rook(this.castleRookDestination, this.castleRook.getPieceCol()));
			builder.setMoveMaker(this.board.currentPlayer().getOtherPlayer().getCol());
			// builder.setMoveTransition(this);
			return builder.build();
		}
		
		@Override 
		public int hashCode() {
			final int prime = 31;
			int result = super.hashCode();
			result = prime * result + this.castleRook.hashCode();
			result = prime * result + this.castleRookDestination;
			return result;
		}
		
		@Override 
		public boolean equals(final Object other) {
			if(this == other) {
				return true;
			}
			if(!(other instanceof CastlingMove)) {
				return false;
			}
			final CastlingMove otherMove = (CastlingMove) other;
			return super.equals(otherMove) && this.castleRook.equals(otherMove.getCastleRook());
		}
	}
	
	public static final class ShortCastle extends CastlingMove{

		public ShortCastle(final ChessBoard board, final Piece movedPiece, 
				final int destinationCoordinate, 
				final Rook castleRook, 
				final int castleRookStart, 
				final int castleRookDestination) {
			super(board, movedPiece, destinationCoordinate, castleRook, castleRookStart, castleRookDestination);
		}
		
		@Override
        public boolean equals(final Object other) {
            if (this == other) {
                return true;
            }
            if (!(other instanceof ShortCastle)) {
                return false;
            }
            final ShortCastle otherMove = (ShortCastle) other;
            return super.equals(otherMove) && this.castleRook.equals(otherMove.getCastleRook());
		}
		
		@Override
		public String toString() {
			return "O-O";
		}
	}
	
	public static final class LongCastle extends CastlingMove{

		public LongCastle(final ChessBoard board, final Piece movedPiece, 
				final int destinationCoordinate, 
				final Rook castleRook, 
				final int castleRookStart, 
				final int castleRookDestination) {
			super(board, movedPiece, destinationCoordinate, castleRook, castleRookStart, castleRookDestination);
		}
		
		@Override
        public boolean equals(final Object other) {
            if (this == other) {
                return true;
            }
            if (!(other instanceof LongCastle)) {
                return false;
            }
            final LongCastle otherMove = (LongCastle) other;
            return super.equals(otherMove) && this.castleRook.equals(otherMove.getCastleRook());
        }
		
		@Override
		public String toString() {
			return "O-O-O";
		}
	}
	
	public static final class NullMove extends Move{

		public NullMove() {
			super(null, -1);
			// TODO Auto-generated constructor stub
		}
		
		@Override
        public int getCurrentCoordinate() {
            return -1;
        }

        @Override
        public int getDestinationCoordinate() {
            return -1;
        }

        @Override
        public ChessBoard execute() {
            throw new RuntimeException("cannot execute null move!");
        }

        @Override
        public String toString() {
            return "Null Move";
        }
	}
	
	public static class MoveFactory{
		
		private MoveFactory() {
			throw new RuntimeException("Not instantiable");
		}
		
		public static Move getNullMove() {
            return NULL_MOVE;
        }
		
		public static Move createMove(final ChessBoard board, 
									final int currentCoordinate, 
									final int destinationCoordinate) {
			for(final Move move : board.getAllMoves()) {
				if(move.getCurrentCoordinate() == currentCoordinate && 
					move.getDestinationCoordinate() == destinationCoordinate){
						return move;
					}
			}
			return NULL_MOVE;
		}
	}

	
}
