using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using rock_paper_scissor.Exceptions;

namespace rock_paper_scissor
{
    class Game
    {
        private int _numberOfPlayers;
        private int _round;
        /// <summary>
        /// Lista de Movimentos permitidos no jogo
        /// </summary>
        public string[] Strategy = { "R", "P", "S" };
        /// <summary>
        /// Matrix de Regras de validação das jogadas
        /// Iniciando o indice da direita para esquerda
        /// </summary>
        private static readonly int[,] Rules = 
        {  // R  P  S p1 // p2
            { 0, 1, 2 }, // R
            { 2, 0, 1 }, // P
            { 1, 2, 0 }  // S
        };
        /// <summary>
        /// Valida as jogadas de acordo com as Regras do Jogo
        /// </summary>
        /// <param name="p1Move">Movimento - Jogador 1</param>
        /// <param name="p2Move">Movimento - Jogador 2</param>
        /// <returns> (0) - Empate  
        ///           (1) - Jogador 1
        ///           (2) - Jogador 2
        /// </returns>
        public static int PlayRound(int p1Move, int p2Move)
        {
            return Rules[p2Move, p1Move];
        }


        public object rps_game_winner(params Player[] players)
        {
            try
            {
                if (players.Length != 2)
                    throw (new WrongNumberOfPlayersError("WrongNumberOfPlayersError"));
                if (players.Any(player => !Strategy.Contains(player.Move.ToString())))
                    throw (new NoSuchStrategyError("NoSuchStrategyError"));
                return rps_run(players);
            }
            catch (WrongNumberOfPlayersError e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                throw;
            }
            catch (NoSuchStrategyError e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                throw;
            }
        }

        public object rps_tournament_winner(params  Player[] players)
        {
            var player = rps_run(players);
            return player;
            //(Player[]) player;
        }

        /// <summary>
        ///  Método Responsável por fazer o controle de jogadas
        /// </summary>
        /// <param name="players">Array de Jogadores </param>
        /// <returns>Jogado vencedor</returns>
        private object rps_run(Player[] players)
        {
            try
            {
                var listwinners = new List<Player>();
                _numberOfPlayers = players.Count();
                _round++;

                for (var i = 0; i < _numberOfPlayers; i++)
                {
                    if (listwinners.Contains(players[i])) continue;
                    for (var j = i + 1; j < _numberOfPlayers; j++)
                    {
                        if (players[i].IsLoser)
                            break;
                        if (listwinners.Contains(players[i]))
                            break;


                        var playerWinner = PlayRound((int)players[i].Move, (int)players[j].Move);

                        Console.WriteLine("======= Round " + _round + "  =============");
                        Console.WriteLine("Player1 " + players[i].Name + " - Move :" + players[i].Move);
                        Console.WriteLine("Player2 " + players[j].Name + " - Move :" + players[j].Move);
                        Console.WriteLine("======================================");
                        
                        if (playerWinner == 1 || playerWinner == 0) 
                        {
                            Console.WriteLine("Player1 Win!!!");
                            Console.WriteLine(players[i].Name + " - Move :" + players[i].Move);
                            players[j].IsLoser = true;
                            listwinners.Add(players[i]);
                        }
                        else
                        {
                            Console.WriteLine("Player 2 Win!!!");
                            Console.WriteLine(players[j].Name + " - Move :" + players[j].Move);
                            players[i].IsLoser = true;
                            listwinners.Add(players[j]);
                        }
                    }
                }
                return listwinners.Count() == 1 ? listwinners.ToArray() : rps_run(listwinners.ToArray());
            }
            catch (Exception e)
            {
                Console.Write("Erro", e.Message);
                throw;
            }
        }
    }
}
