package pkg;
 
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;

public class Controller {

    @FXML
    private Button one;

    @FXML
    private Button two;

    @FXML
    private Button three;

    @FXML
    private Button four;

    @FXML
    private Button five;

    @FXML
    private Button six;

    @FXML
    private Button seven;

    @FXML
    private Button eight;

    @FXML
    private Button nine;

    @FXML
    private Button zero;

    @FXML
    private Button decimal;

    @FXML
    private Button ac;

    @FXML
    private Button ce;

    @FXML
    private Button b;

    @FXML
    private Button divide;

    @FXML
    private Button multiply;

    @FXML
    private Button subtract;

    @FXML
    private Button add;

    @FXML
    private Button equals_;

    @FXML
    private TextField result;

    @FXML
    private TextField input;

    @FXML
    
    void pressed(ActionEvent e) {
    	if (e.getSource() == one) {
    		input.setText(input.getText() + "1"); 
    	}
    	else if (e.getSource() == two) {
    		input.setText(input.getText() + "2"); 
    	}
    	else if (e.getSource() == three) {
    		input.setText(input.getText() + "3"); 
    	}
    	else if (e.getSource() == four) {
    		input.setText(input.getText() + "4"); 
    	}
    	else if (e.getSource() == five) {
    		input.setText(input.getText() + "5"); 
    	}
    	else if (e.getSource() == six) {
    		input.setText(input.getText() + "6"); 
    	}
    	
    	else if (e.getSource() == seven) {
    		input.setText(input.getText() + "7"); 
    	}
    	else if (e.getSource() == eight) {
    		input.setText(input.getText() + "8"); 
    	}
    	
    	else if (e.getSource() == nine) {
    		input.setText(input.getText() + "9"); 
    	}
    	else if (e.getSource() == zero) {
    		input.setText(input.getText() + "0"); 
    	}
    	else if (e.getSource() == decimal) {
    		input.setText(input.getText() + "."); 
    	}
    	else if (e.getSource() == add) {
    		input.setText(input.getText() + "+"); 
    	}
    	
    	else if (e.getSource() == subtract) {
    		input.setText(input.getText() + "-"); 
    	}
    	else if (e.getSource() == multiply) {
    		input.setText(input.getText() + "*"); 
    	}
    	else if (e.getSource() == divide) {
    		input.setText(input.getText() + "/"); 
    	}
    	else if (e.getSource() == ce) {
    		for(int i = input.getText().length()-1; i >= 0; i--) {
    			if (input.getText().charAt(i) == '+'||input.getText().charAt(i) == '-' || 
    					input.getText().charAt(i) == '*'||input.getText().charAt(i) == '/' ) {
    				input.setText(input.getText().substring(0,i+1));
    				break;
    			}
    			else if(i==0)
    				input.setText("");
    				
    		}
    	}
    	else if (e.getSource() == ac) {
    		input.setText("");
    		result.setText("");
    	}
    	else if (e.getSource() == b) {
    		if(input.getText().length()-1 > 0){
    			input.setText(input.getText().substring(0,input.getText().length()-1)); 
    		}
    		else {
    			input.setText("");
    		}
    	}
    	else if (e.getSource() == equals_) {
    		String calc = input.getText();
    	    String operators[]=calc.split("[0-9.]+");
    	    String operands[]=calc.split("[+-]");
    	    Boolean error = false;
    	    for(int i=0;i<operands.length;i++){
    	    	String pre_Operators[]=operands[i].split("[0-9.]+");
        	    String pre_Operands[]=operands[i].split("[*/]");
        	    Double tmp = Double.parseDouble(pre_Operands[0]);
    	    	for(int j=1;j<pre_Operands.length;j++) {
    	    		if(pre_Operators[j].equals("*"))
        	            tmp *= Double.parseDouble(pre_Operands[j]);
        	        else if (pre_Operators[j].equals("/")) {
        	        	if (Double.parseDouble(pre_Operands[j]) == 0.0 || error) {
        	        		error = true;
        	        		System.out.println("Error");
        	        		result.setText("Error");
        	        		break;
        	        	}
        	        	else
        	        		tmp /= Double.parseDouble(pre_Operands[j]);
        	        }
        	        String t = String.valueOf(tmp);
        	        operands[i] = t;
    	    	}
    	    	if (error)
    	    		break;
    	    }
    	    Double r = Double.parseDouble(operands[0]);
    	    for(int i=1;i<operands.length;i++){
    	        if(operators[i].equals("+"))
    	            r += Double.parseDouble(operands[i]);
    	        else if(operators[i].equals("-"))
    	            r -= Double.parseDouble(operands[i]);
    	    }
    	    String res = String.format("%.1f", r);
    	    if (error)
    	    	result.setText("Error");
    	    else
    	    	result.setText(res);
    	}

    }
    void fromKeyboard(String kb) {
    	switch (kb) {
        case "<-":
        	if(input.getText().length()-1 > 0){
    			input.setText(input.getText().substring(0,input.getText().length()-1)); 
    		}
    		else {
    			input.setText("");
    		}
        	break ;
        case "enter":
        	String calc = input.getText();
    	    String operators[]=calc.split("[0-9.]+");
    	    String operands[]=calc.split("[+-]");
    	    Boolean error = false;
    	    for(int i=0;i<operands.length;i++){
    	    	String pre_Operators[]=operands[i].split("[0-9.]+");
        	    String pre_Operands[]=operands[i].split("[*/]");
        	    Double tmp = Double.parseDouble(pre_Operands[0]);
        	    for(int j=1;j<pre_Operands.length;j++) {
    	    		if(pre_Operators[j].equals("*"))
        	            tmp *= Double.parseDouble(pre_Operands[j]);
        	        else if (pre_Operators[j].equals("/")) {
        	        	if (Double.parseDouble(pre_Operands[j]) == 0.0 || error) {
        	        		error = true;
        	        		System.out.println("Error");
        	        		result.setText("Error");
        	        		break;
        	        	}
        	        	else
        	        		tmp /= Double.parseDouble(pre_Operands[j]);
        	        }
        	        String t = String.valueOf(tmp);
        	        operands[i] = t;
    	    	}
    	    }
    	    Double r = Double.parseDouble(operands[0]);
    	    for(int i=1;i<operands.length;i++){
    	        if(operators[i].equals("+"))
    	            r += Double.parseDouble(operands[i]);
    	        else if(operators[i].equals("-"))
    	            r -= Double.parseDouble(operands[i]);
    	    }
    	    String res = String.format("%.1f", r);
    	    if (error)
    	    	result.setText("Error");
    	    else
    	    	result.setText(res);
        	break ;
        case "a":
        	input.setText("");
    		result.setText(""); 
        	break ;
        case "c":
        	for(int i = input.getText().length()-1; i >= 0; i--) {
    			if (input.getText().charAt(i) == '+'||input.getText().charAt(i) == '-' || 
    					input.getText().charAt(i) == '*'||input.getText().charAt(i) == '/' ) {
    				input.setText(input.getText().substring(0,i+1));
    				break;
    			}
    			else if(i==0)
    				input.setText("");
    				
    		}
        	break;
        default:
        	input.setText(input.getText() + kb); 
    	}

    }
}
