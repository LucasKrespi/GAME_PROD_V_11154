using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimation : MonoBehaviour
{
    public Canvas DiedLives;
    public Canvas DiedTime;


    void Start()
    {
        if (PlayerPrefs.GetInt("gameover") == 0)
        {
            DiedTime.gameObject.SetActive(false);
        }
        else
        {
            DiedLives.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillCanvas()
    {
        DiedLives.gameObject.SetActive(false);

        DiedTime.gameObject.SetActive(false);
    }
}
