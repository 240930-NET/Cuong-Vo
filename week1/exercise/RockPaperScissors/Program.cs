namespace RockPaperScissors;

class Program
{
    static void Main(string[] args)
    {
        RPSGame firstGame = new RPSGame();
        Console.WriteLine("Runiing!");
        firstGame.gameStart();
    }
}
