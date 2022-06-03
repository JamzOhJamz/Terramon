using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Terramon.Common.Systems.Loading
{
    public class RecipeBuilder
    {
        protected readonly List<(int, int)> Ingredients = new();
        protected int ResultAmount = 1;
        protected int TileType = -1;

        public virtual RecipeBuilder WithIngredient(int type, int amount) {
            Ingredients.Add((type, amount));
            return this;
        }

        public virtual RecipeBuilder WithIngredient(string name, int amount) {
            (string ns, string type) = ParseQualifiedName(name);

            Ingredients.Add((ModLoader.GetMod(ns).Find<ModItem>(type).Type, amount));
            return this;
        }

        public virtual RecipeBuilder WithResultAmount(int resultAmount) {
            ResultAmount = resultAmount;
            return this;
        }

        public virtual RecipeBuilder WithTileType(int tileType) {
            TileType = tileType;
            return this;
        }

        public virtual RecipeBuilder WithTileType(string name, int amount) {
            (string ns, string type) = ParseQualifiedName(name);

            TileType = ModLoader.GetMod(name).Find<ModTile>(type).Type;
            return this;
        }

        protected virtual (string ns, string type) ParseQualifiedName(string qualifiedName) {
            string[] split = qualifiedName.Split(':', 2);

            return (split[0], split[1]);
        }

        public virtual Action<ModItem> Build() {
            return item =>
            {
                Recipe recipe = item.CreateRecipe(ResultAmount);
                foreach ((int type, int amount) in Ingredients) recipe.AddIngredient(type, amount);
                recipe.AddTile(TileType);
                recipe.Create();
            };
        }
    }
}