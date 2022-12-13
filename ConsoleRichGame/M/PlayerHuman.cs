using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRichGame.M
{
    class PlayerHuman : AbstractPlayer
    {
        public override void ArrivedLandAction(Land land, List<AbstractPlayer> players)
        {
            land.Match(this,
                noOwnerAct: () =>
                {
                    LogHelper.Info($"Player {this.Name} at land {this.LocationIndex} is no owner");
                    LogHelper.Info($"do you want to buy it ? (y|n)");
                    var userInput = Console.ReadLine();
                    bool wantBuy = userInput.Trim().ToLower() == "y";
                    if (!wantBuy)
                    {
                        LogHelper.Info($"Player {this.Name} dont want to buy land {this.LocationIndex}");
                        return;
                    }
                    if (this.Money >= land.BuyWhenEmpty)
                    {
                        this.Withdraw(land.BuyWhenEmpty);
                        land.Owner = this.Name;
                        LogHelper.Info($"Player {this.Name} buy land {this.LocationIndex}");
                    }
                    else
                    {
                        LogHelper.Info($"Player {this.Name} no money to buy land {this.LocationIndex}");
                    }
                },
                mineLandAct: () =>
                {
                    LogHelper.Info($"Player {this.Name} at land {this.LocationIndex} is belong to him.");
                    LogHelper.Info("Player can upgrade if want not implements");
                },
                othersLandAct: () =>
                {
                    var needPay = land.Pay;
                    LogHelper.Info($"Player {this.Name} at land {this.LocationIndex} owner is {land.Owner}. need to pay {needPay} to him");
                    var ownerPlayer = players.Where(x => x.Name == land.Owner).First();
                    var paid = this.Withdraw(needPay);
                    ownerPlayer.Deposit(paid);
                    LogHelper.Info($"Player {this.Name} paid {paid} to {land.Owner} ...");
                }
            );
        }
        public override int Move()
        {
            LogHelper.Info("Please roll the dice (press enter to continue) ");
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Random rnd = new Random();
            int randomNumber;
            while (true)
            {
                randomNumber = rnd.Next(1, 7);
                Console.SetCursorPosition(x, y);
                Console.Write(randomNumber);
                if (Console.KeyAvailable)
                {
                    var dat = Console.ReadKey(true);
                    if (dat.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Thread.Sleep(250);
            }
            Console.WriteLine();
            LogHelper.Info("You roll dice is " + randomNumber.ToString());
            return randomNumber;
        }
    }
}
