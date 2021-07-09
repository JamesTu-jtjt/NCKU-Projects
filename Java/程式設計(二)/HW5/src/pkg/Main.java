package pkg;
import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.input.KeyEvent;
import javafx.scene.Parent;
import javafx.fxml.FXMLLoader;

public class Main extends Application{

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		launch(args);

	}
	
	@Override
	public void start(Stage primaryStage){
		try {
			FXMLLoader loader = new  FXMLLoader(getClass().getResource("calculator.fxml"));
			Parent root = loader.load();
			Controller controller = loader.getController();
			Scene scene = new Scene(root);
			//scene.getStylesheets().add(getClass().getResource("application.css"));
			primaryStage.setScene(scene);
			primaryStage.show();
			scene.setOnKeyReleased(new EventHandler<KeyEvent>() {
	            @Override
	            public void handle(KeyEvent event) {
	            	//controller.fromKeyboard(event.getCode().toString());
	            	switch (event.getCode()) {
	                case DIGIT1: case NUMPAD1:
	                    controller.fromKeyboard("1");
	                    break ;
	                case DIGIT2: case NUMPAD2:
	                    controller.fromKeyboard("2");
	                    break ;
	                case DIGIT3: case NUMPAD3:
	                    controller.fromKeyboard("3");
	                    break ;
	                case DIGIT4: case NUMPAD4:
	                    controller.fromKeyboard("4");
	                    break ;
	                case DIGIT5: case NUMPAD5:
	                    controller.fromKeyboard("5");
	                    break ;
	                case DIGIT6: case NUMPAD6:
	                    controller.fromKeyboard("6");
	                    break ;
	                case DIGIT7: case NUMPAD7:
	                    controller.fromKeyboard("7");
	                    break ;
	                case DIGIT8: case NUMPAD8:
	                    controller.fromKeyboard("8");
	                    break ;
	                case DIGIT9: case NUMPAD9:
	                    controller.fromKeyboard("9");
	                    break ;
	                case DIGIT0: case NUMPAD0:
	                    controller.fromKeyboard("0");
	                    break ;
	                case A: 
	                    controller.fromKeyboard("a");
	                    break ;
	                case C: 
	                    controller.fromKeyboard("c");
	                    break ;
	                case BACK_SPACE:
	                    controller.fromKeyboard("<-");
	                    break ;
	                case ADD: 
	                    controller.fromKeyboard("+");
	                    break ;
	                case SUBTRACT:
	                    controller.fromKeyboard("-");
	                    break ;
	                case MULTIPLY:
	                    controller.fromKeyboard("*");
	                    break ;
	                case DIVIDE:
	                    controller.fromKeyboard("/");
	                    break ;
	                case ENTER:
	                    controller.fromKeyboard("enter");
	                    break ;
	                case DECIMAL:
	                    controller.fromKeyboard(".");
	                    break ;
	                default:
	                	break;

	            }
	            }
	        });
		} catch(Exception e) {
			e.printStackTrace();
		}
		
	}

}
