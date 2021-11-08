using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button resumeButton, exitButton;
    public Image selectedButtonFlag;


    Vector3 resumeButtonInitialPosition, initiaScale;
    Vector3 initial_pos;
  

    float buttonGoal_pos;

    public float abductionVelocity;

    private bool moveStart, moveExit;


    void Start()
    {
        initial_pos = selectedButtonFlag.transform.position;

        resumeButton.Select();

        resumeButtonInitialPosition = resumeButton.transform.position;
        initiaScale = resumeButton.transform.localScale;

        resumeButton.onClick.AddListener(ResumeButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        buttonGoal_pos = selectedButtonFlag.transform.position.y;

        if (resumeButton.transform.position.y >= buttonGoal_pos - 10)
        {
            resumeButton.transform.position = resumeButtonInitialPosition;
            resumeButton.transform.localScale = initiaScale;
            moveStart = false;

            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }

        if (exitButton.transform.position.y >= buttonGoal_pos - 10)
        {
            Application.Quit();
        }

        if (EventSystem.current.currentSelectedGameObject == resumeButton.gameObject)
        {
            Vector3 goal_pos = resumeButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity * Time.unscaledDeltaTime) , initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (EventSystem.current.currentSelectedGameObject == exitButton.gameObject)
        {
            Vector3 goal_pos = exitButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity * Time.unscaledDeltaTime) , initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (moveStart && resumeButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(resumeButton);
        }

        if (moveExit && exitButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(exitButton);
        }

    }

    private void FixedUpdate()
    {

    }

    private void whenClicked(Button selectedButton)
    {
        selectedButton.transform.position = new Vector3(selectedButton.transform.position.x, Mathf.Lerp(selectedButton.transform.position.y, buttonGoal_pos, abductionVelocity * Time.unscaledDeltaTime) , selectedButton.transform.position.z);

        selectedButton.transform.localScale = selectedButton.transform.localScale * Mathf.Lerp(1.0f, 0.5f, abductionVelocity * Time.unscaledDeltaTime);

        selectedButton.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
    }

    private void ResumeButtonClick()
    {
        moveStart = true;
    }

    private void ExitButtonClick()
    {
        moveExit = true;
    }
}
