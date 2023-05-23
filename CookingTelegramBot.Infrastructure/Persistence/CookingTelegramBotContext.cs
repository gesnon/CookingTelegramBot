using CookingTelegramBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingTelegramBot.Infrastructure.Persistence
{
    public class CookingTelegramBotContext: DbContext
    {
        public CookingTelegramBotContext(DbContextOptions<CookingTelegramBotContext> options) : base(options)
        {
        }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
