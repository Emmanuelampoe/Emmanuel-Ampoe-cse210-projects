using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice != "6")
            {
                Console.WriteLine("Invalid choice. Please choose 1-6.");
            }
        }

        Console.WriteLine("Thanks for using Eternal Quest!");
    }

   public void DisplayPlayerInfo()
{
    int level = (_score / 500) + 1;

    Console.WriteLine($"You have {_score} points.");
    Console.WriteLine($"Level: {level}");
}

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            string checkbox = _goals[i].IsComplete() ? "[X]" : "[ ]";

            Console.WriteLine(
                $"{i + 1}. {checkbox} {_goals[i].GetDetailsString()}"
            );
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write(
                "How many times does this goal need to be accomplished for a bonus? "
            );
            int target = int.Parse(Console.ReadLine());

            Console.Write(
                "What is the bonus for accomplishing it that many times? "
            );
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(name, description, points, target, bonus)
            );
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber < 0 || goalNumber >= _goals.Count)
        {
            Console.WriteLine("Invalid goal.");
            return;
        }

        Goal goal = _goals[goalNumber];

        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("That goal has already been completed.");
            return;
        }

        int pointsEarned = goal.GetPoints();

        if (goal is ChecklistGoal checklistGoal)
        {
            bool wasComplete = checklistGoal.IsComplete();

            checklistGoal.RecordEvent();

            if (!wasComplete && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.GetBonus();
            }
        }
        else
        {
            goal.RecordEvent();
        }

        _score += pointsEarned;

        Console.WriteLine(
            $"Congratulations! You have earned {pointsEarned} points!"
        );
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] typeAndData = lines[i].Split(':');
            string goalType = typeAndData[0];
            string[] data = typeAndData[1].Split(',');

            string name = data[0];
            string description = data[1];
            int points = int.Parse(data[2]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(data[3]);

                SimpleGoal goal =
                    new SimpleGoal(name, description, points);

                if (isComplete)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(name, description, points)
                );
            }
            else if (goalType == "ChecklistGoal")
            {
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int amountCompleted = int.Parse(data[5]);

                _goals.Add(
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus,
                        amountCompleted
                    )
                );
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}