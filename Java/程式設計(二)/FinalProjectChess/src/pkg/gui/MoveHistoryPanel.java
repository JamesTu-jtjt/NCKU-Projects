package pkg.gui;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.Move;
import pkg.gui.MainUI.MoveLog;

public class MoveHistoryPanel extends JPanel{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private static final Dimension MOVE_HISTORY_DIMENSION = new Dimension(100, 400);
	private final DataModel model;
	private final JScrollPane scrollPane;

	MoveHistoryPanel(){
		this.setLayout(new BorderLayout());
		this.model = new DataModel();
		final JTable table = new JTable(model);
		table.setRowHeight(15);
		this.scrollPane = new JScrollPane(table);
		scrollPane.setColumnHeaderView(table.getTableHeader());
		scrollPane.setPreferredSize(MOVE_HISTORY_DIMENSION);
		this.add(scrollPane, BorderLayout.CENTER);
		this.setVisible(true);
	}
	

	void redo(final ChessBoard board, final MoveLog history) {
		
		int currentRow = 0;
		this.model.clear();
		for(final Move move : history.getMoves()) {
			final String moveText = move.toString();
			if(move.getMovedPiece().getPieceCol().isWhite()) {
				this.model.setValueAt(moveText, currentRow, 0);
			}else if(move.getMovedPiece().getPieceCol().isBlack()) {
				this.model.setValueAt(moveText, currentRow, 1);
				currentRow++;
			}
		}
		
		if(history.getMoves().size()>0) {
			final Move lastMove = history.getMoves().get(history.size() - 1);
			final String moveText = lastMove.toString();
			
			if(lastMove.getMovedPiece().getPieceCol().isWhite()) {
				this.model.setValueAt(moveText + calculateCheckAndMateHash(board), currentRow, 0);
			} else if(lastMove.getMovedPiece().getPieceCol().isBlack()) {
				this.model.setValueAt(moveText + calculateCheckAndMateHash(board), currentRow - 1, 1);
			}
		}
		
		final JScrollBar vertical = scrollPane.getVerticalScrollBar();
		vertical.setValue(vertical.getMaximum());
	}

	private String calculateCheckAndMateHash(final ChessBoard board) {
		if(board.currentPlayer().checkmate()) {
			System.out.println("CheckMate! Game Over!");
			if(board.currentPlayer().getCol().isBlack()) {
				System.out.println("White Wins!");
			}else {
				System.out.println("Black Wins!");
			}
			return "#";
		}else if(board.currentPlayer().isInCheck()) {
			return "+";
		}else if(board.currentPlayer().stalemate()) {
			System.out.println("StaleMate! Game Over!");
			System.out.println("Draw!");
		}
		return "";
		
	}
	
	public void clear() {
		this.model.clear();
	}

	private static class DataModel extends DefaultTableModel{
		
		/**
		 * 
		 */
		private static final long serialVersionUID = 1L;
		private final List<Row> values;
		private static final String[] NAMES = {"White", "Black"};
		
		DataModel(){
			this.values = new ArrayList<>();
		}
		
		public void clear() {
			this.values.clear();
			setRowCount(0);
		}
		
		@Override
		public int getRowCount() {
			if(this.values == null) {
				return 0;
			}
			return this.values.size();
		}
		
		@Override
		public int getColumnCount() {
			return NAMES.length;
		}
		
		@Override
		public Object getValueAt(final int row, final int column) {
			final Row currentRow = this.values.get(row);
			if(column == 0) {
				return currentRow.getWhiteMove();
			}else if(column == 1) {
				return currentRow.getBlackMove();
			}
			return null;
		}
		
		@Override 
		public void setValueAt(final Object value, final int row, final int column) {
			final Row currentRow;
			if(this.values.size() <= row) {
				currentRow = new Row();
				this.values.add(currentRow);
			}else {
				currentRow = this.values.get(row);
			}
			if(column == 0) {
				currentRow.setWhiteMove((String) value);
				fireTableRowsInserted(row, row);
			}else if(column == 1) {
				currentRow.setBlackMove((String) value);
				fireTableCellUpdated(row, column);
			}
		}
		
		@Override 
		public Class<?> getColumnClass(final int column){
			return Move.class;
		}
		
		@Override
		public String getColumnName(final int column) {
			return NAMES[column];
		}
		
	}
	
	private static class Row{
		private String whiteMove;
		private String blackMove;
		
		Row(){
		}
		
		public String getWhiteMove() {
			return this.whiteMove;
		}
		
		public String getBlackMove() {
			return this.blackMove;
		}
		
		public void setWhiteMove(final String move) {
			this.whiteMove = move;
		}
		
		public void setBlackMove(final String move) {
			this.blackMove = move;
		}
		
	}
	
}
