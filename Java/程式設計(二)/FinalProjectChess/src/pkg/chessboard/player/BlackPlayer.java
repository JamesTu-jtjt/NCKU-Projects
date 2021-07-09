package pkg.chessboard.player;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import pkg.chessboard.ColorOfPieces;
import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.Move;
import pkg.chessboard.board.Square;
import pkg.chessboard.pieces.Piece;
import pkg.chessboard.pieces.Rook;

public class BlackPlayer extends Player{

	public BlackPlayer(final ChessBoard board, 
					final Collection<Move> whiteStandardLegalMoves,
					final Collection<Move> blackStandardLegalMoves) {
		// TODO Auto-generated constructor stub
		super(board, blackStandardLegalMoves, whiteStandardLegalMoves);
	}

	@Override
	public Collection<Piece> getActivePieces() {
		// TODO Auto-generated method stub
		return this.board.getBlackPieces();
	}

	@Override
	public ColorOfPieces getCol() {
		// TODO Auto-generated method stub
		return ColorOfPieces.BLACK;
	}

	@Override
	public Player getOtherPlayer() {
		// TODO Auto-generated method stub
		return this.board.whitePlayer();
	}

	@Override
	public Collection<Move> calculateCastles(final Collection<Move> playerLegals, 
												final Collection<Move> opponentLegals) {
		// TODO Auto-generated method stub
		final List<Move> castles = new ArrayList<>();
		
		if(this.playerK.isFirstMove() && !this.isInCheck()) {
			// black king-side castle availability
			if(!this.board.getSquare(5).squareOccupied() && !this.board.getSquare(6).squareOccupied()) {
				final Square rookTile = this.board.getSquare(7);
				if(rookTile.squareOccupied() && rookTile.getPiece().isFirstMove() && 
						Player.calculateAttacksOnSquare(4, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(5, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(6, opponentLegals).isEmpty() &&
						rookTile.getPiece().getPieceType().isRook()) {
					castles.add(new Move.ShortCastle(this.board, this.playerK, 6, 
							(Rook)rookTile.getPiece(), rookTile.getSquareCoordinate(), 5));
				}
			}
			// black queen-side castle availability
			if(!this.board.getSquare(1).squareOccupied() && 
				!this.board.getSquare(2).squareOccupied() && 
				!this.board.getSquare(3).squareOccupied()) {
				final Square rookTile = this.board.getSquare(0);
				if(rookTile.squareOccupied() && rookTile.getPiece().isFirstMove() && 
						Player.calculateAttacksOnSquare(2, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(3, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(4, opponentLegals).isEmpty() &&
						rookTile.getPiece().getPieceType().isRook()) {
					castles.add(new Move.LongCastle(this.board, this.playerK, 2, 
							(Rook)rookTile.getPiece(), rookTile.getSquareCoordinate(), 3));
				}
			}
		}
		return Collections.unmodifiableList(castles);
	}

}
