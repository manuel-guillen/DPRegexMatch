namespace DPRegexMatchTests;

using static DPRegexMatch.Program;

public class UnitTests
{
    [Fact]
    public void Test_IsMatch_aa_a()
    {
        Assert.False(IsMatch("aa", "a"));
    }

    [Fact]
    public void Test_IsMatch_aa_aStar()
    {
        Assert.True(IsMatch("aa", "a*"));
    }

    [Fact]
    public void Test_IsMatch_ab_dotStar()
    {
        Assert.True(IsMatch("ab", ".*"));
    }

    [Fact]
    public void Test_IsMatch_aab_cStar_aStar_b()
    {
        Assert.True(IsMatch("aab", "c*a*b"));
    }

    [Fact]
    public void Test_IsMatch_ab_dotStar_c()
    {
        Assert.False(IsMatch("ab", ".*c"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar()
    {
        Assert.True(IsMatch("a", ".*"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar_a()
    {
        Assert.True(IsMatch("a", ".*a"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar_aStar()
    {
        Assert.True(IsMatch("a", ".*a*"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar_aStar_b()
    {
        Assert.False(IsMatch("a", ".*a*b"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar_aStar_bStar()
    {
        Assert.True(IsMatch("a", ".*a*b*"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar_aStar_bStar_c()
    {
        Assert.False(IsMatch("a", ".*a*b*c"));
    }

    [Fact]
    public void Test_IsMatch_a_dotStar_aStar_bStar_cStar()
    {
        Assert.True(IsMatch("a", ".*a*b*c*"));
    }

    [Fact]
    public void Test_IsMatch_mississippi_misStar_isStar_pDot()
    {
        Assert.False(IsMatch("mississippi", "mis*is*p*."));
    }

    [Fact]
    public void Test_IsMatch_ssissippi_sStar_isStar_pDot()
    {
        Assert.False(IsMatch("ssissippi", "s*is*p*."));
    }
}