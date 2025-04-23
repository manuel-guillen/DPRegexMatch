# DPRegexMatch

Solving a RegEx Matching problem using dynamic programming.

## Problem
[LeetCode Problem #10](https://leetcode.com/problems/regular-expression-matching/description/)

Given an input string `s` and a pattern `p`, implement regular expression matching with support for '.' and '*' where:

    '.' Matches any single character.​​​​
    '*' Matches zero or more of the preceding element.

The matching should cover the entire input string (not partial).

## Solution Approach
Use a bottom-up dynamic programming approach (build table up from base case to final solution) after figuring out
recursive relationship between problem and neighboring subproblems.

