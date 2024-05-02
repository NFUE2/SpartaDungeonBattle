public class GameManager
{
    private Player player;
    private Battle battle;

    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player = new Player();
    }

    public void StartGame()
    {
        Console.Clear();
        ConsoleUtility.PrintGameHeader();
        MainMenu();
    }

    private void MainMenu()
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다.");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("");

        Console.WriteLine("1. 상태 보기 ");
        Console.WriteLine("2. 전투 시작 ");
        Console.WriteLine("3. 회복 아이템")

        Console.WriteLine("0. 게임 종료");
        Console.WriteLine("");

        int choice = ConsoleUtility.PromptMenuChoice(0, 3);
        switch (choice)
        {
            case 1:
                StatusMenu();
                break;
            case 2:
                BattleMenu();
                break;
            case 3:
                ItemMenu();
                break;
            case 0:
                return;
        }
    }
    
    private void StatusMenu()
    {

    }

    private void BattleMenu()
    {

    }

    private void ItemMenu()
    {

    }
}


public class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}