using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTelegramBot.Domain.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
        public string Amount { get; set; }
    }
}
