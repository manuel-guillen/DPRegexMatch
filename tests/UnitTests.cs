namespace DPRegexMatchTests;

using FluentAssertions;

using static DPRegexMatch.Program;

public class UnitTests
{
    [Theory]
    [InlineData("aa", "a", false)]
    [InlineData("aa", "a*", true)]
    [InlineData("ab", ".*", true)]
    [InlineData("aab", "c*a*b", true)]
    [InlineData("ab", ".*c", false)]
    [InlineData("a", ".*", true)]
    [InlineData("a", ".*a", true)]
    [InlineData("a", ".*a*", true)]
    [InlineData("a", ".*a*b", false)]
    [InlineData("a", ".*a*b*", true)]
    [InlineData("a", ".*a*b*c", false)]
    [InlineData("a", ".*a*b*c*", true)]
    [InlineData("mississippi", "mis*is*p*.", false)]
    [InlineData("ssissippi", "s*is*p*.", false)]
    public void Test_IsMatch(string input, string pattern, bool expected) => IsMatch(input, pattern).Should().Be(expected);
}