public class 509Solution {
    public int Fib(int n) {
        if (n <= 0) {
            return 0;
        }
        
        if (n == 1) {
            return 1;
        }
        
        var n0 = 0;
        var n1 = 1;
        var idx = 2;        
        while (idx <= n) {
            var tmp = n1 + n0;
            n0 = n1;
            n1 = tmp;
            idx++;
        }
        return n1;
    }
}