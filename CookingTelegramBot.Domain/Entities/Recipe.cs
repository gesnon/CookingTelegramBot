using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTelegramBot.Domain.Entities
{
    public class Recipe
    {        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<Step> Steps { get; set; }
    }
}
