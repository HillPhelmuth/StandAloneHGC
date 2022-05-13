namespace StandAloneHGC.Core;

public class HyperGeometricCalc
{
    private static decimal BinomialCoefficient(int n, int k)
    {
        decimal result = 1;

        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }
        return result;
    }
    public static decimal HyperGeoOdds(int hits /*k*/, int deckSize /*N*/, int hitsInDeck /*K*/, int draws /*n*/)
    {
        decimal hitsBc = BinomialCoefficient(hitsInDeck, hits);
        decimal diffBc = BinomialCoefficient(deckSize - hitsInDeck, draws - hits);
        decimal drawDeckBc = BinomialCoefficient(deckSize, draws);
        return (hitsBc * diffBc) / drawDeckBc;
    }
    public static HyperResult GetHyperResult(int hits, int deckSize, int hitsInDeck, int draws)
    {
        var exact = HyperGeoOdds(hits, deckSize, hitsInDeck, draws);
        decimal less = 0;
        decimal lessEq = 0;
        decimal greater = 0;
        decimal greaterEq = 0;
        for (var i = 0; i < hits; i++)
        {
            less += HyperGeoOdds(i, deckSize, hitsInDeck, draws);
        }

        for (var j = 0; j <= hits; j++)
        {
            lessEq += HyperGeoOdds(j, deckSize, hitsInDeck, draws);
        }
        var maxDraw = Math.Min(hitsInDeck, draws);
        for (var h = hits + 1; h <= maxDraw; h++)
        {
            greater += HyperGeoOdds(h, deckSize, hitsInDeck, draws);
        }
        for (var ht = hits; ht <= maxDraw; ht++)
        {
            greaterEq += HyperGeoOdds(ht, deckSize, hitsInDeck, draws);
        }
        return new()
        {
            OddsExacly = exact,
            OddsLessThan = less,
            OddsLessThanOrEq = lessEq,
            OddsGreatorThan = greater,
            OddsGreatorThanOrEq = greaterEq
        };
    }
}
public class HyperResult
{
    public decimal OddsExacly { get; set; }
    public decimal OddsLessThan { get; set; }
    public decimal OddsGreatorThan { get; set; }
    public decimal OddsLessThanOrEq { get; set; }
    public decimal OddsGreatorThanOrEq { get; set; }
}