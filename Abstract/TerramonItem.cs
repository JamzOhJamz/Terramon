using TeaFramework.API;
using Terraria.ModLoader;

namespace Terramon.Abstract
{
    /// <summary>
    ///     Abstracted <see cref="ModItem" /> used for all items in Terramon.
    /// </summary>
    public abstract class TerramonItem : ModItem
    {
        public ITeaMod TeaMod => (ITeaMod) Mod;

        public abstract override string Texture { get; }

        public override string Name => ContentName ?? base.Name;

        public virtual string? ContentName { get; set; }

        protected override bool CloneNewInstances => true;
    }
}