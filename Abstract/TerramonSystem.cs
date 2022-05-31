using TeaFramework.API;
using Terraria.ModLoader;

namespace Terramon.Abstract
{
    /// <summary>
    ///     Abstracted <see cref="ModSystem" /> serving as a base class for all Terramon systems.
    /// </summary>
    public abstract class TerramonSystem : ModSystem
    {
        public ITeaMod TeaMod => (ITeaMod) Mod;
    }
}