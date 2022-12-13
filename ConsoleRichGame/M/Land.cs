using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRichGame.M
{
    class Land
    {
        public decimal BuyWhenEmpty { get; set; }
        public decimal Pay { get; set; }
        public string? Owner { get; set; }
    }
    static class LandExtenstion
    {
        public static void EmptyOwner(this Land land) => land.Owner = null;

        public static void Match(this Land land, AbstractPlayer player,
            Action noOwnerAct,
            Action mineLandAct,
            Action othersLandAct)
        {
            bool noOwner = land.Owner == null;
            if (noOwner)
            {
                noOwnerAct?.Invoke();
            }
            else
            {
                bool isMineLand = land.Owner == player.Name;
                if (isMineLand)
                {
                    mineLandAct?.Invoke();
                }
                else
                {
                    othersLandAct?.Invoke();
                }
            }
        }
    }
}
