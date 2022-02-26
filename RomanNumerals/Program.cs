RomanCalculator calculator = new RomanCalculator();

Console.WriteLine(calculator.RomanToArabic("I")); // 1
Console.WriteLine(calculator.RomanToArabic("VIII")); // 8
Console.WriteLine(calculator.RomanToArabic("XXI")); // 21
Console.WriteLine(calculator.RomanToArabic("CLXXIII")); // 173
Console.WriteLine(calculator.RomanToArabic("MDCLXVI")); // 1666
Console.WriteLine(calculator.RomanToArabic("MDCCCXXII")); // 1822
Console.WriteLine(calculator.RomanToArabic("MCMLIV")); // 1954
Console.WriteLine(calculator.RomanToArabic("MCMXC")); // 1990
Console.WriteLine(calculator.RomanToArabic("MMVIII")); // 2008
Console.WriteLine(calculator.RomanToArabic("MMXIV")); // 2014


class RomanCalculator
{
    private (char, int)[] romanValues = new (char, int)[]
    {
        ('I', 1),
        ('V', 5),
        ('X', 10),
        ('L', 50),
        ('C', 100),
        ('D', 500),
        ('M', 1000)
    };

    public int RomanToArabic(string roman)
    {
        int total = 0;
        int lastVal = 0;
        for (var i = roman.Length-1; i >= 0; i--)
        {
            char c = roman[i];
            int curVal = RomanToArabic(c);

            total += curVal >= lastVal ? curVal : -curVal;

            lastVal = curVal;
        }

        return total;
    }

    private int RomanToArabic(char c)
    {
        foreach (var tuple in romanValues)
        {
            if (tuple.Item1 == c)
            {
                return tuple.Item2;
            }
        }

        return 0;
    }
}