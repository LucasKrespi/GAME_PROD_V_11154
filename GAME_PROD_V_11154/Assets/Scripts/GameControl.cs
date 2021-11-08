using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public Canvas pauseMenu;
    private GameObject ship_gameObject;
    public static Transform ship_Transform;
    private PlayerMovement ship_PlayerMovement;
    public static GameControl singletonGamecontrol;

    public static List<Vector3> Occupied_pos;

    private float perlinNoiseStepOne = 0.2f;
    private float perlinNoiseStepTwo = 3.75f;

    //UIHud Varriables
    //Timer
    private TextMeshProUGUI timerText;
    private float timer;
    float time = 0;
    private int seconds;
    private int minutes;
    //Score
    private TextMeshProUGUI scoreText;
    //Lives
    [SerializeField]
    private List<Image> livesList;

    private void Awake()
    {
        singletonGamecontrol = this;
    }
    private void Start()
    {
        seconds = 0;
        minutes = 0;
        timer = 180;

        Cursor.lockState = CursorLockMode.Locked;

        ship_gameObject = GameObject.Find("Low_poly_UFO");

        ship_Transform = ship_gameObject.GetComponent<Transform>();
        ship_PlayerMovement = ship_gameObject.GetComponent<PlayerMovement>();

        Occupied_pos = new List<Vector3>(Pool.singletonPool.pooledItens.Count);

        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

    }
    void Update()
    {
        //UIHud
        TimerControl(timerText);
        scoreControl(scoreText);

        updateLives(ship_PlayerMovement.lives);

        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.gameObject.SetActive(true);
        }

        checkGameOver();

    }

    public float Noise(int x, int y)
    {
        float temp = Mathf.PerlinNoise(x * perlinNoiseStepOne, y * perlinNoiseStepOne) * perlinNoiseStepTwo;
        return temp;
    }

    public static bool isPosOccupied(Vector3 tested)
    {
        foreach(Vector3 t in Occupied_pos)
        {
            if( tested.x + 2 <= t.x &&
                tested.x - 2 >= t.x &&
                tested.z + 2 <= t.z &&
                tested.z - 2>= t.z )
            {
                return true;
            }
        }

        return false;
    }

    private void TimerControl(TextMeshProUGUI clock)
    {

        timer -= Time.deltaTime;

        minutes = (int)timer / 60;
        seconds = (int)((timer/60 - minutes) * 60);


        //Set layout of clock
        if(seconds < 10 && minutes < 10)
        {
            clock.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
        }
        else if (minutes < 10)
        {
            clock.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
        else 
        {
            clock.text = minutes.ToString() + ":" + seconds.ToString();
        }

        //set color of text
        if(minutes < 1)
        {
            if(seconds < 30)
            {
                clock.color = Color.red;
            }
            else
            {
                clock.color = Color.yellow;
            }
        }
        else
        {
            clock.color = Color.green;
        }

    }

    private void scoreControl(TextMeshProUGUI score)
    {
        //WTF magic that increase the score every second
        int timeSinceLastIncrease = (int)time;
        time += Time.deltaTime;

        if(timeSinceLastIncrease != (int)time)
        {
           ship_PlayerMovement.score++;
        }
        

        if (ship_PlayerMovement.score < 0)
        {
            score.text = "Score: 00000";
        }
        else if (ship_PlayerMovement.score < 10)
        {
            score.text = "Score: 0000" + ship_PlayerMovement.score.ToString();
        }
        else if (ship_PlayerMovement.score < 100)
        {
            score.text = "Score: 000" + ship_PlayerMovement.score.ToString();
        }
        else if (ship_PlayerMovement.score < 1000)
        {
            score.text = "Score: 00" + ship_PlayerMovement.score.ToString();
        }
        else if (ship_PlayerMovement.score < 10000)
        {
            score.text = "Score: 0" + ship_PlayerMovement.score.ToString();
        }
        else if (ship_PlayerMovement.score < 100000)
        {
            score.text = "Score: " + ship_PlayerMovement.score.ToString();
        }
    }

    private void updateLives(int currentLives)
    {
        if(currentLives < 5)
         livesList[currentLives].enabled = false;
    }

    private void checkGameOver()
    {
        if(ship_PlayerMovement.lives == 0 || (minutes == 0) && (seconds == 0))
        {
            Debug.Log("GAME OVER");
        }
    }
}
