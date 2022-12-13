using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRichGame.M
{
    class PlayerComputer : AbstractPlayer
    {
        public override void ArrivedLandAction(Land land, List<AbstractPlayer> players)
        {
            land.Match(this,
                noOwnerAct: () =>
                {
                    LogHelper.Info($"Player {this.Name} at land {this.LocationIndex} is no owner");
                    if (this.Money >= land.BuyWhenEmpty)
                    {
                        this.Withdraw(land.BuyWhenEmpty);
                        land.Owner = this.Name;
                        LogHelper.Info($"Player {this.Name} buy this land {this.LocationIndex}");
                    }
                    else
                    {
                        LogHelper.Info($"Player {this.Name} no money to buy land {this.LocationIndex}");
                    }
                },
                mineLandAct: () =>
                {
                    LogHelper.Info($"Player {this.Name} at his land {this.LocationIndex} player can upgrade(not implements)");
                    //todo upgrade land building

                },
                othersLandAct: () =>
                {
                    var landPay = land.Pay;
                    LogHelper.Info($"Player {this.Name} at land {this.LocationIndex}" +
                        $" owner is {land.Owner} landpay is {landPay}");
                    var ownerPlayer = players.Where(x => x.Name == land.Owner).First();
                    var paid = this.Withdraw(landPay);
                    ownerPlayer.Deposit(paid);
                    LogHelper.Info($"Player {this.Name} paid {paid} to {land.Owner}...");
                }
            );
        }
        public override int Move()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 7);
            return randomNumber;
        }
    }
}
