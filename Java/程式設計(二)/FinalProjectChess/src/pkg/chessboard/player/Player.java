package pkg.chessboard.player;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import pkg.chessboard.ColorOfPieces;
import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.Move;
import pkg.chessboard.board.MoveStatus;
import pkg.chessboard.board.MoveUpdate;
import pkg.chessboard.pieces.King;
import pkg.chessboard.pieces.Piece;

public abstract class Player {

	protected final ChessBoard board;
	protected final King playerK;
	protected final Collection<Move> legalMoves;
	private final boolean inCheck;
	
	Player(final ChessBoard board, 
			final Collection<Move> legalMoves, 
			final Collection<Move> opponentMoves){
		
		final List<Move> concat = new ArrayList<>();
		this.board = board;
		this.playerK = establishK();
		concat.addAll(legalMoves);
		concat.addAll(calculateCastles(legalMoves, opponentMoves));
		this.legalMoves = concat;
		this.inCheck = !Player.calculateAttacksOnSquare(this.playerK.getPiecePos(), opponentMoves).isEmpty();
		
	}
	
	public King getPlayerK() {
		return this.playerK;
	}
	
	public Collection<Move> getLegalMoves(){
		return this.legalMoves;
	}

	protected static Collection<Move> calculateAttacksOnSquare(int piecePosition, Collection<Move> moves){
		final List<Move> attackMoves = new ArrayList<>();
		for(final Move move: moves) {
			if(piecePosition == move.getDestinationCoordinate()) {
				attackMoves.add(move);
			}
		}
		return Collections.unmodifiableList(attackMoves);
	}

	private King establishK() {
		for(final Piece piece: getActivePieces()) {
			if(piece.getPieceType().isKing()) {
				return (King) piece;
			}
		}
		throw new RuntimeException("No King! Should not reach this code. ");
	}
	
	public boolean isMoveLegal(final Move move) {
		return this.legalMoves.contains(move);
	}
	
	public boolean isInCheck() {
		return this.inCheck;
	}
	
	public boolean checkmate() {
		return this.inCheck && !hasEscapeMoves();
	}
	
	public boolean stalemate() {
		return !this.inCheck && !hasEscapeMoves();
	}
	
	protected boolean hasEscapeMoves() {
		for(final Move move: this.legalMoves) {
			final MoveUpdate transition = makeMove(move);
			if(transition.getMoveStatus().isDone()) {
				return true;
			}
		}
		return false;
	}
	
	public boolean isCastled() {
		return false;
	}
	
	public Collection<Move> showLegalMoves(){
		
		final Collection<Move> possibleMoves = new ArrayList<>();
		
		for(final Move move : this.getLegalMoves()) {
			
			final ChessBoard transitionBoard = move.execute();
			
			final Collection<Move> kingAttacks = Player.calculateAttacksOnSquare(transitionBoard.currentPlayer().getOtherPlayer().getPlayerK().getPiecePos(),
					transitionBoard.currentPlayer().getLegalMoves());
			
			if(!kingAttacks.isEmpty()) {
				possibleMoves.add(move);
			}
			
		}
		return possibleMoves;
	}
	
	public MoveUpdate makeMove(final Move move) {
		
		if(!isMoveLegal(move)) {
			return new MoveUpdate(this.board, move, MoveStatus.ILLEGAL_MOVE);
		}
		
		final ChessBoard transitionBoard = move.execute();
		
		final Collection<Move> kingAttacks = Player.calculateAttacksOnSquare(transitionBoard.currentPlayer().getOtherPlayer().getPlayerK().getPiecePos(),
				transitionBoard.currentPlayer().getLegalMoves());
		
		if(!kingAttacks.isEmpty()) {
			return new MoveUpdate(this.board, move, MoveStatus.ILLEGAL_MOVE);
		}
		
		return new MoveUpdate(transitionBoard, move, MoveStatus.DONE);
	}


	public abstract Collection<Piece> getActivePieces();
	public abstract ColorOfPieces getCol();
	public abstract Player getOtherPlayer();
	public abstract Collection<Move> calculateCastles(Collection<Move> playerLegals, Collection<Move> opponentLegals);
	
	
	
}
