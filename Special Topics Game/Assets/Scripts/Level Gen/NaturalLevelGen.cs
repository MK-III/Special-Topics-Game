using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalLevelGen {
    public class Node
    {
        public Node room1;
        public Node room2;
        problemType problem;

        public Node(problemType problem)
        {
            this.problem = problem;
        }

        //Other data

    }

    public Node start;

    public NaturalLevelGen(int difficulty, int numberOfProblems)
    {
        Node start = new Node(problemType.none);
        this.start = start;

        Node stop = new Node(problemType.none);

        start.room1 = stop;
        start.room2 = stop;

        insertRooms(start.room1, stop, 1, problemType.keyGen);

    }

    public void insertRooms(Node a, Node b, int room, problemType desiredProblem)
    {
        Node c = new Node(desiredProblem);
        c.room1 = b;
        c.room2 = b;
        if(room == 1)
        {
            a.room1 = c;
        }
        else
        {
            a.room2 = c;
        }
    }
    public enum problemType
    {
        none,
        keyGen,
        heavyEnemy,
        trapHeavy
    }
	
}
