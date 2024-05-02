internal class ConsoleUtility
{
    public static void PrintGameHeader()
    {
        Console.WriteLine("=============================================================================");
        Console.WriteLine("        ___________________   _____  __________ ___________ _____    ");
        Console.WriteLine("       /   _____/\\______   \\ /  _  \\ \\______   \\\\__    ___//  _  \\   ");
        Console.WriteLine("       \\_____  \\  |     ___//  /_\\  \\ |       _/  |    |  /  /_\\  \\  ");
        Console.WriteLine("       /        \\ |    |   /    |    \\|    |   \\  |    | /    |    \\ ");
        Console.WriteLine("      /_______  / |____|   \\____|__  /|____|_  /  |____| \\____|__  / ");
        Console.WriteLine("              \\/                   \\/        \\/                  \\/  ");
        Console.WriteLine(" ________    ____ ___ _______     ________ ___________________    _______");
        Console.WriteLine(" \\______ \\  |    |   \\\\      \\   /  _____/ \\_   _____/\\_____  \\   \\      \\");
        Console.WriteLine("  |    |  \\ |    |   //   |   \\ /   \\  ___  |    __)_  /   |   \\  /   |   \\\r\n");
        Console.WriteLine("  |    |   \\|    |  //    |    \\\\    \\_\\  \\ |        \\/    |    \\/    |    \\\r\n");
        Console.WriteLine(" /_______  /|______/ \\____|__  / \\______  //_______  /\\_______  /\\____|__  /\r\n");
        Console.WriteLine("         \\/                  \\/         \\/         \\/         \\/         \\/");
        Console.WriteLine("=============================================================================");
        Console.WriteLine("                           PRESS ANYKEY TO START                             ");
        Console.WriteLine("=============================================================================");
        Console.ReadKey();
    }
    public static int PromptMenuChoice(int min, int max)
    {
        while (true)
        {
            Console.Write("원하시는 번호를 입혁해주세요:");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
            {
                return choice;
            }
            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
        }
    }

}