using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveHighScore : MonoBehaviour
{
    public TMP_InputField inputName;

    string path;
    LinkedList<HighScore> highScores;
    int maxHighScore = 10;
    void Start()
    {
        path = Application.dataPath + Path.DirectorySeparatorChar + "HighScoreSave.txt";

        highScores = new LinkedList<HighScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void savehighScore()
    {
        //sort and add

        if (ishighScore())
        {
            Debug.Log(highScores);

            StreamWriter sw = new StreamWriter(path);

            HighScore newHighScore = new HighScore(inputName.text, PlayerPrefs.GetInt("score"));

            FindAndInsertAtIndex(newHighScore);
            

            foreach(HighScore h in highScores)
            {
                sw.WriteLine(h.name + "," + h.score);
            }

            sw.Close();
        }

        
    }

    public bool ishighScore()
    {
        
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string line = "";

            while((line = sr.ReadLine()) != null)
            {
                string[] savedLines = line.Split(',');
                HighScore h = new HighScore(savedLines[0], int.Parse(savedLines[1]));

                highScores.AddLast(h);
            }

            sr.Close();

            if(highScores.Count > 0)
            {
                if(highScores.Last.Value.score > PlayerPrefs.GetInt("score"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        return true;
    }

    private void FindAndInsertAtIndex(HighScore score)
    {
        if(highScores.Count > 0)
        {
            LinkedListNode<HighScore> index = highScores.First;

            foreach(HighScore h in highScores)
            {
                if(score.score > h.score)
                {
                    highScores.AddBefore(index, score);

                    if (highScores.Count > maxHighScore)
                    {
                        highScores.RemoveLast();
                    }

                    return;
                }
                index = index.Next;
            }
        }
        else
        {
            highScores.AddLast(score);
        }

    }
}

public class HighScore
{
    public string name;
    public int score;

    public HighScore(string Name, int Score)
    {
        name = Name;
        score = Score;
    }
}
