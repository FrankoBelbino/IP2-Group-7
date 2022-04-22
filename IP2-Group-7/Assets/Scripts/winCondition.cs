using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour
{
    public static int score;

    public GameObject Dog;
    public GameObject Parrot;

    void Update()
    {
        score = TrophyCollect.score;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject == Dog && col.gameObject == Parrot && score == 2)
        {
            Application.Quit();
        }
    } 
}
