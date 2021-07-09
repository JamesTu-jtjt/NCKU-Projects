package pkg.gui;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.SwingUtilities;

import pkg.chessboard.board.ChessBoard;
import pkg.chessboard.board.BoardUtils;
import pkg.chessboard.board.Move;
import pkg.chessboard.board.MoveUpdate;
import pkg.chessboard.board.Square;
import pkg.chessboard.pieces.Piece;

public class MainUI {

	private final JFrame gameFrame;
	private MoveHistoryPanel moveHistoryPanel;
	private CapturedPiecesPanel capturedPiecesPanel;
	private BoardPanel boardPanel;
	private MoveLog moveLog;
	
	private ChessBoard chessBoard;
	
	private Square sourceSquare = null;
	private Square destinationSquare = null;
	private Piece movedPiece = null;
	private BoardDirection boardDirection;
	
	private boolean highlightLegalMoves;
	
	private final static Dimension OUTER_FRAME_DIMENSION = new Dimension(600, 500);
	private static final Dimension BOARD_PANEL_DIMENSION = new Dimension(400, 350);
	public static final Dimension SQUARE_PANEL_DIMENSION = new Dimension(10, 10);
	
	public static final Color lightSquare = new Color(150, 150, 150);
	public static final Color darkSquare = new Color(0, 0, 100);
	
	public MainUI() {
		this.gameFrame = new JFrame("2PlayerChessGUI"); 
		this.gameFrame.setLayout(new BorderLayout());
		final JMenuBar tableMenuBar = createTableMenuBar();
		this.gameFrame.setJMenuBar(tableMenuBar);
		this.gameFrame.setSize(OUTER_FRAME_DIMENSION);
		this.moveHistoryPanel = new MoveHistoryPanel();
		this.capturedPiecesPanel = new CapturedPiecesPanel();
		this.chessBoard = ChessBoard.createStartingBoard();
		this.boardPanel = new BoardPanel();
		this.moveLog = new MoveLog();
		this.boardDirection = BoardDirection.NORMAL;
		this.highlightLegalMoves = false;
		this.gameFrame.add(this.moveHistoryPanel, BorderLayout.EAST);
		this.gameFrame.add(this.capturedPiecesPanel, BorderLayout.WEST);
		this.gameFrame.add(this.boardPanel, BorderLayout.CENTER);
		this.gameFrame.setVisible(true);
	}
	
	public MainUI get() {
        return this;
    }

    private MoveLog getMoveLog() {
        return this.moveLog;
    }

    private BoardPanel getBoardPanel() {
        return this.boardPanel;
    }

    private MoveHistoryPanel getGameHistoryPanel() {
        return this.moveHistoryPanel;
    }
    
    private CapturedPiecesPanel getCapturedPiecesPanel() {
		// TODO Auto-generated method stub
		return this.capturedPiecesPanel;
	}
    
	
	private JMenuBar createTableMenuBar() {
		final JMenuBar tableMenuBar = new JMenuBar();
		tableMenuBar.add(createOptionsMenu());
		return tableMenuBar;
	}

