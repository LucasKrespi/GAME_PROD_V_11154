using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button resumeButton, mainMenuButton, resetePositionButton;
    public Image selectedButtonFlag;
    public Canvas UIhud;
    public Transform playerTrasform;

    Vector3 resumeButtonInitialPosition, initiaScale, resetePositionButtonInitialPosition;
    Vector3 initial_pos;

    
  

    float buttonGoal_pos;

    public float abductionVelocity;

    private bool moveStart, moveMainMenu, moveResetePosition;


    void Start()
    {
        initial_pos = selectedButtonFlag.transform.position;

        resumeButton.Select();

        resumeButtonInitialPosition = resumeButton.transform.position;
        initiaScale = resumeButton.transform.localScale;

        resetePositionButtonInitialPosition = resetePositionButton.transform.position;

        resumeButton.onClick.AddListener(ResumeButtonClick);
        mainMenuButton.onClick.AddListener(mainMenuButtonClick);
        resetePositionButton.onClick.AddListener(resetePositionButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        UIhud.gameObject.SetActive(true);

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

        if (mainMenuButton.transform.position.y >= buttonGoal_pos - 10)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }


        if (resetePositionButton.transform.position.y >= buttonGoal_pos - 10)
        {
            resetePositionButton.transform.position = resetePositionButtonInitialPosition;
            resetePositionButton.transform.localScale = initiaScale;
            moveResetePosition = false;
            playerTrasform.gameObject.GetComponent<PlayerMovement>().cowhit = false;

            playerTrasform.position = new Vector3(0.0f, 4.3f, 0.0f);

            gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }







        if (EventSystem.current.currentSelectedGameObject == resumeButton.gameObject)
        {
            Vector3 goal_pos = resumeButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity * Time.unscaledDeltaTime) , initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (EventSystem.current.currentSelectedGameObject == mainMenuButton.gameObject)
        {
            Vector3 goal_pos = mainMenuButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity * Time.unscaledDeltaTime) , initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (EventSystem.current.currentSelectedGameObject == resetePositionButton.gameObject)
        {
            Vector3 goal_pos = resetePositionButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity * Time.unscaledDeltaTime), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }





        if (moveStart && resumeButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(resumeButton);
        }

        if (moveMainMenu && mainMenuButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(mainMenuButton);
        }

        if (moveResetePosition && resetePositionButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(resetePositionButton);
        }

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

    private void mainMenuButtonClick()
    {
        moveMainMenu = true;
    }

    private void resetePositionButtonClick()
    {
        moveResetePosition = true;
    }
}
