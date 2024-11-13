public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
       int [] prices = items.Select(i=>i[0]).ToArray();
       Array.Sort(prices,items);
       List<int[]> bestBeautyTillPrice = new List<int[]>();
       int lastPrice = 0;
       int MaximumBeauty = 0;
       foreach(int [] item in items){
        if (item[0]> lastPrice){
            bestBeautyTillPrice.Add([lastPrice,MaximumBeauty]);
            MaximumBeauty = Math.Max(MaximumBeauty,item[1]);
            lastPrice = item[0];
        }
        else{
            MaximumBeauty = Math.Max(MaximumBeauty,item[1]);
        }
       }
       bestBeautyTillPrice.Add([lastPrice,MaximumBeauty]);

       return queries.Select(i=>FindBestBeauty(i,bestBeautyTillPrice)).ToArray();

    }

    private int FindBestBeauty(int price, List<int[]> bestBeautyTillPrice)
    {
        int left = 0;
        int right = bestBeautyTillPrice.Count-1;
        while (left < right){
        int mid = (left+right)/2;
        if (bestBeautyTillPrice[mid][0]<=price){
            left = mid;
        }
        else{
            right=mid-1;
        }
        }
        return bestBeautyTillPrice[right][1];
    }
}