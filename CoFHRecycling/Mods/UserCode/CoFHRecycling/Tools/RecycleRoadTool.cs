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
    using Eco.Gameplay.Settlements.ClaimStakes;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(BasicEngineeringSkill), 4)]
    public partial class RecycleRoadToolRecipe : RecipeFamily
    {
        public RecycleRoadToolRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "RecycleStoneRoadTool",  //noloc
                displayName: Localizer.DoStr("Recycle Stone Road Tool"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(StoneRoadToolItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<WoodPulpItem>(4)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(10, typeof(BasicEngineeringSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(RecycleRoadToolRecipe), start: 0.25f, skillType: typeof(BasicEngineeringSkill), typeof(BasicEngineeringFocusedSpeedTalent), typeof(BasicEngineeringParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Recycle Stone Road Tool"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Recycle Road Tool"), recipeType: typeof(RecycleRoadToolRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(ToolBenchObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    public partial class RecycleIronRoadToolRecipe : Recipe
    {
        public RecycleIronRoadToolRecipe()
        {
            this.Init(
                name: "RecycleIronRoadTool",  //noloc
                displayName: Localizer.DoStr("Recycle Iron Road Tool"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronRoadToolItem), 1, true)
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<IronBarItem>(2),
                    new CraftingElement<WoodPulpItem>(10)
                });
            // Perform post initialization steps for user mods and initialize our recipe instance as a tag product with the crafting system
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(ToolBenchObject), typeof(RecycleRoadToolRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
