namespace Terramon.API.CatchRates
{
    /// <summary>
    ///     Defines the catch rate calculator for a pokeball item.
    /// </summary>
    public interface ICatchRate
    {
        /// <summary>
        ///     Calculates the catch rate based on the given pokemon.
        /// </summary>
        /// <param name="pokemon">The pokemon the catch rate is being calculated for.</param>
        /// <returns>The catch rate.</returns>
        float CalculateRate(Pokemon pokemon);
    }
}