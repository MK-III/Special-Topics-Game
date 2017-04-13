using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator {

    int difficultyCap = 20;
    int difficultyMin = 10;
    int actualDifficulty;

    public LevelGenerator(int difficultyCap, int difficultyMin)
    {
        this.difficultyCap = difficultyCap;
        this.difficultyMin = difficultyMin;
        int numberOfBranches = Random.Range((int)(Mathf.Sqrt(difficultyCap) * 1.5) - 4, (int) (Mathf.Sqrt(difficultyCap) * 1.5));

        this.actualDifficulty = (numberOfBranches / 15) * 100;
    }
    
}
