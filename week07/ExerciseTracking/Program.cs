// Exercise Tracking Program
// Demonstrates inheritance, encapsulation, and polymorphism

// Create one instance of each activity type
Running running = new Running("03 Nov 2022", 30, 3.0);
Cycling cycling = new Cycling("03 Nov 2022", 45, 12.0);
Swimming swimming = new Swimming("03 Nov 2022", 60, 20);

// Put all activities into a single list (polymorphism via base class reference)
List<Activity> activities = new List<Activity>();
activities.Add(running);
activities.Add(cycling);
activities.Add(swimming);

// Iterate and call GetSummary on each — polymorphic dispatch at work
foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}
