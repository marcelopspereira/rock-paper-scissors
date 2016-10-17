using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_paper_scissor
{
    public class Player
    {
        public string Name { get; set; }
        public Move Move { get; set; }
        public bool IsLoser { get; set; }

        public Player(string name, Move move)
        {
            Name = name;
            Move = move;
            IsLoser = false;
        }
    }

    public enum Move
    {
        [Description("Rock")]
        R,
        [Description("Paper")]
        P,
        [Description("Scissors")]
        S,
        [Description("None")]
        Q
    }
}
