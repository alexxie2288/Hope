using System;

public class RewardEvents
{
    public event Action<int> onRewardGained;
    public void RewardGained(int gold) 
    {
        if (onRewardGained != null) 
        {
            onRewardGained(gold);
        }
    }

    public event Action<int> onRewardChange;
    public void RewardChange(int gold) 
    {
        if (onRewardChange != null) 
        {
            onRewardChange(gold);
        }
    }
}