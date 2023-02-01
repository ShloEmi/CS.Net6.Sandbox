using System.Linq;

namespace CSNet6Sandbox.Algorithms.SortArrayWithSquares;

class Solution {
    public List<int> solve(List<int> A) {
        var l = 0;
        int h = A.Count-1;
        
        var s = new Stack<int>(A.Count);
        while(l<=h){
            int ll = A[l]*A[l];
            int hh = A[h]*A[h];
            
            if ( ll>=hh ) {
                s.Push(ll);
                l++;
            } else {
                s.Push(hh);
                h++;
            }
        }
        
        return s.ToList();
    }
}
