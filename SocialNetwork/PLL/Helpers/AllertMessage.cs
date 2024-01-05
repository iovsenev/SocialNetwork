namespace SocialNetwork.PLL.Helpers
{
    public class AllertMessage
    {
        public static void Show(string message)
        {
            ConsoleColor defcol = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = defcol;
        }
    }
}
