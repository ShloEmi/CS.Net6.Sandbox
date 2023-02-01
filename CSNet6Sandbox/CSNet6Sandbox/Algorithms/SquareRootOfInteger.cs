namespace CSNet6Sandbox.Algorithms.SquareRootOfInteger;

class Solution {
    public int sqrt(int A) {
        if(A==0) return 0;
        if(A==1) return 1;
        if(A==2) return 1;
        
        long l=0;
        long h=((long)A+1)/2;
        
        long lhs;
        long avg;
        while(l+1 != h){
            avg = (l+h)/2;
            lhs=avg*avg;
            
            Console.WriteLine($"l={l}, h={h}, avg={avg}, lhs={lhs}");
            if(lhs== A) return (int)avg;
            
            if(lhs<A) l=avg;
            else h=avg;
        }
        
        return (int)l;
    }
}
