using System;

namespace Terramon.API.CatchRates
{
    /// <summary>
    ///     Useful utilities for calculating catch rates.
    /// </summary>
    public static class CatchRateCalculator
    {
        /// <summary>
        ///     Calculates a safe-clamped catch rate.
        /// </summary>
        /// <param name="rateCalculator">The catch rate calculator to use.</param>
        /// <param name="pokemon">The pokemon to use.</param>
        /// <returns>A 0f-1f catch rate value.</returns>
        public static float CalculateRate(ICatchRate rateCalculator, Pokemon pokemon) {
            return Math.Clamp(rateCalculator.CalculateRate(pokemon), 0f, 1f);
        }

        /// <summary>
        ///     Calculates a safe-clamped catch rate as a byte.
        /// </summary>
        /// <param name="rateCalculator">The catch rate calculator to use.</param>
        /// <param name="pokemon">The pokemon to use.</param>
        /// <returns>A base game byte catch rate value.</returns>
        public static byte CalculateByteRate(ICatchRate rateCalculator, Pokemon pokemon) {
            return GetByteCatchRate(CalculateRate(rateCalculator, pokemon));
        }

        /// <summary>
        ///     Converts a base game byte catch rate value to a 0f-1f float catch rate value.
        /// </summary>
        /// <param name="rate">The base game byte catch rate.</param>
        /// <returns>The converted 0f-1f float catch rate.</returns>
        public static float GetCatchRateFromByte(byte rate) {
            return rate / 255f;
        }

        /// <summary>
        ///     Converts a 0f-1f float catch rate to a base game byte catch rate.
        /// </summary>
        /// <param name="rate">The 0f-1f float catch rate.</param>
        /// <returns>The converted base game bye catch rate.</returns>
        public static byte GetByteCatchRate(float rate) {
            return (byte) Math.Clamp(rate / 255, byte.MinValue, byte.MaxValue);
        }
    }
}