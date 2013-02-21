using System;
using KRS.Model.KRS;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.Model.Infrastructure
{
    public class RecipesCookProcesses : KRSEntity
    {
        public virtual Recipe Recipe { get; set; }
        public virtual CookProcess CookProcess { get; set; }

        public int? ParentStep { get; set; }
        public int? Step { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
    }
}
