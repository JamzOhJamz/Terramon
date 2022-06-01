using System;
using Terramon.API;
using Terramon.API.CatchRates;

namespace Terramon.Content.CatchRates
{
    /// <summary>
    ///     A catch rate that uses a 0f-1f float as a percentage.
    /// </summary>
    public class SimpleChanceCatchRate : ICatchRate
    {
        public SimpleChanceCatchRate(float chance) {
            Chance = Math.Clamp(chance, 0f, 1f);
        }

        public float Chance { get; }

        public virtual float CalculateRate(Pokemon pokemon) {
            return Chance;
        }
    }
}