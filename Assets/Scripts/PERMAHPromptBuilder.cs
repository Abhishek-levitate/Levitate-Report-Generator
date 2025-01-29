using UnityEngine;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

public class PERMAHPromptBuilder : MonoBehaviour
{
    public PERMAHScoreCollector scoreCollector;
    public PERMAHApiManager apiManager;
    public TextAsset[] promptFiles;
    private StringBuilder promptBuilder = new StringBuilder();

    void Awake()
    {
        apiManager.systemContent = BuildPrompt();
    }

    private string BuildPrompt()
    {
        promptBuilder.Clear();

        // Add content from TextAsset files
        foreach (var file in promptFiles)
        {
            if (file != null)
            {
                promptBuilder.AppendLine(file.text);
                promptBuilder.AppendLine("---");
            }
        }

        return promptBuilder.ToString();
    }
}