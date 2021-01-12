public class Solution46
{
    private IList<IList<int>> result;

    public IList<IList<int>> Permute(int[] nums)
    {
        result = new List<IList<int>>();
        var currentPath = new List<int>();
        PermuteImpl(currentPath, nums.ToList());

        return result;
    }

    private void PermuteImpl(List<int> currentPath, List<int> nums)
    {
        if (!nums.Any())
        {
            result.Add(CloneList(currentPath));
            return;
        }

        foreach (var num in nums)
        {
            currentPath.Add(num);
            PermuteImpl(currentPath, nums.Where(n => n != num).ToList());
            currentPath.Remove(num);
        }
    }

    private List<int> CloneList(IList<int> list)
    {
        return list.Select(item => item).ToList();
    }
}