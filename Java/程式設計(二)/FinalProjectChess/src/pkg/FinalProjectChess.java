package pkg;

import pkg.chessboard.board.ChessBoard;
import pkg.gui.MainUI;

public class FinalProjectChess {

	public static void main(String[] args) {
		ChessBoard board = ChessBoard.createStartingBoard();
		
		System.out.println(board);
		
		MainUI startGUI = new MainUI();
	}
}
