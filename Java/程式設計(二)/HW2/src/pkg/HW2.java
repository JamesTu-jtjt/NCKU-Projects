package pkg;
import java.util.Scanner;

public class HW2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String w1 = "";
		String w2 = "";
		Scanner keyboard = new Scanner(System.in);
		int int1 = keyboard.nextInt();
		int int2 = keyboard.nextInt();
		String operator = keyboard.next();
		if((int1>9 || int1<0) || (int2>9 || int2<0)) {
			System.out.println("invalid number");
		}
		else{
			switch(int1) {
			case 1:
				w1 = "one";
				break;
			case 2:
				w1 = "two";
				break;
			case 3:
				w1 = "three";
				break;
			case 4:
				w1 = "four";
				break;
			case 5:
				w1 = "five";
				break;
			case 6:
				w1 = "six";
				break;
			case 7:
				w1 = "seven";
				break;
			case 8:
				w1 = "eight";
				break;
			case 9:
				w1 = "nine";
				break;
			case 0:
				w1 = "zero";
				break;
			}
			switch(int2) {
			case 1:
				w2 = "one";
				break;
			case 2:
				w2 = "two";
				break;
			case 3:
				w2 = "three";
				break;
			case 4:
				w2 = "four";
				break;
			case 5:
				w2 = "five";
				break;
			case 6:
				w2 = "six";
				break;
			case 7:
				w2 = "seven";
				break;
			case 8:
				w2 = "eight";
				break;
			case 9:
				w2 = "nine";
				break;
			case 0:
				w2 = "zero";
				break;
			}
			switch(operator) {
			case "+":
				System.out.print(w1 + " plus " + w2 + " is ");
				System.out.print(int1+int2);
				break;
			case "-":
				System.out.print(w1 + " minus " + w2 + " is ");
				System.out.print(int1-int2);
				break;
			case "*":
				System.out.print(w1 + " multiplied by " + w2 + " is ");
				System.out.print(int1*int2);
				break;
			case "/":
				if(int2 == 0) {
					System.out.println("division by zero is not allowed");
				}
				else {
					System.out.print(w1 + " divided by " + w2 + " is ");
					System.out.print(int1/int2);
				}
				break;
			case "^":
				System.out.print(w1 + " to the power of " + w2 + " is ");
				System.out.printf("%.0f", Math.pow(int1, int2));
				break;
			}
		}
	}

}
