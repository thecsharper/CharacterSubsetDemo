var solution = new Solution();
string s1 = "epidemiologist";
string s2 = "refrigeration";
string s3 = "supercalifragilisticexpialodocious";
int result = solution.LongestCommonSubsequenceLength(s1, s2, s3);

Console.WriteLine($"Input strings: \"{s1}\", \"{s2}\", \"{s3}\"");
Console.WriteLine($"Length of longest common subsequence: {result}"); // Output: 5

public class Solution
{
    public int LongestCommonSubsequenceLength(string s1, string s2, string s3)
    {
        // Handle edge cases
        if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || string.IsNullOrEmpty(s3))
            return 0;

        int len1 = s1.Length, len2 = s2.Length, len3 = s3.Length;
        // Initialize 3D DP table
        int[,,] dp = new int[len1 + 1, len2 + 1, len3 + 1];

        // Fill DP table
        for (int i = 0; i <= len1; i++)
        {
            for (int j = 0; j <= len2; j++)
            {
                for (int k = 0; k <= len3; k++)
                {
                    if (i == 0 || j == 0 || k == 0)
                    {
                        dp[i, j, k] = 0; // Base case: empty prefix
                        continue;
                    }

                    // If characters match, include them
                    if (s1[i - 1] == s2[j - 1] && s2[j - 1] == s3[k - 1])
                    {
                        dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                    }
                    else
                    {
                        // Take maximum of excluding one character
                        dp[i, j, k] = Math.Max(dp[i - 1, j, k],
                                        Math.Max(dp[i, j - 1, k], dp[i, j, k - 1]));
                    }
                }
            }
        }

        return dp[len1, len2, len3];
    }
}