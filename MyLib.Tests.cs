namespace propertybasedtesting;

using FsCheck;
using FsCheck.Xunit;

public class MyLibTests
{













/*

                          ███████████  ███████████      ███████    ███████████  ██████████ ███████████   ███████████ █████ █████
                         ░░███░░░░░███░░███░░░░░███   ███░░░░░███ ░░███░░░░░███░░███░░░░░█░░███░░░░░███ ░█░░░███░░░█░░███ ░░███
                          ░███    ░███ ░███    ░███  ███     ░░███ ░███    ░███ ░███  █ ░  ░███    ░███ ░   ░███  ░  ░░███ ███
                          ░██████████  ░██████████  ░███      ░███ ░██████████  ░██████    ░██████████      ░███      ░░█████
                          ░███░░░░░░   ░███░░░░░███ ░███      ░███ ░███░░░░░░   ░███░░█    ░███░░░░░███     ░███       ░░███
                          ░███         ░███    ░███ ░░███     ███  ░███         ░███ ░   █ ░███    ░███     ░███        ░███
                          █████        █████   █████ ░░░███████░   █████        ██████████ █████   █████    █████       █████
                         ░░░░░        ░░░░░   ░░░░░    ░░░░░░░    ░░░░░        ░░░░░░░░░░ ░░░░░   ░░░░░    ░░░░░       ░░░░░



                                            ███████████    █████████    █████████  ██████████ ██████████
                                           ░░███░░░░░███  ███░░░░░███  ███░░░░░███░░███░░░░░█░░███░░░░███
                                            ░███    ░███ ░███    ░███ ░███    ░░░  ░███  █ ░  ░███   ░░███
                                            ░██████████  ░███████████ ░░█████████  ░██████    ░███    ░███
                                            ░███░░░░░███ ░███░░░░░███  ░░░░░░░░███ ░███░░█    ░███    ░███
                                            ░███    ░███ ░███    ░███  ███    ░███ ░███ ░   █ ░███    ███
                                            ███████████  █████   █████░░█████████  ██████████ ██████████
                                           ░░░░░░░░░░░  ░░░░░   ░░░░░  ░░░░░░░░░  ░░░░░░░░░░ ░░░░░░░░░░



                                   ███████████ ██████████  █████████  ███████████ █████ ██████   █████   █████████
                                  ░█░░░███░░░█░░███░░░░░█ ███░░░░░███░█░░░███░░░█░░███ ░░██████ ░░███   ███░░░░░███
                                  ░   ░███  ░  ░███  █ ░ ░███    ░░░ ░   ░███  ░  ░███  ░███░███ ░███  ███     ░░░
                                      ░███     ░██████   ░░█████████     ░███     ░███  ░███░░███░███ ░███
                                      ░███     ░███░░█    ░░░░░░░░███    ░███     ░███  ░███ ░░██████ ░███    █████
                                      ░███     ░███ ░   █ ███    ░███    ░███     ░███  ░███  ░░█████ ░░███  ░░███
                                      █████    ██████████░░█████████     █████    █████ █████  ░░█████ ░░█████████
                                     ░░░░░    ░░░░░░░░░░  ░░░░░░░░░     ░░░░░    ░░░░░ ░░░░░    ░░░░░   ░░░░░░░░░



















                Property based testing is the construction of tests such that,
                when these tests are fuzzed, failures in the test reveal problems
                with the system under test that could not have been revealed
                by direct fuzzing of that system.




















 */


































    [Property]
    public Property The_sum_of_two_numbers_is_bigger_than_one_of_the_numbers(int a, int b)
    {
        var sum = MyLib.Sum(a, b);
        return (sum > a || sum > b).ToProperty();
    }






































    [Property]
    public Property The_sum_of_two_numbers_is_bigger_than_one_of_the_numbers2(int a, int b)
    {
        var sum = MyLib.Sum(a, b);
        return (sum > a || sum > b)
            .ToProperty()
            .When(a != 0 && b != 0);
    }









































    [Property]
    public Property The_sum_of_two_numbers_is_bigger_than_one_of_the_numbers3(int a, int b)
    {
        var sum = MyLib.Sum(a, b);
        return (sum > a || sum > b)
            .ToProperty()
            .When(a > 0 && b > 0)
            .Collect("The sum: " + sum);
    }







































    [Property]
    public Property The_sum_of_two_numbers_is_bigger_than_one_of_the_numbers4(PositiveInt a, PositiveInt b)
    {
        var x = a.Get;
        var y = b.Get;
        var sum = MyLib.Sum(x, y);
        return (sum > x|| sum > y)
            .ToProperty()
            .Collect("The sum: " + sum);
    }

    /*
     PositiveInt represent an integer bigger than zero
     NonZeroInt represent an integer which isn’t zero
     NonNegativeInt represent an integer which isn’t below zero
     IntWithMinMax represent an integer that can contain the int.Min and int.Max values
     NonNull<T> wraps a type to prevent null being generated
     NonEmptyArray<T> represent an array which isn’t empty
     NonEmptySet<T> represent a set which isn’t empty
     NonEmptyString represent a string which isn’t empty
     StringNoNulls represent a string without null characters (‘00’)
     NormalFloat represent a float which isn’t infinite or NaN
     Interval represent an integer interval
     IPv4Address represents an IPv4 Address
     IPv6Address represents an IPv6 Address
    ...
     */
























    private static class MyGenerator
    {
        public static Arbitrary<int> Generate()
            => Arb.Default.Int32().Filter(i => i > 0);
    }

    [Property(Arbitrary = new[] { typeof(MyGenerator) })]
    public Property The_sum_of_two_numbers_is_bigger_than_one_of_the_numbers5(int a, int b)
    {
        var sum = MyLib.Sum(a, b);
        return (sum > a || sum > b)
            .ToProperty()
            .Collect("The sum: " + sum);
    }
}























//[FsCheck: Random Testing for .NET] (https://fscheck.github.io/FsCheck/)

//[Writing Better Tests Than Humans Can Part 1: FsCheck Property Tests in C# – Aaronontheweb (aaronstannard.com)](https://aaronstannard.com/fscheck-property-testing-csharp-part1/)
//[Property-Based Testing with C# | Codit](https://www.codit.eu/blog/property-based-testing-with-c/)

























//       █████   █████████   █████   █████   █████████
//      ░░███   ███░░░░░███ ░░███   ░░███   ███░░░░░███
//       ░███  ░███    ░███  ░███    ░███  ░███    ░███
//       ░███  ░███████████  ░███    ░███  ░███████████
//       ░███  ░███░░░░░███  ░░███   ███   ░███░░░░░███
// ███   ░███  ░███    ░███   ░░░█████░    ░███    ░███
//░░████████   █████   █████    ░░███      █████   █████
// ░░░░░░░░   ░░░░░   ░░░░░      ░░░      ░░░░░   ░░░░░
//

// https://jqwik.net/


