using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button startButton, highScoreButton, exitButton;
    public Image selectedButtonFlag;

    Vector3 initial_pos;

    float buttonGoal_pos;

    public float abductionVelocity;

    private bool moveStart, moveExit, moveHighScore;


    void Start()
    {
        initial_pos = selectedButtonFlag.transform.position;

        startButton.Select();

        startButton.onClick.AddListener(StartButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
        highScoreButton.onClick.AddListener(HighScoreButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        buttonGoal_pos = selectedButtonFlag.transform.position.y;

        if(startButton.transform.position.y >= buttonGoal_pos - 10)
        {
            SceneManager.LoadScene(1);
        }

        if (exitButton.transform.position.y >= buttonGoal_pos - 10)
        {
            Application.Quit();
        }
    }
    private void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == startButton.gameObject)
        {
            Vector3 goal_pos = startButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (EventSystem.current.currentSelectedGameObject == highScoreButton.gameObject)
        {
            Vector3 goal_pos = highScoreButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (EventSystem.current.currentSelectedGameObject == exitButton.gameObject)
        {
            Vector3 goal_pos = exitButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }


        if (moveStart && startButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(startButton);
        }

        if (moveExit && exitButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(exitButton);
        }


        if (moveHighScore && highScoreButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(highScoreButton);
        }
    }

    private void whenClicked(Button selectedButton)
    {
        selectedButton.transform.position = new Vector3(selectedButton.transform.position.x, Mathf.Lerp(selectedButton.transform.position.y, buttonGoal_pos, abductionVelocity), selectedButton.transform.position.z);

        selectedButton.transform.localScale = selectedButton.transform.localScale * Mathf.Lerp(1.0f, 0.5f, abductionVelocity);

        selectedButton.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
    }

    private void StartButtonClick()
    {
        moveStart = true;
    }

    private void ExitButtonClick()
    {
        moveExit = true;
    }

    private void HighScoreButtonClick()
    {
        moveHighScore = true;
    }
}
