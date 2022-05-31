using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terramon.Common;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Content.Items.Resources
{
	/// <summary>
	/// Base class for Apricorns.
	/// </summary>
    public abstract class ApricornItem : ModItem
    {
		readonly string prefix;
		Color tooltipColor;

		public override string Texture => AssetDirectory.ApricornsItem + Name;

		public ApricornItem(string prefix, Color tooltipColor)
		{
			this.prefix = prefix;
			this.tooltipColor = tooltipColor;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(prefix + " Apricorn");
			Tooltip.SetDefault("A special fruit seemingly related to berries."
							   + "\nCan be used to craft assorted Poké Balls.");
			SacrificeTotal = 50;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 999;
			Item.value = 500;
			Item.rare = ItemRarityID.White;
			Item.scale = 1f;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine nameLine = tooltips.FirstOrDefault(t => t.Name == "ItemName" && t.Mod == "Terraria");

			foreach (TooltipLine line2 in tooltips)
				if (line2.Mod == "Terraria" && line2.Name == "ItemName")
					line2.OverrideColor = tooltipColor;
		}
	}

	public class BlackApricorn : ApricornItem
    {
		public BlackApricorn() : base("Black", new Color(68, 68, 68)) { }
	}

	public class BlueApricorn : ApricornItem
	{
		public BlueApricorn() : base("Blue", new Color(72, 187, 234)) { }
	}

	public class GreenApricorn : ApricornItem
	{
		public GreenApricorn() : base("Green", new Color(52, 226, 150)) { }
	}

	public class PinkApricorn : ApricornItem
	{
		public PinkApricorn() : base("Pink", new Color(214, 109, 220)) { }
	}

	public class RedApricorn : ApricornItem
	{
		public RedApricorn() : base("Red", new Color(190, 49, 49)) { }
	}

	public class WhiteApricorn : ApricornItem
	{
		public WhiteApricorn() : base("White", Color.White) { }
	}

	public class YellowApricorn : ApricornItem
	{
		public YellowApricorn() : base("Yellow", new Color(253, 211, 129)) { }
	}
}
