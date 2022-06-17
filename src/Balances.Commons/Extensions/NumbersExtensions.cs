using System.Globalization;

namespace Balances.Commons.Extensions;

public static class NumbersExtensions
{
    private const string NumberGroupSeparator = " ";
    private static readonly CultureInfo DefaultCultureInfo = new("en-US", false);

    public static string Format(this decimal value, int fraction = 2)
    {
        var nfi = DefaultCultureInfo.NumberFormat;
        nfi.NumberGroupSeparator = NumberGroupSeparator;
        return value.ToString($"N{fraction}", nfi);
    }

    public static decimal RoundMin(this decimal value, int fraction)
    {
        return Math.Round(value, fraction, MidpointRounding.ToZero);
    }

    public static decimal Maximize(this decimal value, int fraction = 2)
    {
        return value == 0
            ? value
            : Math.Round(Math.Ceiling(value * 100) / 100, fraction, MidpointRounding.AwayFromZero);
    }

    public static decimal Minimize(this decimal value, int fraction = 2)
    {
        return value == 0 ? value : Math.Round(Math.Ceiling(value * 100) / 100, fraction, MidpointRounding.ToZero);
    }
}