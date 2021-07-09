package pkg.gui;

import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Comparator;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.border.*;

import pkg.gui.MainUI.MoveLog;
import pkg.chessboard.board.Move;
import pkg.chessboard.pieces.Piece;

public class CapturedPiecesPanel extends JPanel{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private final JPanel upperPanel;
	private final JPanel lowerPanel;
	
	private static final EtchedBorder PANEL_BORDER = new EtchedBorder(EtchedBorder.RAISED);
	private static final Dimension CAPTURED_PIECES_DIMENSION = new Dimension(40, 100);

	public CapturedPiecesPanel() {
		super(new BorderLayout());
		this.setBackground(new Color(204, 204, 204));
		this.setBorder(PANEL_BORDER);
		this.upperPanel = new JPanel(new GridLayout(8, 2));
		this.lowerPanel = new JPanel(new GridLayout(8, 2));
		this.upperPanel.setBackground(new Color(0, 0, 0));
		this.lowerPanel.setBackground(new Color(255, 255, 255));
		this.add(this.upperPanel, BorderLayout.NORTH);
		this.add(this.lowerPanel, BorderLayout.SOUTH);
		setPreferredSize(CAPTURED_PIECES_DIMENSION);
	}
	
	public void redo(final MoveLog moveLog) {
		upperPanel.removeAll();
		lowerPanel.removeAll();
		
		final List<Piece> capturedWhite = new ArrayList<>();
		final List<Piece> capturedBlack = new ArrayList<>();
		
		for(final Move move : moveLog.getMoves()) {
			if(move.isCapture()) {
				final Piece capturedPiece = move.getCapturedPiece();
				if(capturedPiece.getPieceCol().isWhite()) {
					capturedWhite.add(capturedPiece);
				}else {
					capturedBlack.add(capturedPiece);
				}
			}
		}
		Collections.sort(capturedWhite, new Comparator<Piece>(){
			@Override
			public int compare(Piece p1, Piece p2) {
				return Integer.compare(p1.getPieceVal(), p2.getPieceVal());
			}
		});
		
		Collections.sort(capturedBlack, new Comparator<Piece>(){
			@Override
			public int compare(Piece p1, Piece p2) {
				return Integer.compare(p1.getPieceVal(), p2.getPieceVal());
			}
		});
		
		for(final Piece capturedPiece : capturedWhite) {
			try {
				final BufferedImage image = 
						ImageIO.read(new File("Images/"  + capturedPiece.getPieceCol().toString().substring(0, 1) + 
						capturedPiece.toString() + ".gif"));
				final ImageIcon icon = new ImageIcon(image);
				final JLabel imageLabel = new JLabel(new ImageIcon(icon.getImage().getScaledInstance(
                        icon.getIconWidth() - 15, icon.getIconWidth() - 15, Image.SCALE_SMOOTH)));
				this.upperPanel.add(imageLabel);
			}catch(final IOException e) {
				e.printStackTrace();
			}
		}
		
		for(final Piece capturedPiece : capturedBlack) {
			try {
				final BufferedImage image = 
						ImageIO.read(new File("Images/"  + capturedPiece.getPieceCol().toString().substring(0, 1) + 
						capturedPiece.toString() + ".gif"));
				final ImageIcon icon = new ImageIcon(image);
				 final JLabel imageLabel = new JLabel(new ImageIcon(icon.getImage().getScaledInstance(
	                        icon.getIconWidth() - 15, icon.getIconWidth() - 15, Image.SCALE_SMOOTH)));
				this.lowerPanel.add(imageLabel);
			}catch(final IOException e) {
				e.printStackTrace();
			}
		}
		
		validate();
		
	}
	
	
}
