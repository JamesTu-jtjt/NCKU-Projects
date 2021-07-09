package pkg;
import java.util.Scanner;

public class HW1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner keyboard = new Scanner(System.in);
		double d1 = keyboard.nextDouble();
		double d2 = keyboard.nextDouble();
		double d3 = keyboard.nextDouble();
		double output = (d1 * (d3/d2))/(30 * 0.001);
		System.out.printf("%.1f", output);
	}

}
