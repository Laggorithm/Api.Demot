using System;

[Serializable]
public class Quest
{
    public int id; // Ensure this matches the JSON key exactly
    public string name; // Match the JSON key
    public string description; // Match the JSON key
    public int reward; // Match the JSON key

    // Override ToString() to print the quest details
    public override string ToString()
    {
        return $"Quest ID: {id}\nName: {name}\nDescription: {description}\nReward: {reward} Gold";
    }
}
