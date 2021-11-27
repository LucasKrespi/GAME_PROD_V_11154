using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LoadAndDisplayHighScore : MonoBehaviour
{
    LinkedList<HighScore> highScores;
    string path;

    public GameObject templatePrefab, Canvas;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + Path.DirectorySeparatorChar + "HighScoreSave.txt";
        highScores = new LinkedList<HighScore>();

        loadHighScores();

        DisplayHighScore();
    }

    private void loadHighScores()
    {
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] savedLines = line.Split(',');
                HighScore h = new HighScore(savedLines[0], int.Parse(savedLines[1]));

                highScores.AddLast(h);
            }

            sr.Close();
        }
    }


    private void DisplayHighScore()
    {

        int position = 1;
        TextMeshProUGUI[] textMeshProUGUIs;
        Image image;
        foreach(HighScore h in highScores)
        {
            GameObject spot = Instantiate(templatePrefab, Canvas.transform);

            textMeshProUGUIs = spot.GetComponentsInChildren<TextMeshProUGUI>();
            image = spot.GetComponentInChildren<Image>();

            if(position % 2 == 0)
                image.color = Color.black;
            else
                image.color = Color.white;

            textMeshProUGUIs[0].text = position.ToString();
            textMeshProUGUIs[1].text = h.name;
            textMeshProUGUIs[2].text = h.score.ToString();


            spot.transform.position = new Vector2(Canvas.transform.position.x, Canvas.transform.position.y + (position * -22));

            position++;

        }
    }
}
