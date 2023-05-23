using AngleSharp;
using AngleSharp.Dom;
using CookingTelegramBot.Domain.Entities;
using CookingTelegramBot.Infrastructure.Persistence;
using System.Text;


namespace CookingTelegramBot.Application.Services
{
    public class ParserService
    {
        public CookingTelegramBotContext _context;
        public ParserService(CookingTelegramBotContext _context)
        {
            this._context = _context;
        }

        public async Task Parse()
        {
            List<Recipe> recipes = _context.Recipes.ToList();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var config = Configuration.Default.WithDefaultLoader();
            int recipeId = 3;
            using var context = BrowsingContext.New(config);

            List<Recipe> result = new List<Recipe>();
            while (recipeId > 0)
            {
                List<Ingredient> IngredientsfromBase = _context.Ingredients.ToList();

                Console.WriteLine(recipeId);
                recipeId--;
                string urlAddress = $"https://food.ru/recipes/{recipeId}";
                using var doc = await context.OpenAsync(urlAddress);
                var titleElement = doc.QuerySelector(".title_title__DUuGT.slugPage_title__jB45m");
                if (titleElement == null)
                {
                    continue;
                }
                var title = titleElement.Text();
                var picture = doc.QuerySelector(".cover_themeLogoWrapper__m1zPo img")?.Attributes["srcset"];
                if (picture == null)
                {
                    continue;
                }
                var products = doc.QuerySelectorAll(".ingredientsTable_table__QFLKe.ingredientsCalculator_ingredientsTable__GIHSQ tr td").Select(p => p.Text()).ToArray();

                
                List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
                for(int i = 0; i < products.Length-1; i += 2)
                {
                    Ingredient ing = IngredientsfromBase.FirstOrDefault(_ => _.Name == products[i]);
                    if (ing!=null)
                    {
                        recipeIngredients.Add(new RecipeIngredient { Amount = products[i + 1], Ingredient = ing });
                        continue;
                        
                    }
                    ing = new Ingredient { Name = products[i] };                 

                    recipeIngredients.Add(new RecipeIngredient { Amount = products[i + 1], Ingredient = ing });
                }

                var steps = doc.QuerySelectorAll(".stepByStepPhotoRecipe_step__vGA5r .markup_wrapper__7GLFA").Select(p => p.Text()).ToArray();                

                List<Step> _steps = steps.Select(_ => new Step { Number = Array.IndexOf(steps, _) + 1, Description = _ }).ToList();

                Recipe recipe = new Recipe { Name = title, Picture = picture.Value, Steps=_steps, RecipeIngredients = recipeIngredients };

                await _context.Recipes.AddAsync(recipe);
                await _context.SaveChangesAsync();
                
            }

            //await _context.Recipes.AddRangeAsync(result);
            //await _context.SaveChangesAsync();
        }
    }
}

