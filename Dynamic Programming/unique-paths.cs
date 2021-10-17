namespace DynamicProgramming
{  
    public class Solution {
        public int UniquePaths(int m, int n) {
            var map = new int[m][];
            for(int i = 0;i<map.Length;i++){
                map[i] = new int[n];
            }
            
            for(int i =0;i<map.Length;i++){
                for(int j = 0;j<map[i].Length;j++){
                    if(i == 0 || j == 0) map[i][j] = 1;
                    else map[i][j] = map[i-1][j] + map[i][j-1];
                }
            }
            return map[m-1][n-1];   
        }
    }
}