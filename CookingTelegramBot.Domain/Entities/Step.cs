using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTelegramBot.Domain.Entities
{
    public class Step
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
    }
}
