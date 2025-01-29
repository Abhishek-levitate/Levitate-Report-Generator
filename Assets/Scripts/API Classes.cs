using System;
using System.Collections.Generic;

[Serializable]
public class PERMAHAnalysis
{
    public Analysis analysis;
    public Advice advice;
    public RecommendedExperience recommended_experiences;
}

public class Analysis
{
    public string observations;
    public string patterns;
    public string opportunities;
}

public class Advice
{
    public string immediate_actions;

    public string progress_indicators;

    public string focus_areas;
}

public class RecommendedExperience
{
    public string name;
    public string rationale;
}

[Serializable]
public class Message
{
    public string role;
    public List<Content> content;
}

[Serializable]
public class Content
{
    public string type;
    public string text;
}

[Serializable]
public class ApiRequest
{
    public string model;
    public List<Message> messages;
    public Dictionary<string, string> response_format;
    public float temperature;
    public int max_completion_tokens;
    public float top_p;
    public float frequency_penalty;
    public float presence_penalty;
}

[Serializable]
public class OpenAIResponse
{
    public string id;
    public string @object;
    public long created;
    public string model;
    public List<Choice> choices;
    public Usage usage;
    public string service_tier;
    public string system_fingerprint;
}

[Serializable]
public class Choice
{
    public int index;
    public AssistantMessage message;
    public object logprobs;
    public string finish_reason;
}

[Serializable]
public class AssistantMessage
{
    public string role;
    public string content;
    public object refusal;
}

[Serializable]
public class Usage
{
    public int prompt_tokens;
    public int completion_tokens;
    public int total_tokens;
    public TokenDetails prompt_tokens_details;
    public TokenDetails completion_tokens_details;
}

[Serializable]
public class TokenDetails
{
    public int cached_tokens;
    public int audio_tokens;
    public int accepted_prediction_tokens;
    public int rejected_prediction_tokens;
}