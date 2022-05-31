using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terramon.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Content.Items.PokeBalls
{
	/// <summary>
	/// Base class for Poké Balls.
	/// </summary>
	public abstract class PokeBallItem : ModItem
	{
		readonly string prefix;
		readonly string tooltip;
		Color tooltipColor;

		public override string Texture => AssetDirectory.PokeBallItem + Name;

		public PokeBallItem(string prefix, string tooltip, int sellPrice, Color tooltipColor)
		{
			this.tooltipColor = tooltipColor;
			this.tooltip = tooltip;
			this.prefix = prefix;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(prefix + " Ball");
			Tooltip.SetDefault(tooltip);
			SacrificeTotal = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.White;
			Item.scale = 5f;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine nameLine = tooltips.FirstOrDefault(t => t.Name == "ItemName" && t.Mod == "Terraria");

			foreach (TooltipLine line2 in tooltips)
				if (line2.Mod == "Terraria" && line2.Name == "ItemName")
					line2.OverrideColor = tooltipColor;
		}
	}

	public class PokeBall : PokeBallItem
	{
		public PokeBall() : base(
		  "Poké",
		  "A device for catching wild Pokémon.\nIt is thrown like a ball at the target.\nIt is designed as a capsule system.",
		  Item.sellPrice(silver: 5),
		  new Color(255, 87, 87))
		{ }
	}
}
