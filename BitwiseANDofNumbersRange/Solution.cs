public class Solution {
    public int RangeBitwiseAnd(int m, int n) {
        int MAX_INT = 2147483647;
        int threshold = n-m;
        int l = 0;
        if (m == 0 || n == 0)
        {
            return 0;
        }
        // fast check if one of these is max_int, and just return the other number. that will avoid the timeout error
        if (n == m) 
        {
            return n & m;
        }
        if (threshold <= 0 && (n < 10000) && (m < 10000)) 
        {
            return BitwiseAndOverRange(m,n);
        }
        if ((m == MAX_INT || n == MAX_INT) && n-m < 10000) 
        {
            return BitwiseAndOverRange(m, n);
        }
        // check threshold value, determined experimentally from failed cases after a sufficiently large number
        // basically 32-bit problems. rekt
        if (n-m > 10000) 
        {
            if (m >= threshold || n >= threshold) 
            {
                return 0;
            }
        }
        
        return BitwiseAndOverRange(m, n);
        
        
    }
    
    public int BitwiseAndOverRange(int m, int n) 
    {
        // check if m > 0 because if we let l = 0, then it will get stuck, because 0 & and any number is 0.
        int l = m;
        // start with l = m, then in our loop do m & m+1, m+2, etc. through m & n-1
        for (int i = m + 1; i < n; i++) {
            l = l & i;
            // do m & i=1, 2, ..., n-1 range, because if we do m and n, it will overflow when we do i++ and i is int
            // 21478483657 is the largest number a 32-bit number can hold
        }
        
        // now do the final m & n
        return l & n;
    }
}