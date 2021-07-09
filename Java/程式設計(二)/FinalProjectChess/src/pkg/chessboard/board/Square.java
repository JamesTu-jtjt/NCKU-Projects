package pkg.chessboard.board;

import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

import pkg.chessboard.pieces.Piece;

public abstract class Square {
	
	protected final int squareCoordinate;
	
	private static final Map<Integer, EmptySquare> EMPTY_TILES_CACHE = createAllPossibleEmptyTiles();
	
	public static Square createSquare(final int tileCoordinate, final Piece piece) {
		return piece != null ? new OccupiedSquare(tileCoordinate, piece) : EMPTY_TILES_CACHE.get(tileCoordinate);
	}
	
	private Square(final int tileCoordinate){
		this.squareCoordinate = tileCoordinate;
		
	}
	
	private static Map<Integer, EmptySquare> createAllPossibleEmptyTiles(){
		
		final Map<Integer, EmptySquare> emptyTileMap = new HashMap<>();
		
		for(int i = 0; i < BoardUtils.NUM_SQUARES; i++) {
			emptyTileMap.put(i, new EmptySquare(i));
		}
		
		
		return Collections.unmodifiableMap(emptyTileMap);
		
	}

	public abstract boolean squareOccupied();
	
	public abstract Piece getPiece();
	
	public static final class EmptySquare extends Square{
		
		private EmptySquare(final int coordinate){
			super(coordinate);
		}
		
		@Override
		public String toString() {
			return "-";
		}
		
		@Override
		public boolean squareOccupied() {
			return false;
		}
		
		@Override
		public Piece getPiece() {
			return null;
		}
		
	}
	
	public static final class OccupiedSquare extends Square {
		
		private final Piece pieceOnSquare;
		
		private OccupiedSquare(int tileCoordinate, final Piece pieceOnTile){
			super(tileCoordinate);
			this.pieceOnSquare = pieceOnTile;
		}
		
		@Override
		public String toString() {
			return getPiece().getPieceCol().isBlack() ? getPiece().toString().toLowerCase():
				getPiece().toString();
		}
		
		@Override
		public boolean squareOccupied() {
			return true;
		}
		
		@Override
		public Piece getPiece() {
			return this.pieceOnSquare;
		}
	}

	public int getSquareCoordinate() {
		// TODO Auto-generated method stub
		return this.squareCoordinate;
	}
	
	
}
