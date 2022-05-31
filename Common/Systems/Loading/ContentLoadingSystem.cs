﻿using Microsoft.Xna.Framework;
using Terramon.Abstract;
using Terramon.Content.Items;
using Terraria;

namespace Terramon.Common.Systems.Loading
{
    /// <summary>
    ///     Handles the loading of content utilizing loading manifests.
    /// </summary>
    public class ContentLoadingSystem : TerramonSystem
    {
        protected readonly ContentManifestCollection<ApricornItem, ApricornItemManifest> ApricornItems = new(ApricornItemManifest.MakeContent)
        {
            new ApricornItemManifest("BlackApricorn", new Color(68, 68, 68)),
            new ApricornItemManifest("BlueApricorn", new Color(72, 187, 234)),
            new ApricornItemManifest("GreenApricorn", new Color(52, 226, 150)),
            new ApricornItemManifest("PinkApricorn", new Color(214, 109, 220)),
            new ApricornItemManifest("RedApricorn", new Color(190, 49, 49)),
            new ApricornItemManifest("WhiteApricorn", Color.White),
            new ApricornItemManifest("YellowApricorn", new Color(253, 211, 129))
        };

        protected readonly ContentManifestCollection<PokeBallItem, PokeBallItemManifest> PokeBallItems = new(PokeBallItemManifest.MakeContent)
        {
            new PokeBallItemManifest("PokeBall", Item.sellPrice(silver: 5), new Color(255, 87, 87))
        };

        public override void OnModLoad() {
            base.OnModLoad();

            ApricornItems.AddAllContent(TeaMod);
            PokeBallItems.AddAllContent(TeaMod);
        }
    }
}