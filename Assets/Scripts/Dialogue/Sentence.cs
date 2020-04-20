using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Sentence {

    public string name;
    [TextArea(3, 5)]
    public string sentence;
    public float characterSpacing;
    public float textSpeed;

}
