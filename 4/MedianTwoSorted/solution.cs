
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int length = nums1.Length+nums2.Length;
        return Median(nums1,nums2,(length/2)+1,length %2 == 0);

        
    }

    private double Median(int[] nums1, int[] nums2, int midIndex,bool even)
    {
        int p1 = 0;
        int p2 = 0;
        int first =0;
        int second=0;
        while (p1+p2<midIndex){
            if (p1==nums1.Length){
                second = first;
                first = nums2[p2];
                p2++;
            }
            else if (p2==nums2.Length){
                second = first;
                first = nums1[p1];
                p1++;
            }
            else if (nums1[p1] > nums2[p2]){
                second = first;
                first = nums2[p2];
                p2++;
            }
            else{
                second = first;
                first = nums1[p1];
                p1++;
            }
        }
        return even?(double)(first+second)/2:first;
    }
}
