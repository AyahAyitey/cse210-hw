using System;
using System.Collections.Generic;

// PromptGenerator class is responsible for storing and randomly selecting writing prompts.
// It does NOT know about entries, journals, or file I/O.
class PromptGenerator
{
    // Member variables use _underscoreCamelCase
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What am I most grateful for right now?",
            "What is one small win I had today?",
            "What challenged me today and how did I respond?",
            "What would make tomorrow even better than today?",
            "What is a goal I am currently working toward, and what did I do today to pursue it?"
        };
    }

    // Return a random prompt from the list
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
