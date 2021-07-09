package pkg;
import java.util.Scanner;

public class HW3 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner keyboard = new Scanner(System.in);
		int num  = keyboard.nextInt();
		long tmp = 1;
        for(int i =0; i<=num; i++) {
            System.out.print(tmp);
            if (i!=num) {
            	System.out.print(" ");
            }
            tmp = tmp * (num - i) / (i + 1);
        }
        
	}
}
