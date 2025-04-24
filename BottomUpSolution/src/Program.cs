namespace BottomUpSolution;

/* Bottom-Up (Tabulation) Dynamic Programming Approach
 * ===================================================
 * Recursive function:          isMatch[i,j] := str[0,i] matches pattern[0,j]
 * Base Case Initialization:    isMatch[0,0] is true - empty string matches empty pattern
 * Recursive Case: 
 *      Consider regex automata and taking a step from an [i,j] state
 *      Subcase 1: Consume a char and consume a token
 *                 isMatch[i,j] produces isMatch[i+1,j+1] because the (i+1)-th character matches (j+1)-th token
 *      Subcase 2: Consume a char and stay at token
 *                 isMatch[i,j] produces isMatch[i+1,j] because the (i+1)-th character can add to the quantified jth token
 *      Subcase 3: Don't consume a char and consume a token
 *                 isMatch[i,j] produces isMatch[i,j+1] because (j+1)-th token is quantified (0 char option)
 * 
 *      Entry (i,j) influences entries (i+1,j+1), (i+1,j), (i,j+1) or equivalently, for the purpose of recursive definition:
 *      Entry (i,j) is a function of entries (i-1,j-1), (i-1,j), (i,j-1)
 */
public static class Program
{
    private record Token(char C, bool IsZeroOrMore = false);

    private static IEnumerable<Token> Tokenize(string pattern)
    {
        for (int i = 1; i < pattern.Length; i++)
        {
            if (pattern[i] == '*') yield return new Token(pattern[i - 1], true);
            else if (pattern[i - 1] != '*') yield return new Token(pattern[i - 1]);
        }
        if (pattern[^1] != '*') yield return new Token(pattern[^1]);
    }

    public static bool IsMatch(string str, string pattern)
    {
        Token[] tokens = [.. Tokenize(pattern)];
        
        int m = str.Length, n = tokens.Length;
        bool[,] isMatchArr = new bool[m + 1, n + 1];
        
        isMatchArr[0, 0] = true;
        for (int j = 1; j <= n; j++)
            for (int i = 0; i <= m; i++)
                isMatchArr[i, j] = i >= 1 && (
                                         isMatchArr[i - 1, j - 1] && (str[i - 1] == tokens[j - 1].C || tokens[j - 1].C == '.') ||
                                         isMatchArr[i - 1, j] && tokens[j - 1].IsZeroOrMore && (str[i - 1] == tokens[j - 1].C || tokens[j - 1].C == '.')
                                    ) || isMatchArr[i, j - 1] && tokens[j - 1].IsZeroOrMore;
        return isMatchArr[m, n];
    }
}