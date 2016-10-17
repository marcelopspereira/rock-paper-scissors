using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_paper_scissor
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            Player[] players=
            {
                new Player("Armando", Move.S),
                new Player("Dave", Move.P),                
            };

            Player[] players1 =
            {
                new Player("Armando", Move.P),
                new Player("Dave", Move.S),
                new Player("Richard", Move.R),
                new Player("Michael", Move.S),

                new Player("Allen", Move.S),
                new Player("Omer", Move.P),
                new Player("David E", Move.R),
                new Player("Richard X", Move.P)
            };

            //var result1 = game.rps_game_winner(players);
           var result2 = game.rps_tournament_winner(players1);

            Console.Write("...");        
            Console.ReadKey();
        }
    }
}
