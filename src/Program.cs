namespace DPRegexMatch;

using System.Collections.Generic;

public static class Program
{
    private record Token(char c, bool IsZeroOrMore = false);

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
        // Tokenize pattern
        Token[] tokens = [.. Tokenize(pattern)];
        
        // Bottom-Up (Tabulation) Dynamic Programming Approach
        // isMatch[i,j] := str[0,i] matches pattern[0,j]
        int m = str.Length, n = tokens.Length;
        bool[,] isMatchArr = new bool[m + 1, n + 1];
        
        bool isMatch(int i, int j) => i >= 0 && j >= 0 && i <= m && j <= n && isMatchArr[i,j];

        // Base Case Initialization: empty string matches empty pattern
        isMatchArr[0, 0] = true;

        /*
         * Consider regex automata and taking a step into an [i,j] state
         * 
         * Case 1: Consume a char and consume a token
         * isValid[i-1,j-1] produces isValid[i,j] because the i-th character matches j-th token
         * Case 2: Consume a char and stay at token
         * isValid[i-1,j] produces isValid[i,j] because the i-th character can add to the quantified jth token
         * Case 3: Don't consume a char and consume a token
         * isValid[i,j-1] produces isValid[i,j] because j-th token is quantified (0 char option)
         */
        for (int j = 1; j <= n; j++)
            for (int i = 0; i <= m; i++)
                isMatchArr[i, j] = isMatch(i - 1, j - 1) && (str[i - 1] == tokens[j - 1].c || tokens[j - 1].c == '.') ||
                                  isMatch(i - 1, j) && tokens[j - 1].IsZeroOrMore && (str[i - 1] == tokens[j - 1].c || tokens[j - 1].c == '.') ||
                                  isMatch(i, j - 1) && tokens[j - 1].IsZeroOrMore;
        return isMatch(m, n);
    }
}