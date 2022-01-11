using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GameController2048 : MonoBehaviour
{

    public static GameController2048 instance;
    public static int ticker;
    [SerializeField] GameObject fillPrefab;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Cell2048[] allCells;
    [SerializeField] Text scoreDisplay;
    [SerializeField] int winScore;
    [SerializeField] GameObject winningPanel;
    public static Action<string> slide;
    public int score;
    bool win;
    int gameOver;
    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitiateGrid();
        InitiateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LocateNumOnGrid();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ticker = 0;
            gameOver = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ticker = 0;
            gameOver = 0;
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ticker = 0;
            gameOver = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ticker = 0;
            gameOver = 0;
            slide("a");
        }

    }


    public void LocateNumOnGrid()
    {
        bool isFull = true;

        for(int i = 0; i < allCells.Length; i++)
        {
            if(allCells[i].fill == null)
            {
                isFull = false;
            }
        }

        if (isFull == true)
            return;
       

        int whichCell = UnityEngine.Random.Range(0, allCells.Length);

        while(allCells[whichCell].transform.childCount != 0)
            whichCell = UnityEngine.Random.Range(0, allCells.Length);

        float prob = UnityEngine.Random.Range(0f, 1f);
        if (prob < .6f)
        {
            
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichCell].transform);
            //Debug.Log(2);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichCell].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
        else
        {
            
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichCell].transform);
            //Debug.Log(4);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichCell].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(4);
        }
        
    }



    /////////////////////////////////////////////////////////////////////////////////////////////

    public void InitiateGrid()
    {
        int whichCell = UnityEngine.Random.Range(0, allCells.Length);

        while(allCells[whichCell].transform.childCount != 0)
            whichCell = UnityEngine.Random.Range(0, allCells.Length);

        GameObject tempFill = Instantiate(fillPrefab, allCells[whichCell].transform);
        Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
        allCells[whichCell].GetComponent<Cell2048>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(2);
       
    }

    public void HigherScore(int input)
    {
        if (input > score)
            score = input;
        scoreDisplay.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver++;
        if (gameOver >= 16)
            gameOverPanel.SetActive(true);  
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void WinCheck(int currScore)
    {
        if (win)
            return;
        if (currScore == winScore)
        {
            winningPanel.SetActive(true); //Enable the winning Panel 
            win = true;
        }
            
    }
    public void ContinuePlaying()
    {
        winningPanel.SetActive(false); //Disable the winning Panel 
    }

    public void Exit()
    {
        Application.Quit();
    }
}
