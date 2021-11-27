using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameOverMenuBehavior : MonoBehaviour
{
    public Button saveButton;
    public Image selectedButtonFlag;
    public SoundManager soundManager;

    Vector3 initial_pos;

    float buttonGoal_pos;

    public float abductionVelocity;

    private bool moveStart;

    public TextMeshProUGUI score;



    void Start()
    {

        initial_pos = selectedButtonFlag.transform.position;

        saveButton.Select();
        soundManager = SoundManager.soundManagerInstace;

        saveButton.onClick.AddListener(SaveButtonClick);

        score.text = "Score: " + PlayerPrefs.GetInt("score");

    }

    // Update is called once per frame
    void Update()
    {
        buttonGoal_pos = selectedButtonFlag.transform.position.y;

        if (saveButton.transform.position.y >= buttonGoal_pos - 10)
        {
            SceneManager.LoadScene(4);
        }
    }
    private void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == saveButton.gameObject)
        {
            Vector3 goal_pos = saveButton.transform.position;

            selectedButtonFlag.transform.position = new Vector3(Mathf.Lerp(initial_pos.x, goal_pos.x, abductionVelocity), initial_pos.y, initial_pos.z);

            initial_pos = selectedButtonFlag.transform.position;
        }

        if (moveStart && saveButton.transform.position.y < buttonGoal_pos)
        {
            whenClicked(saveButton);
        }

    }

    private void whenClicked(Button selectedButton)
    {
        selectedButton.transform.position = new Vector3(selectedButton.transform.position.x, Mathf.Lerp(selectedButton.transform.position.y, buttonGoal_pos, abductionVelocity), selectedButton.transform.position.z);

        selectedButton.transform.localScale = selectedButton.transform.localScale * Mathf.Lerp(1.0f, 0.5f, abductionVelocity);

        selectedButton.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
    }

    private void SaveButtonClick()
    {
        moveStart = true;
        soundManager.PlaySound("Moo");
        soundManager.PlaySound("Abduction");
    }

}
