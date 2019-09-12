using System;
using System.Collections.Generic;

namespace hailstone.core
{
    /// <summary>
    /// Defines a hailstone number generator 
    /// </summary>
    public interface HailstoneNumberGenerator
    {
        /// <summary>
        /// Computes the hailstone number for the input.
        /// </summary>
        /// <param name="input">The number for which to generate a hailstone number.</param>
        /// <returns>The hailstone number corresponding to the input.</returns>
        long ComputeHailstoneNumber(long input);

        /// <summary>
        /// Generates the sequence of hailstone numbers for the input.
        /// </summary>
        /// <param name="input">The number for which to generate a hailstone number sequence.</param>
        /// <returns>The hailsone number sequence for the input.</returns>
        IEnumerable<long> GenerateSequence(long input);
    }
}