	private JMenu createOptionsMenu() {
		
		final JMenu optionsMenu = new JMenu("Options");
		final JMenuItem flipBoardMenuItem = new JMenuItem("Flip Board");
		flipBoardMenuItem.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				boardDirection = boardDirection.opposite();
				boardPanel.drawBoard(chessBoard);
			}
		});
		optionsMenu.add(flipBoardMenuItem);
		
		optionsMenu.addSeparator();
		
		final JCheckBoxMenuItem legalMovesHighlighter = new JCheckBoxMenuItem("Highlight Legal Moves");
		legalMovesHighlighter.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				highlightLegalMoves = legalMovesHighlighter.isSelected();
			}
		});
		optionsMenu.add(legalMovesHighlighter);
		
		optionsMenu.addSeparator();
		
		final JMenuItem resetMenuItem = new JMenuItem("New Game", KeyEvent.VK_P);
		resetMenuItem.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				resetChessBoard();
			}
		});
		

        optionsMenu.add(resetMenuItem);
		
		optionsMenu.addSeparator();
		
		final JMenuItem exitMenuItem = new JMenuItem("Exit");
		exitMenuItem.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				System.exit(0);
			}
		});
		optionsMenu.add(exitMenuItem);
		
		return optionsMenu;
	}

	protected void resetChessBoard() {
		System.out.println("New Game");
		ChessBoard board = ChessBoard.createStartingBoard();
		this.chessBoard =  board;
		get().getMoveLog().clear();
        get().getGameHistoryPanel().redo(chessBoard, get().getMoveLog());
        get().getCapturedPiecesPanel().redo(get().getMoveLog());
        get().getBoardPanel().drawBoard(chessBoard);
	}


	public enum BoardDirection{
		NORMAL {
			@Override
			List<SquarePanel> traverse(List<SquarePanel> boardTiles) {
				return boardTiles;
			}

			@Override
			BoardDirection opposite() {
				return FLIPPED;
			}
		},
		FLIPPED {
			@Override
			List<SquarePanel> traverse(List<SquarePanel> boardTiles) {
				 List<SquarePanel> reversedList = new ArrayList<>();
				    //Iterate through input list in reverse order
				    for(int i = boardTiles.size() - 1; i >= 0; i--){
				      //add item to the new list
				      reversedList.add(boardTiles.get(i));
				    }
				return reversedList;
			}

			@Override
			BoardDirection opposite() {
				// TODO Auto-generated method stub
				return NORMAL;
			}
		};
		
		abstract List<SquarePanel> traverse(final List<SquarePanel> boardTiles);
		abstract BoardDirection opposite();
	}
	
	
	private class BoardPanel extends JPanel{
		
		/**
		 * 
		 */
		private static final long serialVersionUID = 1L;
		final List<SquarePanel> boardTiles;
		
		BoardPanel(){
			super(new GridLayout(8,8));
			this.boardTiles = new ArrayList<>();
			for(int i = 0; i < BoardUtils.NUM_SQUARES; i++) {
				final SquarePanel tilePanel = new SquarePanel(this, i);
				this.boardTiles.add(tilePanel);
				add(tilePanel);
			}
			setPreferredSize(BOARD_PANEL_DIMENSION);
			validate();
		}

		public void drawBoard(final ChessBoard board) {
			removeAll();
			for(final SquarePanel tilePanel : boardDirection.traverse(boardTiles)) {
				tilePanel.drawSquare(board);
				add(tilePanel);
			}
			validate();
			repaint();
			
		}
	}
	
	
	public static class MoveLog {
		private final List<Move> moves;
		
		MoveLog(){
			this.moves = new ArrayList<>();
		}
		
		public List<Move> getMoves(){
			return this.moves;
		}
		
		public void addMove(final Move move) {
			this.moves.add(move);
		}
		
		public int size() {
			return this.moves.size();
		}
		
		public void clear() {
			this.moves.clear();
		}
		
		public Move removeMove(int index) {
			return this.moves.remove(index);
		}
		
		public boolean removeMove(final Move move) {
			return this.moves.remove(move);
		}
	}
	
	private class SquarePanel extends JPanel{
		
		/**
		 * 
		 */
		private static final long serialVersionUID = 1L;
		private final int squareId;
		
		SquarePanel(final BoardPanel boardPanel, final int tileId){
			super(new GridBagLayout());
			this.squareId = tileId;
			setPreferredSize(SQUARE_PANEL_DIMENSION);
			assignTileColor();
			assignPieceIcon(chessBoard);
			
			addMouseListener(new MouseListener() {

				@Override
				public void mouseClicked(MouseEvent e) {
					
					if(SwingUtilities.isRightMouseButton(e)) {
						resetSelection();
					}
					else if(SwingUtilities.isLeftMouseButton(e)) {
						// first click
						if(sourceSquare == null) {
							sourceSquare = chessBoard.getSquare(tileId);
							movedPiece = sourceSquare.getPiece();
							if(movedPiece == null) {
								resetSelection();
							}
						}else {
							// second click
							destinationSquare = chessBoard.getSquare(tileId);
							final Move move = Move.MoveFactory.createMove(chessBoard, 
												sourceSquare.getSquareCoordinate(), 
												destinationSquare.getSquareCoordinate());
							final MoveUpdate transition = chessBoard.currentPlayer().makeMove(move);
							if(transition.getMoveStatus().isDone()) {
								System.out.println("Legal Move");
								chessBoard = transition.getBoard();
								moveLog.addMove(move);
							}else if(transition.getMoveStatus().isIllegal()) {
								System.out.println("Illegal Move!!");
							}
							resetSelection();
						}
					}
					SwingUtilities.invokeLater(new Runnable() {

						@Override
						public void run() {
							moveHistoryPanel.redo(chessBoard, moveLog);
							capturedPiecesPanel.redo(moveLog);
							boardPanel.drawBoard(chessBoard);
						}
						
					});
					
				}

				@Override
				public void mousePressed(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}

				@Override
				public void mouseReleased(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}

				@Override
				public void mouseEntered(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}

				@Override
				public void mouseExited(MouseEvent e) {
					// TODO Auto-generated method stub
					
				}
				
				private void resetSelection() {
					sourceSquare = null;
					destinationSquare = null;
					movedPiece = null;
				}
			});
			
			validate();
		}
		
		public void drawSquare(final ChessBoard board) {
			assignTileColor();
			assignPieceIcon(board);
			highlightLegalMoves(board);
			validate();
			repaint();
			
		}

		private void assignPieceIcon(final ChessBoard board) {
			this.removeAll();
			if(board.getSquare(this.squareId).squareOccupied()) {
				try {
					final BufferedImage image = 
							ImageIO.read(new File("Images/" + board.getSquare(this.squareId).getPiece().getPieceCol().toString().substring(0, 1) + 
							board.getSquare(this.squareId).getPiece().toString() + ".gif"));
					add(new JLabel(new ImageIcon(image)));
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
		
		private void highlightLegalMoves(final ChessBoard board) {
			if(highlightLegalMoves) {
				for(final Move move : pieceLegalMoves(board)) {
					if(move.getDestinationCoordinate() == this.squareId) {
						try {
							if(move.isCapture()) {
								add(new JLabel(new ImageIcon(ImageIO.read(new File("Images/kill.jpg")))));
							}else {
								add(new JLabel(new ImageIcon(ImageIO.read(new File("Images/ok.png")))));
							}
						}catch(Exception e) {
							e.printStackTrace();
						}
					}
				}
			}
		}
		

		private Collection<Move> pieceLegalMoves(final ChessBoard board) {
			if(movedPiece != null && movedPiece.getPieceCol() == board.currentPlayer().getCol()) {
				return movedPiece.calculateMoves(board);
			}
			return Collections.emptyList();
		}

		private void assignTileColor() {
			if(BoardUtils.RANK_8[this.squareId] || 
					BoardUtils.RANK_6[this.squareId] || 
					BoardUtils.RANK_4[this.squareId] || 
					BoardUtils.RANK_2[this.squareId]) {
				setBackground(this.squareId % 2 == 0 ? lightSquare : darkSquare);
			}
			if(BoardUtils.RANK_7[this.squareId] || 
					BoardUtils.RANK_5[this.squareId] || 
					BoardUtils.RANK_3[this.squareId] || 
					BoardUtils.RANK_1[this.squareId]) {
				setBackground(this.squareId % 2 != 0 ? lightSquare : darkSquare);
			}
		}
		
		
	}
	
}
