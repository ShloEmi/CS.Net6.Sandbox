namespace CSNet6Sandbox.Algorithms.KthNodeFromMiddle;


 // Definition for singly-linked list.
 class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { this.val = x; this.next = null; }
}


// REM: stop at 22m, phone, Cont at 2h32m
class Solution {
    public int solve(ListNode A, int B) {
        var pA = A;
        int N = 0;
        while(pA!=null){
            pA=pA.next;
            N++;
        }
        
        int mid=N/2 + 1;
        Console.WriteLine($"N={N}, mid={mid}");
        if(B>=mid) return -1;

        pA = A;
        for(int i=mid-B; i>0; i--)
            pA = pA.next;
        
        return pA.val;        
    }
}
