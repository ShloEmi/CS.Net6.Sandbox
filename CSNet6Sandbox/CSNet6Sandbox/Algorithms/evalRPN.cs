namespace CSNet6Sandbox.Algorithms.evalRPN;

class Solution {
    public int evalRPN(List<string> A) {
        var operations = new Stack<string>(A.Count / 7 /*~1:7 */) ;
        var operands = new Stack<int>(A.Count / 3 /*~2:7*/);
        int bracetsBalanceCount = 0;
        int acc = 0;
        
        int num;
        foreach(string s in A){
            if(string.IsNullOrEmpty(s)) continue;

            var st = s.Trim(' ');
            
            if(st == "(") bracetsBalanceCount++;
            
            // operand
            else if (int.TryParse(s, out num)) operands.Push(num);
            
            // operators:
            else if(st == "+")
                operations.Push(st);
            else if(st == "-")
                operations.Push(st);
            else if(st == "*")
                operations.Push(st);
            else if(st == "/")
                operations.Push(st);

            // ) case
            else if(st == ")") {
                if(bracetsBalanceCount == 0 )
                    return int.MinValue;    // unbalanced case:
                
                var operation = operations.Pop();
                if(operation == "+")
                    operands.Push(operands.Pop() + operands.Pop());
                else if(operation == "-")
                    operands.Push(operands.Pop() - operands.Pop());
                else if(operation == "*")
                    operands.Push(operands.Pop() * operands.Pop());
                else if(operation == "/")
                    operands.Push(operands.Pop() / operands.Pop());
                
                bracetsBalanceCount--;                
            }
            else
                return int.MinValue;    // unknown input case!            
        }
        
        if(bracetsBalanceCount == 0 )
            return int.MinValue;    // unbalanced case!
            
        return acc;
    }
}
