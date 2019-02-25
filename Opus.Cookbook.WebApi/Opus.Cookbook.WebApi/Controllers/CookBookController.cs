using Opus.Cookbook.WebApi.Filters;
using Opus.Cookbook.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Opus.Cookbook.WebApi.Controllers
{
    public class CookBookController : ControllerBase
    {
        public CookBookController() : base()
        {
        }

        /// <summary>
        /// Obtem um listagem de receitas cadastradas no sistema.
        /// </summary>
        [HttpGet]
        [Route("api/v1/CookBook/GetAll")]
        [PerformanceFilter]
        public IHttpActionResult GetAll()
        {
            JsonResult.Status = true;
            JsonResult.Object = RecipeCollection;
            return Ok(JsonResult);
        }

        /// <summary>
        /// Obtem uma receita especifica cadastrada no sistema.
        /// </summary>
        [HttpGet]
        [Route("api/v1/CookBook/GetById")]
        [PerformanceFilter]
        public IHttpActionResult GetById(int id)
        {
            JsonResult.Status = true;
            JsonResult.Object = RecipeCollection.Where(x => x.Id == id).FirstOrDefault();
            return Ok(JsonResult);
        }

        /// <summary>
        /// Salva uma receita nova no sistema.
        /// </summary>
        [HttpPost]
        [Route("api/v1/CookBook/Save")]
        [PerformanceFilter]
        public IHttpActionResult Save(RecipeVm entity)
        {
            var entityToEdit = RecipeCollection.FirstOrDefault(x => x.Id == entity.Id);
            if (entityToEdit != null)
            {
                entityToEdit.Id = entity.Id;
                entityToEdit.Calories = entity.Calories;
                entityToEdit.Ingredients = entity.Ingredients;
                entityToEdit.Portion = entity.Portion;
                entityToEdit.PreparationMode = entity.PreparationMode;
                entityToEdit.Title = entity.Title;

                if (entity.Ingredients.Any()) {
                    entityToEdit.Ingredients.Clear();
                    foreach (var item in entity.Ingredients) { entityToEdit.Ingredients.Add(item); }
                }
            }
            else
            {
                entity.Id = (RecipeCollection.Any()) ? RecipeCollection.Max(x => x.Id) + 1 : 1;
                RecipeCollection.Add(entity);
            }

            JsonResult.Status = true;           
            JsonResult.Object = RecipeCollection;
            return Ok(JsonResult);
        }

        /// <summary>
        /// Inativa uma receita ja cadastrada no sistema.
        /// </summary>
        [HttpDelete]
        [Route("api/v1/CookBook/Delete")]
        [PerformanceFilter]
        public IHttpActionResult Delete(int id)
        {
            JsonResult.Status = true;
            var itemToRemove = RecipeCollection.Single(x => x.Id == id);
            RecipeCollection.Remove(itemToRemove);
            JsonResult.Object = RecipeCollection;
            return Ok(JsonResult);
        }

        /// <summary>
        /// Obtem ingredientes de uma receita especifica cadastrada.
        /// </summary>
        [HttpGet]
        [Route("api/v1/CookBook/GetIngredientsByRecipeId")]
        [PerformanceFilter]
        public IHttpActionResult GetIngredientsByRecipeId(int id)
        {
            JsonResult.Status = true;
            var entity = RecipeCollection.Where(x => x.Id == id).FirstOrDefault();
            JsonResult.Object = entity.Ingredients;
            return Ok(JsonResult);
        }

        /// <summary>
        /// Obtem receitas que contenham o id do ingrediente procurado.
        /// </summary>
        [HttpGet]
        [Route("api/v1/CookBook/GetRecipesContainingIngredientById")]
        [PerformanceFilter]
        public IHttpActionResult GetRecipesContainingIngredientId(int id)
        {
            JsonResult.Status = true;
            var recipes = new List<RecipeVm>();

            foreach (var item in RecipeCollection)
            {
                if (item.Ingredients.Any())
                {
                    foreach (var ingredient in item.Ingredients)
                    {
                        if (ingredient.Id == id)
                        {
                            recipes.Add(item);
                        }
                    }
                }
            }

            JsonResult.Object = recipes;
            return Ok(JsonResult);
        }
    }
}