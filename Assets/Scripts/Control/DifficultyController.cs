using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
   public struct Difficulty
    {
        // "low" and "high" defined the minimum and maximum amount of time in seconds that the player has to fulfill a customer request 
        public int low;
        public int high;
        public int maxRequests;
    }
    public static Difficulty difficulty;
    // This declaration is the global difficulty for the game
}
