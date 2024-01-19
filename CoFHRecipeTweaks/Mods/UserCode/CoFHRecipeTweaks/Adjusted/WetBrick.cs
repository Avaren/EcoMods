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

    public partial class WetBrickRecipe : RecipeFamily
    {
        partial void ModsPreInitialize()
        {
            this.Recipes.Clear();

            var recipe = new Recipe();
            recipe.Init(
                name: "WetBrick",  //noloc
                displayName: Localizer.DoStr("Wet Brick"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SandItem), 3, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)),
                    new IngredientElement(typeof(ClayItem), 12, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)),
                    new IngredientElement(typeof(WoodenMoldItem), 4, typeof(PotterySkill), typeof(PotteryLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WetBrickItem>(4),
                    new CraftingElement<WoodenMoldItem>(typeof(PotterySkill), 2, typeof(PotteryLavishResourcesTalent))
                });
            this.Recipes = new List<Recipe> { recipe };
        }
    }
}