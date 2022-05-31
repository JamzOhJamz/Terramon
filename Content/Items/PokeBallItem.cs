using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terramon.Abstract;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Content.Items
{
    [Autoload(false)]
    public class PokeBallItem : TerramonItem
    {
        protected readonly int SellPrice;
        protected readonly Color TooltipColor;

        public PokeBallItem(int sellPrice, Color tooltipColor) {
            SellPrice = sellPrice;
            TooltipColor = tooltipColor;
        }

        public override string Texture => "Terramon/Assets/Items/PokeBalls/" + Name;

        public override void SetStaticDefaults() {
            SacrificeTotal = 25;
        }

        public override void SetDefaults() {
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 999;
            Item.rare = ItemRarityID.White;
            Item.scale = 5f;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine? nameLine = tooltips.FirstOrDefault(t => t.Name == "ItemName" && t.Mod == "Terraria");
            if (nameLine is not null) nameLine.OverrideColor = TooltipColor;
        }
    }
}