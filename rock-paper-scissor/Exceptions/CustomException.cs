using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_paper_scissor.Exceptions
{
   public class WrongNumberOfPlayersError:Exception
    {
        public WrongNumberOfPlayersError(string message)
            : base(message)
       {
       }
    }

    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError(string message)
            : base(message)
        {
        }
    }
}
