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

public class WhitePlayer extends Player{

	public WhitePlayer(final ChessBoard board, 
					final Collection<Move> whiteStandardLegalMoves,
					final Collection<Move> blackStandardLegalMoves) {
		// TODO Auto-generated constructor stub
		super(board, whiteStandardLegalMoves, blackStandardLegalMoves);
	}

	@Override
	public Collection<Piece> getActivePieces() {
		// TODO Auto-generated method stub
		return this.board.getWhitePieces();
	}

	@Override
	public ColorOfPieces getCol() {
		// TODO Auto-generated method stub
		return ColorOfPieces.WHITE;
	}

	@Override
	public Player getOtherPlayer() {
		// TODO Auto-generated method stub
		return this.board.blackPlayer();
	}

	@Override
	public Collection<Move> calculateCastles(final Collection<Move> playerLegals, 
												final Collection<Move> opponentLegals) {
		// TODO Auto-generated method stub
		final List<Move> castles = new ArrayList<>();
		
		if(this.playerK.isFirstMove() && !this.isInCheck()) {
			//white king-side castle availability
			if(!this.board.getSquare(61).squareOccupied() && !this.board.getSquare(62).squareOccupied()) {
				final Square rookTile = this.board.getSquare(63);
				if(rookTile.squareOccupied() && rookTile.getPiece().isFirstMove() && 
						Player.calculateAttacksOnSquare(60, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(61, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(62, opponentLegals).isEmpty() &&
						rookTile.getPiece().getPieceType().isRook()) {
					castles.add(new Move.ShortCastle(this.board, this.playerK, 62, 
							(Rook)rookTile.getPiece(), rookTile.getSquareCoordinate(), 61));
				}
			}
			// white queen-side castle availability
			if(!this.board.getSquare(59).squareOccupied() && 
				!this.board.getSquare(58).squareOccupied() && 
				!this.board.getSquare(57).squareOccupied()) {
				final Square rookTile = this.board.getSquare(56);
				if(rookTile.squareOccupied() && rookTile.getPiece().isFirstMove() && 
						Player.calculateAttacksOnSquare(60, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(59, opponentLegals).isEmpty() &&
						Player.calculateAttacksOnSquare(58, opponentLegals).isEmpty() &&
						rookTile.getPiece().getPieceType().isRook()) {
					castles.add(new Move.LongCastle(this.board, this.playerK, 58, 
							(Rook)rookTile.getPiece(), rookTile.getSquareCoordinate(), 59));
				}
			}
		}
		return Collections.unmodifiableList(castles);
	}

}
