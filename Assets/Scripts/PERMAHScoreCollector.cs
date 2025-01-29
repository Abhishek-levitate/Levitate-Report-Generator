using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TMPro;

public class PERMAHScoreCollector : MonoBehaviour
{
    public Transform Day1;
    public Transform Day2;
    public Transform Day3;
    public Transform Day4;
    public Transform Day5;

    private List<PERMAHScore> scores = new List<PERMAHScore>();

    public string CollectAndSerializeScores()
    {
        scores.Clear();
        
        CollectDayScore(Day1, 1);
        CollectDayScore(Day2, 2);
        CollectDayScore(Day3, 3);
        CollectDayScore(Day4, 4);
        CollectDayScore(Day5, 5);

        return JsonConvert.SerializeObject(scores);
    }

    private void CollectDayScore(Transform day, int dayNumber)
    {
        if (day == null) return;

        var score = new PERMAHScore
        {
            DayNumber = dayNumber.ToString(),
            Positive = day.GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text,
            Engagement = day.GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text,
            Relationships = day.GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text,
            Meaning = day.GetChild(4).GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text,
            Achievement = day.GetChild(5).GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text,
            Health = day.GetChild(6).GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text
        };
        scores.Add(score);
    }
}