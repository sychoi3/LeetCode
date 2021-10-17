using System.Collections.Generic;

namespace Array {
    public class Solution {
        public IList<IList<int>> ThreeSum(int[] nums) {
            if(nums == null) return new List<IList<int>>();
            if(nums.Length < 3) return new List<IList<int>>();
            
            var result = new List<IList<int>>();
            System.Array.Sort(nums);
            for(int i = 0;i<nums.Length;i++){
                if(i > 0 && nums[i] == nums[i-1]) continue;
                var list = TwoSum(i, nums);
                result.AddRange(list);
            }
            return result;
        }
        
        public IList<IList<int>> TwoSum(int index, int[] nums){
            var result = new List<IList<int>>();
            
            var left = index+1;
            var right = nums.Length-1;
            while(left < right){
                
                if(left > index+1 && nums[left] == nums[left-1]) {left++; continue;}
                if(right < nums.Length-1 && nums[right] == nums[right+1]) {right--; continue;}
                
                var sum = nums[index]+nums[left]+nums[right];
                if(sum == 0)
                    result.Add(new List<int>{nums[index], nums[left], nums[right]});
                
                if(sum < 0) left++;
                else right--;
            }
            return result;
        }
    }
}