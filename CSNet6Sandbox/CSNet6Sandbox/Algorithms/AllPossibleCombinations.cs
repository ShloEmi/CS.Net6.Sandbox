namespace CSNet6Sandbox.Algorithms.AllPossibleCombinations;

/// <remarks> Stopped after 1h7m, IDK why - I can't solve this simple recursion :/, will re-try later on..</remarks>
class Solution
{
    public List<string> specialStrings(List<string> A)
    {
        if (A == null || A.Count == 0) return new List<string>();

        return specialStrings(A[0], A.TakeLast(A.Count - 1).ToList()).ToList();
    }

    public IEnumerable<string> specialStrings(string A0, List<string> A)
    {
        if (!A.Any())
            foreach (char a in A0)
                yield return $"{a}";
        else
        {
            foreach (char a in A0)
                yield return $"{a}" + specialStrings(A[0], A.TakeLast(A.Count - 1).ToList()).ToList();
        }
    }
}
