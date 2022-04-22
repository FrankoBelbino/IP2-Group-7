using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollect : MonoBehaviour
{
    public static int score;

    public GameObject Dog;
    public GameObject Parrot;

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject == Dog)
        {
            gameObject.SetActive(false);
            score += 1;
        }

        if (col.gameObject == Parrot)
        {
            gameObject.SetActive(false);
            score += 1;
        }


    }
}
