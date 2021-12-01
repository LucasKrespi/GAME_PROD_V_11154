using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HighScoreButtonManager : MonoBehaviour
{
    public Button mainMenuButton, exitButton;
    public Image selectedButtonFlag;
    public SoundManager soundManager;


    Vector3 initial_pos;

    float buttonGoal_pos;

    public float abductionVelocity;

    private bool moveMainMenu, moveExit;

    void Start()
    {

        soundManager = SoundManager.soundManagerInstace;


        soundManager.StopSound("BackgroundSound");
        soundManager.PlaySound("Lucas");



        initial_pos = selectedButtonFlag.transform.position;

        mainMenuButton.Select();

        mainMenuButton.onClick.AddListener(MainMenuButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
 
    }

    // Update is called once per frame
    void Update()
    {
        buttonGoal_pos = selectedButtonFlag.transform.position.y;

        if (mainMenuButton.transform.position.y >= buttonGoal_pos - 10)
        {
            SceneManager.LoadScene(0);
            soundManager.StopSound("Lucas");
        }

        if (exitButton.transform.position.y >= buttonGoal_pos - 10)
        {
            Application.Quit();
        }
        
    }

    private void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == mainMenuButton.gameObject)
        {
            Vector3 goal_pos = mainMenuButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (EventSystem.current.currentSelectedGameObject == exitButton.gameObject)
        {
            Vector3 goal_pos = exitButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }


        if (moveMainMenu && mainMenuButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(mainMenuButton);
        }

        if (moveExit && exitButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(exitButton);
        }

    }


    private void whenClicked(Button selectedButton)
    {
        selectedButton.transform.position = new Vector3(selectedButton.transform.position.x, Mathf.Lerp(selectedButton.transform.position.y, buttonGoal_pos, abductionVelocity), selectedButton.transform.position.z);

        selectedButton.transform.localScale = selectedButton.transform.localScale * Mathf.Lerp(1.0f, 0.5f, abductionVelocity);

        selectedButton.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
    }

    private void MainMenuButtonClick()
    {
        moveMainMenu = true;
        soundManager.PlaySound("Moo");
        soundManager.PlaySound("Abduction");
    }

    private void ExitButtonClick()
    {
        moveExit = true;
        soundManager.PlaySound("Moo");
        soundManager.PlaySound("Abduction");

    }

}
