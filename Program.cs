using System;

namespace boatgame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MasterGame())
                game.Run();
        }
    }
}
