namespace CSNet6Sandbox.Algorithms.RedundantBraces;

class Solution
{
    // Strategy-1: (Operand1 ~Operator Operand2) - is valid, meaning '(' && op1 && operator && ')' is a valid combo only.
    // Stopped at T+58, failed to:      A : "(a*(b+c)*(d+e)*(a+c))"
    public int braces(string A)
    {
        // if (A==null || A.Length<1 || A[0]!='(') return 1;
        
        var s = new Stack<char>(A.Length);
        var s1 = new Stack<char>(A.Length);

        foreach (char c in A)
            s1.Push(c);

        while (s1.Count > 0)
        {
            char c = s1.Pop();
            if (c == '(')
            {
                char c1;
                do
                {
                    if (s1.Count == 0) return 1;

                    c1 = s1.Pop();
                    if (c1 == '(') return 1;
                } while (c1 != ')');
                
                s.Push('x');
            }
            else
                s.Push(c);
        }
        
        while(s1.Count>0)
            if("()".Contains(s1.Pop())) return 1;
        
        return 0;
    }
}
