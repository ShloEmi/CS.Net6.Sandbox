namespace CSNet6Sandbox.Algorithms.PrettyPrint;

class Solution {
    public List<List<int>> prettyPrint(int A) {
        int mSize = 2*A-1;
        
        var m = new List<List<int>>(mSize);
        // fill each cell
        for(int c = 0; c<mSize; c++)
        {
            m.Add(new List<int>(mSize));
            
            for(int r = 0; r<mSize; r++)
            {
                int cc = Math.Abs((A-1)-c)+1;
                int rr = Math.Abs((A-1)-r)+1;
                
                m[c].Add(Math.Max(cc, rr));
            }
        }
           
        return m;
    }
}
