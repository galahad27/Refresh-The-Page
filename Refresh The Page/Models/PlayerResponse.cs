using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GameDataAccess;

namespace Refresh_The_Page.Models
{
    public class PlayerResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int Highscore { get; set; }
        public int Tens { get; set; }
        public int Hundreds { get; set; }
        public int Thousands { get; set; }
        public int TenThousands { get; set; }
        public int HundredThousands { get; set; }
        public int Millions { get; set; }

        public static PlayerResponse DataToResponse(Player player)
        {
            PlayerResponse response = new PlayerResponse
            {
                Id = player.Id,
                UserName = player.UserName,
                Highscore = player.Highscore,
                Tens = player.Tens,
                Hundreds = player.Hundreds,
                Thousands = player.Thousands,
                TenThousands = player.TenThousands,
                HundredThousands = player.HundredThousands,
                Millions = player.Millions
            };

            return response;
        }
    }
}