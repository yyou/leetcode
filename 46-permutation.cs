using System;
using System.Collections.Generic;
using System.Linq;

public class Solution46
{
    private IList<IList<int>> _permutationResult;

    public IList<IList<int>> Permute(int[] nums)
    {
        _permutationResult = new List<IList<int>>();
        var selectedNumbers = new List<int>();
        PermuteImpl(selectedNumbers, nums.ToList());

        return _permutationResult;
    }

    private void PermuteImpl(List<int> selectedNumbers, List<int> candidates)
    {
        if (!candidates.Any())
        {
            _permutationResult.Add(CloneList(selectedNumbers));
            return;
        }

        foreach (var candidate in candidates)
        {
            selectedNumbers.Add(candidate);
            PermuteImpl(selectedNumbers, candidates.Where(num => num != candidate).ToList());
            selectedNumbers.Remove(candidate);
        }
    }

    private List<int> CloneList(IList<int> list)
    {
        return list.Select(item => item).ToList();
    }
}