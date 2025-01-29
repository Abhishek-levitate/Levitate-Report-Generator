using UnityEngine;
using TMPro;

public class PERMAHAnalysisDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI analysisText;
    [SerializeField] private TextMeshProUGUI adviceText;
    [SerializeField] private TextMeshProUGUI recommendationsText;

    public void DisplayAnalysis(PERMAHAnalysis analysis)
    {
        analysisText.text = analysis.analysis.observations + " " + analysis.analysis.patterns + " " + analysis.analysis.opportunities;
        adviceText.text = analysis.advice.immediate_actions + " " + analysis.advice.progress_indicators + " " + analysis.advice.focus_areas;
        recommendationsText.text = analysis.recommended_experiences.name + " " + analysis.recommended_experiences.rationale;
    }
}