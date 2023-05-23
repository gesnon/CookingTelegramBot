using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTelegramBot.Infrastructure.Persistence
{
    public class DbInitializer
    {
        private readonly CookingTelegramBotContext _context;

        public DbInitializer(CookingTelegramBotContext context)
        {
            _context = context;
        }
    }
}
