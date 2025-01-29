[System.Serializable]
public struct PERMAHScore
{
    public string DayNumber;
    public string Positive;
    public string Engagement;
    public string Relationships;
    public string Meaning;
    public string Achievement;
    public string Health;

    public PERMAHScore(string dayNumber, string positive, string engagement, string relationships, 
                      string meaning, string achievement, string health)
    {
        DayNumber = dayNumber;
        Positive = positive;
        Engagement = engagement;
        Relationships = relationships;
        Meaning = meaning;
        Achievement = achievement;
        Health = health;
    }
}