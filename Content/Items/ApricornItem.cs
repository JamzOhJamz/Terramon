using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terramon.Abstract;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Content.Items
{
    [Autoload(false)]
    public class ApricornItem : TerramonItem
    {
        public readonly Color TooltipColor;

        public ApricornItem(Color tooltipColor) {
            TooltipColor = tooltipColor;
        }

        public override string Texture => "Terramon/Assets/Items/Resources/Apricorns/" + Name;

        public override void SetStaticDefaults() {
            SacrificeTotal = 50;
        }

        public override void SetDefaults() {
            Item.width = 26;
            Item.height = 26;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.White;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine? nameLine = tooltips.FirstOrDefault(t => t.Name == "ItemName" && t.Mod == "Terraria");
            if (nameLine is not null) nameLine.OverrideColor = TooltipColor;
        }
    }
}