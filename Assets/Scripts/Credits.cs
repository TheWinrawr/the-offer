using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credits : MonoBehaviour
{

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RollCredits());
    }

    IEnumerator RollCredits() {
        yield return new WaitForSeconds(3f);
        text.text = "The Offer";
        yield return new WaitForSeconds(3f);
        text.text = "by Jon Hu";
        yield return new WaitForSeconds(3f);
        text.text = "Made for Ludum Dare 46";
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
