namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;

    public partial class FlaxseedOilRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            this.Recipes.Clear();

            var recipe = new Recipe();
            recipe.Init(
                name: "FlaxseedOil",  //noloc
                displayName: Localizer.DoStr("Flaxseed Oil"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(FlaxSeedItem), 12, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<FlaxseedOilItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
        }
    }
}