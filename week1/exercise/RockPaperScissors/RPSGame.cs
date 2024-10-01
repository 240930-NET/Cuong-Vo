public class RPSGame {    
    short mode;
    int playerScore = 0;
    int computerScore = 0;
    Random numberGenerator;
    string[] handName = {"Rock","Paper","Scissor"};
    public RPSGame(short mode = 0) {
        this.mode = mode;
        this.numberGenerator = new Random();
    }  

    public void gameStart() {
        Console.WriteLine("Welcome to Rock Paper Scissor Game!");
        string ending = "Y";
        while (ending != "N") {
        Console.WriteLine("=====================================================");
        Console.WriteLine("Please enter 1 for Rock, 2 for Paper, and 3 for Scissor");
        int userChoice = getUserChoice();
        Console.WriteLine("User chose: {0}",handName[userChoice-1]);
        int computerChoice = getComputerChoice();
        Console.WriteLine("computer chose: {0}",handName[computerChoice-1]);
        int result = getResult(userChoice,computerChoice);
        handleResult(result);
        Console.WriteLine("Player Score: {0} ; Computer Score: {1} ",playerScore,computerScore);
        Console.WriteLine("you want to play again ? (Y/N)");
        ending = Console.ReadLine();
        }
    }

       //Get input from user
    int getUserChoice() {
        string? choice = Console.ReadLine();
        while (choice != "1" && choice != "2" && choice != "3") {
            Console.WriteLine("The input is invalid. Please input between 1 and 3");
            choice = Console.ReadLine();
        }
        return  Int32.Parse(choice);
    }

    int getComputerChoice() {
        return numberGenerator.Next(1,3);
    }

    int getResult(int firstChoice, int secondChoice) {
        if (firstChoice == secondChoice) return 0;
        else {
            int diff = firstChoice - secondChoice;
            if (firstChoice == 1) {
                if (secondChoice == 2) return 1;
                else return -1;
            }

            if (firstChoice == 2) return 1;
            else return -1;
        }
        return 0;
    }

    void handleResult(int result) {
        if (result == 0 ) {
            Console.WriteLine("a Tie");
        }
        else if (result == 1) {
            Console.WriteLine("Computer win!");
            computerScore+=1;
        } 
        else {
            Console.WriteLine("Player win!");
            playerScore+=1;
        }
    }

    

}
