class Solution(object):
    
    def countNumbersLowerThanPivot(self,nums, pivot):
        below = 0
        for i in nums:
            if i<=pivot:
                below = below +1
        return below
        
        

    def findDuplicate(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        left = 1
        right = len(nums)
        pivot = int((left +right)/2)

        while right>=left:
            BelowPivot = self.countNumbersLowerThanPivot(nums,pivot)
            if BelowPivot<=pivot:
                left = pivot+1
            else:
                right = pivot-1
            pivot = int((left +right)/2)
        return left



nums = [3, 3, 3, 3, 3]
solution = Solution()
result = solution.findDuplicate(nums)
print(f"Duplicate number is: {result}")