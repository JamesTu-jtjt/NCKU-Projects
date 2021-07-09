package pkg;
import java.util.Scanner;

public class HW4 {
	public static void main(String[] args) {
		Scanner keyboard = new Scanner(System.in);
		int num  = keyboard.nextInt();
		int i = num - 1;
		while (i > 0) {
			for (int j=2; j<i; j++) {
				if (i%j==0) {
					break;
				}
				else if (j == i-1){
					System.out.print(i);
					i = 0;
					break;
				}
			}
			i--;
		}
	}

}
