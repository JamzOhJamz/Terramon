using Microsoft.Xna.Framework;
using TeaFramework.API;
using Terramon.Common.Systems.Loading;

namespace Terramon.Content.Items
{
    public readonly struct PokeBallItemManifest : IContentManifest
    {
        public string Name { get; }

        public readonly int SellPrice;
        public readonly Color TooltipColor;

        public PokeBallItemManifest(string name, int sellPrice, Color tooltipColor) {
            Name = name;
            SellPrice = sellPrice;
            TooltipColor = tooltipColor;
        }

        public static PokeBallItem MakeContent(ITeaMod teaMod, PokeBallItemManifest manifest) {
            return new PokeBallItem(manifest.SellPrice, manifest.TooltipColor)
            {
                ContentName = manifest.Name
            };
        }
    }
}