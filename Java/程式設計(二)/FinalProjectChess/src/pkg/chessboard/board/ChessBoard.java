package pkg.chessboard.board;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import pkg.chessboard.ColorOfPieces;
import pkg.chessboard.pieces.Bishop;
import pkg.chessboard.pieces.King;
import pkg.chessboard.pieces.Knight;
import pkg.chessboard.pieces.Pawn;
import pkg.chessboard.pieces.Piece;
import pkg.chessboard.pieces.Queen;
import pkg.chessboard.pieces.Rook;
import pkg.chessboard.player.BlackPlayer;
import pkg.chessboard.player.Player;
import pkg.chessboard.player.WhitePlayer;

public class ChessBoard {
	
	private final List<Square> gameBoard;
	private final Collection<Piece> whitePieces;
	private final Collection<Piece> blackPieces;
	
	private final BlackPlayer blackPlayer;
	private final WhitePlayer whitePlayer;
	private final Player currentPlayer;
	
	private final Pawn enPassantPawn;
	
	private ChessBoard(final Builder builder) {
		this.gameBoard = createGameBoard(builder);
		this.blackPieces = calculateActivePieces(this.gameBoard, ColorOfPieces.BLACK);
		this.whitePieces = calculateActivePieces(this.gameBoard, ColorOfPieces.WHITE);
		this.enPassantPawn = builder.enPassantPawn;
		final Collection<Move> blackStandardLegalMoves = calculateLegalMoves(this.blackPieces);
		final Collection<Move> whiteStandardLegalMoves = calculateLegalMoves(this.whitePieces);
		
		this.blackPlayer = new BlackPlayer(this, whiteStandardLegalMoves, blackStandardLegalMoves);
		this.whitePlayer = new WhitePlayer(this, whiteStandardLegalMoves, blackStandardLegalMoves);
		this.currentPlayer = builder.nextMoveMaker.choosePlayer(this.whitePlayer, this.blackPlayer);
	}
	
	@Override
	public String toString() {
		final StringBuilder builder = new StringBuilder();
		for(int i = 0; i < BoardUtils.NUM_SQUARES; i++) {
			final String tileText = this.gameBoard.get(i).toString();
			builder.append(String.format("%3s", tileText));
			if((i + 1) % BoardUtils.NUM_RANKS == 0) {
				builder.append("\n");
			}
		}
		return builder.toString();
	}

	private Collection<Move> calculateLegalMoves(Collection<Piece> pieces) {
		// TODO Auto-generated method stub
		final List<Move> legalMoves = new ArrayList<>();
		for(final Piece piece: pieces) {
			legalMoves.addAll(piece.calculateMoves(this));
		}
		
		return Collections.unmodifiableList(legalMoves);
	}

	private static Collection<Piece> calculateActivePieces(final List<Square> gameBoard, final ColorOfPieces alliance) {
		// TODO Auto-generated method stub
		final List<Piece> activePieces = new ArrayList<>();
		
		for(final Square tile: gameBoard) {
			if(tile.squareOccupied()) {
				final Piece piece = tile.getPiece();
				if(piece.getPieceCol() == alliance) {
					activePieces.add(piece);
				}
			}
		}
		return Collections.unmodifiableList(activePieces);
	}

	public Square getSquare(final int tileCoordinate){
		return gameBoard.get(tileCoordinate);
	}
	
	private static List<Square> createGameBoard(final Builder builder){
		final List<Square> tiles =  new ArrayList<>();
		for(int i = 0; i < BoardUtils.NUM_SQUARES; i++) {
			final Square tile = Square.createSquare(i, builder.boardConfig.get(i));
			tiles.add(tile);
		}
		
		return Collections.unmodifiableList(tiles);
	}
	
	public static ChessBoard createStartingBoard() {
		final Builder builder = new Builder();
		// Black
		builder.setPiece(new Rook(0, ColorOfPieces.BLACK));
		builder.setPiece(new Knight(1, ColorOfPieces.BLACK));
		builder.setPiece(new Bishop(2, ColorOfPieces.BLACK));
		builder.setPiece(new Queen(3, ColorOfPieces.BLACK));
		builder.setPiece(new King(4, ColorOfPieces.BLACK));
		builder.setPiece(new Bishop(5, ColorOfPieces.BLACK));
		builder.setPiece(new Knight(6, ColorOfPieces.BLACK));
		builder.setPiece(new Rook(7, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(8, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(9, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(10, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(11, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(12, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(13, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(14, ColorOfPieces.BLACK));
		builder.setPiece(new Pawn(15, ColorOfPieces.BLACK));
		
		// White
		builder.setPiece(new Pawn(48, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(49, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(50, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(51, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(52, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(53, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(54, ColorOfPieces.WHITE));
		builder.setPiece(new Pawn(55, ColorOfPieces.WHITE));
		builder.setPiece(new Rook(56, ColorOfPieces.WHITE));
		builder.setPiece(new Knight(57, ColorOfPieces.WHITE));
		builder.setPiece(new Bishop(58, ColorOfPieces.WHITE));
		builder.setPiece(new Queen(59, ColorOfPieces.WHITE));
		builder.setPiece(new King(60, ColorOfPieces.WHITE));
		builder.setPiece(new Bishop(61, ColorOfPieces.WHITE));
		builder.setPiece(new Knight(62, ColorOfPieces.WHITE));
		builder.setPiece(new Rook(63, ColorOfPieces.WHITE));
		
		//White makes first move
		builder.setMoveMaker(ColorOfPieces.WHITE);
		
		return builder.build();
	}
	
	public static class Builder {
		
		Map<Integer, Piece> boardConfig;
		ColorOfPieces nextMoveMaker;
		Pawn enPassantPawn;
		
		public Builder() {
			this.boardConfig = new HashMap<>();
		}
		
		public Builder setPiece(final Piece piece) {
			this.boardConfig.put(piece.getPiecePos(), piece);
			return this;
		}
		
		public Builder setMoveMaker(final ColorOfPieces nextMoveMaker) {
			this.nextMoveMaker = nextMoveMaker;
			return this;
		}
		
		public ChessBoard build() {
			return new ChessBoard(this);
		}

		public void setEnPassantPawn(Pawn jumpedPawn) {
			// TODO Auto-generated method stub
			this.enPassantPawn = jumpedPawn;
		}
		
	}
	
	public Player whitePlayer() {
		return this.whitePlayer;
	}

	public Player blackPlayer() {
		return this.blackPlayer;
	}

	public Player currentPlayer() {
		return this.currentPlayer;
	}
	
	public Collection<Piece> getBlackPieces() {
		return this.blackPieces;
	}

	public Collection<Piece> getWhitePieces() {
		return this.whitePieces;
	}
	
	public Pawn getEnPassantPawn() {
		return this.enPassantPawn;
	}

	
	public Iterable<Move> getAllMoves() {
		final List<Move> concatenatedMoves = new ArrayList<>();
		concatenatedMoves.addAll(this.whitePlayer.getLegalMoves());
		concatenatedMoves.addAll(this.blackPlayer.getLegalMoves());
		return Collections.unmodifiableList(concatenatedMoves);
	}

	
}
