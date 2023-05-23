using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTelegramBot.Examples.Polling.Services
{
    public enum State
    {
        Wait,
        SendFirstNumber,
        SendSecondNumber,
    }
}
