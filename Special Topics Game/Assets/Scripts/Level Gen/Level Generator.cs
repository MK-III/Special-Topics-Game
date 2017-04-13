using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator {

    float difficulty = 20;
    public LevelGenerator(int difficulty)
    {
        this.difficulty = difficulty;
        int maxBranches = Random.Range(3, (int) (Mathf.Sqrt(difficulty) * 1.5));
    }
    
}
