using Opus.Cookbook.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Opus.Cookbook.WebApi.Controllers
{
    public class ControllerBase : ApiController
    {
        private static List<RecipeVm> _recipeCollection;
        private static Stopwatch _stopWatch;
        private static JsonVm _jsonResult;

        public ControllerBase()
        {
            _stopWatch = new Stopwatch();
            _jsonResult = new JsonVm();

            if (_recipeCollection == null)
                LoadRecipe();
        }

        public static List<RecipeVm> RecipeCollection
        {
            get
            {
                return _recipeCollection;
            }
            set
            {
                _recipeCollection = value;
            }
        }

        public static JsonVm JsonResult
        {
            get
            {
                return _jsonResult;
            }
            set
            {
                _jsonResult = value;
            }
        }

        public static Stopwatch StopWatch
        {
            get
            {
                return _stopWatch;
            }
            set
            {
                _stopWatch = value;
            }
        }

        private static void LoadRecipe()
        {
            _recipeCollection = new List<RecipeVm>();

            _recipeCollection.Add(new RecipeVm()
            {
                Id = 5,
                Title = "Bolo de Cenoura",
                Calories = 200,
                Portion = 2,
                PreparationMode = "40 MIN",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id=1,Name="1/2 xícara (chá) de óleo" },
                    new Ingredient { Id=2,Name="3 cenouras médias raladas" },
                    new Ingredient { Id=3,Name="4 ovos" },
                    new Ingredient { Id=4,Name="2 xícaras (chá) de açúcar" },
                    new Ingredient { Id=5,Name="2 e 1/2 xícaras (chá) de farinha de trigo" },
                    new Ingredient { Id=6,Name="1 colher (sopa) de fermento em pó" },
                } 
            });

            _recipeCollection.Add(new RecipeVm()
            {
                Id = 4,
                Title = "Bolo de Fuba",
                Calories = 200,
                Portion = 2,
                PreparationMode = "20 MIN",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id=1,Name="4 ovos" },
                    new Ingredient { Id=2,Name="4 xícaras de leite" },
                    new Ingredient { Id=3,Name="3 xícaras de açúcar" },
                    new Ingredient { Id=4,Name="2 colheres de farinha de trigo" },
                    new Ingredient { Id=5,Name="1 e 1/2 xícara de fubá" },
                    new Ingredient { Id=6,Name="2 colheres de margarina" },
                    new Ingredient { Id=7,Name="100 g de queijo ralado" },
                    new Ingredient { Id=8,Name="1 colher de fermento em pó" },
                }
            });

            _recipeCollection.Add(new RecipeVm()
            {
                Id = 3,
                Title = "Panquecas americana",
                Calories = 300,
                Portion = 2,
                PreparationMode = "60 MIN",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id=1,Name="1 xícara e 1/2 de chá de farinha de trigo" },
                    new Ingredient { Id=2,Name="1 xícara e 1/2 de leite" },
                    new Ingredient { Id=3,Name="1 banana nanica bem madura" },
                    new Ingredient { Id=4,Name="2 colheres de sobremesa de fermento em pó Royal" },
                    new Ingredient { Id=5,Name="1 colher rasa de café de sal" },
                    new Ingredient { Id=6,Name="1 colher de café de essência de baunilha" },
                    new Ingredient { Id=7,Name="2 ovos levemente batidos (para não criar espuma)" },
                    new Ingredient { Id=8,Name="Óleo para untar" },
                    new Ingredient { Id=9,Name="2 colheres de sobremesa de açúcar cristal" },
                    new Ingredient { Id=10,Name="2 colheres de sopa de manteiga" }
                }
            });

            _recipeCollection.Add(new RecipeVm()
            {
                Id = 2,
                Title = "Torta de Frango",
                Calories = 500,
                Portion = 2,
                PreparationMode = "40 MIN",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id=1,Name="4 xícaras de farinha de trigo sem fermento" },
                    new Ingredient { Id=2,Name="3 gemas de ovo" },
                    new Ingredient { Id=3,Name="3 tabletes de margarina (em um pacote use 3/4 - 300 g)" },
                    new Ingredient { Id=4,Name="1 colher de fermento em pó" },
                    new Ingredient { Id=5,Name="1 colherinha de sal" }
                }
            });

            _recipeCollection.Add(new RecipeVm()
            {
                Id = 1,
                Title = "Pudim de pão com Banana",
                Calories = 200,
                Portion = 2,
                PreparationMode = "60 MIN",
                Ingredients = new List<Ingredient> {
                    new Ingredient { Id=1,Name="2 xícaras de pão cortado em cubinhos" },
                    new Ingredient { Id=2,Name="2 xícaras de leite" },
                    new Ingredient { Id=3,Name="3 ovos" },
                    new Ingredient { Id=4,Name="1 xícara e 1/2 de açúcar" },
                    new Ingredient { Id=5,Name="1 colher de café de canela em pó" },
                    new Ingredient { Id=6,Name="Raspa de 1 limão" }
                }
            });
        }
    }
}
