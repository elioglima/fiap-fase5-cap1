using System.Diagnostics.CodeAnalysis;

namespace Greenlight.Utils
{
    public class Validates
    {
        internal static bool IsNotNull(string? obj) => obj != null;


        private static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
    }
}
