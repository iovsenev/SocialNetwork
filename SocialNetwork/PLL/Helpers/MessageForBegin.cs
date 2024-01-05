namespace SocialNetwork.PLL.Helpers
{
    public class MessageForBegin
    {
        public static void Show()
        {
            ConsoleColor defcol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Для продолжения нажмите Enter.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = defcol;
        }
    }
}
