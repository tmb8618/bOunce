using System;

namespace game_v0._1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            
            using (game game = new game())
            {
                game.Run();
            }
        }
    }
}

