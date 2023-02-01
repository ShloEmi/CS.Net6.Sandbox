namespace CSNet6Sandbox.Algorithms.KthRowOfPascalsTriangle;

class Solution {
    public List<int> getRow(int A) {
        if(A<1)
            return null;
            
        var c = new List<int>(1) {1};
        if(A==1) 
            return c;
        
        return getRow(A-1, c);
    }
    
    protected List<int> getRow(int A, List<int> aC) {
        if(A==1) 
            return aC;
            
        var c = new List<int> (aC.Count + 1);
        
        c.Add(1);        
        for(int i=1; i<aC.Count; i++)
            c.Add(aC[i-1] + aC[i] );
        c.Add(1);
        
        return getRow(A-1, c);
    }
}
