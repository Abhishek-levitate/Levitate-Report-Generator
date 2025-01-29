using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class PERMAHApiManager : MonoBehaviour
{
    // Replace with your Cloud Function URL
    private const string API_ENDPOINT = "https://us-central1-levitate-ai-llm.cloudfunctions.net/handlePermahAnalysis";
    private string apiKey;

    [HideInInspector] public string systemContent;
    public PERMAHScoreCollector scoreCollector;
    public TextAsset apiConfig;
    public PERMAHAnalysisDisplay analysisDisplay;

    void Awake()
    {
        apiKey = apiConfig.text.Trim();
    }

    public void GenerateReport()
    {
        StartCoroutine(AnalyzePermahScores(scoreCollector.CollectAndSerializeScores(), analysisDisplay.DisplayAnalysis, null));
    }

    public IEnumerator AnalyzePermahScores(string scores, Action<PERMAHAnalysis> onComplete, Action<string> onError)
    {
        // Create the request body for our Cloud Function
        var requestBody = new
        {
            scores = scores,
            systemContent = systemContent
        };

        string jsonRequest = JsonConvert.SerializeObject(requestBody);
        
        using (UnityWebRequest webRequest = new UnityWebRequest(API_ENDPOINT, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonRequest);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            Debug.Log(apiKey);
            webRequest.SetRequestHeader("Authorization", $"Bearer {apiKey}");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                var responseJson = webRequest.downloadHandler.text;
                var apiResponse = JsonConvert.DeserializeObject<OpenAIResponse>(responseJson);
                Debug.Log($"API response: {apiResponse.choices[0].message.content}");
                var response = JsonConvert.DeserializeObject<PERMAHAnalysis>(apiResponse.choices[0].message.content);
                onComplete?.Invoke(response);
            }
            else
            {
                string errorMessage = $"API request failed: {webRequest.error}";
                onError?.Invoke(errorMessage);
                Debug.LogError(errorMessage);
                
                // Additional error information if available
                if (!string.IsNullOrEmpty(webRequest.downloadHandler.text))
                {
                    Debug.LogError($"Error details: {webRequest.downloadHandler.text}");
                }
            }
        }
    }
}