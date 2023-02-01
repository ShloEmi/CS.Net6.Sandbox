namespace CSNet6Sandbox.Algorithms.GrayCode;

// REM: wasted ~30m on Strategy-2, that lead to nowhere !! ==> waste of a lot of time ==> if you have a good working strategy with O(min-time) - don't wast moe!!
class Solution {
    public List<int> grayCode(int A) {
        if(A==0) return new List<int>();
        
        return grayCode(new HashSet<int>(), A, 0b0).ToList();
    }
    
    /*
    v       === visited
    nBit    === current bit to check
    s       === state
    */
    public HashSet<int> grayCode(HashSet<int> v, int A, int s) {
        if(!v.Contains(s)) v.Add(s);
        
        // xor, 1-negates ==> a:2^i
        int a=0b1;
        while(a < Math.Pow(A, 2)){            
            int ss = s ^ a; // negate only bit-a
            grayCode(v, A, ss);
            
            a<<=1;
        }
        
        return v;
    }    
}
