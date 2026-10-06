using System;

// EXCEEDING REQUIREMENTS:
// The program includes a simple level system based on the player's score.
// As the player earns more points, their level increases.
// This adds an extra gamification feature to encourage continued progress.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}