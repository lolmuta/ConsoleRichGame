using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRichGame.M
{
    abstract class AbstractPlayer
    {
        public string Name { get; set; }
        public decimal Money { get; set; }
        public bool IsBankruptcy { get; set; } = false;
        public int LocationIndex { get; set; }

        public abstract int Move();
        public abstract void ArrivedLandAction(Land land, List<AbstractPlayer> players);
    }
    static class PlayerExtention
    {
        public static decimal Withdraw(this AbstractPlayer player, decimal m)
        {
            if (m < 0) throw new Exception();
            player.Money -= m;
            if (player.Money - m > 0)
            {
                return m;
            }
            else
            {
                decimal maxWithdrawal = Math.Max(0, player.Money);
                player.Money -= maxWithdrawal;
                player.IsBankruptcy = true;
                return maxWithdrawal;
            }
        }
        public static void Deposit(this AbstractPlayer player, decimal m)
        {
            if (m < 0) throw new Exception();
            player.Money += m;
        }
        public static bool IsOnlyOnePlayerStillive(this List<AbstractPlayer> players)
        {
            var OnePlayerStillive = players.Where(x => x.IsBankruptcy == false).Count() == 1;
            if (OnePlayerStillive)
                return true;
            else
                return false;
        }

    }
}
