using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opus.Cookbook.WebApi.Models
{
    public class RecipeVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Portion { get; set; }
        public int Calories { get; set; }
        public string PreparationMode { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }  

}