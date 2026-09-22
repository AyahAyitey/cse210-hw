using System;
using System.Collections.Generic;

// GratitudeActivity: A fourth activity added to exceed core requirements.
// The user writes one thing they are grateful for each round, then the program
// reflects all their entries back at the end, giving them a personal gratitude list
// to appreciate before finishing.
public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private List<string> _unusedPrompts;

    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity will help you focus on the positive in your life by guiding you to identify things you are grateful for. Taking time to notice the good around you can lift your mood and bring greater peace.")
    {
        _prompts = new List<string>
        {
            "Name something in nature that you are grateful for.",
            "Name a person who has positively influenced your life.",
            "Name a challenge that helped you grow.",
            "Name a simple pleasure you enjoyed recently.",
            "Name a talent or ability you are thankful to have.",
            "Name something about your home or shelter you are grateful for.",
            "Name a memory that makes you smile.",
            "Name something you learned this week that you are grateful for."
        };

        _unusedPrompts = new List<string>(_prompts);
    }

    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        Random random = new Random();
        int index = random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }

    public void Run()
    {
        DisplayStartingMessage();

        List<string> gratefulItems = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomPrompt());
            Console.Write("> ");
            string entry = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entry))
            {
                gratefulItems.Add(entry);
            }

            ShowSpinner(3);
        }

        Console.WriteLine();
        Console.WriteLine("Here is your gratitude list from this session:");
        Console.WriteLine("------------------------------------------------");
        for (int i = 0; i < gratefulItems.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {gratefulItems[i]}");
        }
        Console.WriteLine("------------------------------------------------");

        DisplayEndingMessage();
    }
}
