using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sentence[] Sentences {
        get { return sentences; }
    }

    public float TextSpeed {
        get { return textSpeed; }
    }
    
    [SerializeField]
    private Sentence[] sentences;
    [SerializeField]
    private float textSpeed = 0.02f;
}
