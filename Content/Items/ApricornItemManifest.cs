using Microsoft.Xna.Framework;
using TeaFramework.API;
using Terramon.Common.Systems.Loading;

namespace Terramon.Content.Items
{
    public readonly struct ApricornItemManifest : IContentManifest
    {
        public readonly Color TooltipColor;

        public string Name { get; }

        public ApricornItemManifest(string name, Color tooltipColor) {
            Name = name;
            TooltipColor = tooltipColor;
        }

        public static ApricornItem MakeContent(ITeaMod teaMod, ApricornItemManifest manifest) {
            return new ApricornItem(manifest.TooltipColor)
            {
                ContentName = manifest.Name
            };
        }
    }
}