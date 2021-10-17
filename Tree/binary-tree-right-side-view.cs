
using System.Collections.Generic;
using System.Linq;

// https://leetcode.com/problems/binary-tree-right-side-view/

#region Definition for a binary tree node.
public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }
#endregion

public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        if(root == null) return new List<int>();

        var result = new List<int>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while(q.Count()>0){
            var size = q.Count();
            for(int i = 0;i<size;i++){
                var node = q.Dequeue();
                
                if(i == size-1) result.Add(node.val);

                if(node.left != null) q.Enqueue(node.left);
                if(node.right != null) q.Enqueue(node.right);
            }
        }
        return result;
    }
}