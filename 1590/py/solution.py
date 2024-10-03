class Solution(object):
    def minSubarray(self, nums, p):
        """
        :type nums: List[int]
        :type p: int
        :rtype: int
        """
        runningSum = 0
        leftSum = []
        for i in nums:
            runningSum = (runningSum + i )%p
            leftSum.append(runningSum)
        rightSum = []
        for i in nums:
            runningSum = (runningSum - i )%p
            rightSum.append(runningSum)


        dictionary= dict()
        dictionary[0] = -1 

        minVal = 100001
        for i in range(len(nums)):
            dictionary[leftSum[i]]=i
            if dictionary.get((p-rightSum[i])%p,-2) !=-2:
                minVal = min(minVal, i-dictionary[(p-rightSum[i])%p])
        if minVal == len (nums):
            return -1
        return minVal
    
sol = Solution()
print(sol.minSubarray([8,32,31,18,34,20,21,13,1,27,23,22,11,15,30,4,2],148))

nums =[8,32,31,18,34,20,21,13,1,27,23,22,11,15,30,4,2]
p = 148
for i in range(len(nums)-7):
    print((sum(nums[0:i])+ sum(nums[i+7:]))%148)
trial = sum(nums[7:])
print ("hi")