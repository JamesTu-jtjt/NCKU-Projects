package pkg.chessboard.board;

import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class BoardUtils {
	
	public static final boolean[] A_FILE = initColumn(0);
	public static final boolean[] B_FILE = initColumn(1);
	public static final boolean[] C_FILE = initColumn(2);
	public static final boolean[] D_FILE = initColumn(3);
	public static final boolean[] E_FILE = initColumn(4);
	public static final boolean[] F_FILE = initColumn(5);
	public static final boolean[] G_FILE = initColumn(6);
	public static final boolean[] H_FILE = initColumn(7);
	
	public static final boolean[] RANK_8 = initRank(0);
	public static final boolean[] RANK_7 = initRank(8);
	public static final boolean[] RANK_6 = initRank(16);
	public static final boolean[] RANK_5 = initRank(24);
	public static final boolean[] RANK_4 = initRank(32);
	public static final boolean[] RANK_3 = initRank(40);
	public static final boolean[] RANK_2 = initRank(48);
	public static final boolean[] RANK_1 = initRank(56);
	
	public static final List<String> POSITION_NOTATION = initializePN();
	public static final Map<String, Integer> POSITION_TO_COORDINATE = initializePtoCMap();
	
	public static final int NUM_SQUARES = 64;
	public static final int NUM_RANKS = 8;
	

	private BoardUtils() {
		throw new RuntimeException("DO NOT INSTANTIATE!!");
	}
	
	private static Map<String, Integer> initializePtoCMap() {
		final Map<String, Integer> positionToCoordinate = new HashMap<>();
        for (int i = 0; i < NUM_SQUARES; i++) {
            positionToCoordinate.put(POSITION_NOTATION.get(i), i);
        }
        return Collections.unmodifiableMap(positionToCoordinate);
    }

	private static List<String> initializePN() {
		return Collections.unmodifiableList(Arrays.asList(
                "a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8",
                "a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7",
                "a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6",
                "a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5",
                "a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4",
                "a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3",
                "a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2",
                "a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1"));
    }

	private static boolean[] initRank(int rowNum) {
		// TODO Auto-generated method stub
		final boolean[] row = new boolean[NUM_SQUARES];
		do {
			row[rowNum] = true;
			rowNum++;
		}while(rowNum % NUM_RANKS != 0);
		
		return row;
	}

	private static boolean[] initColumn(int columnNum) {
		// TODO Auto-generated method stub
		final boolean[] column = new boolean[64];
		
		do {
			column[columnNum] = true;
			columnNum += 8;
		} while(columnNum < 64);
		
		return column;
	}

	public static boolean isValidTileCoordinate(final int coordinate) {
		// TODO Auto-generated method stub
		return coordinate >= 0 && coordinate < 64;
	}

	public static int getCoordinateOfPosition(final String position) {
		return POSITION_TO_COORDINATE.get(position);
	}
	
	public static String getPositionCoordinate(final int coordinate) {
		return POSITION_NOTATION.get(coordinate);
	}

}
