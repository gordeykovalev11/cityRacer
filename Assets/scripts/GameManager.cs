using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int nextCheckPointIndex = 0;
    public int completedCircles = 0;
    public List<GameObject> checkPoints;
    public int circlesToWin = 5;
    public TextMeshProUGUI completedCirclesText;
    public GameObject winPanel;

    void Start()
    {
        Time.timeScale = 1.0f;
        winPanel.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void CheckPointReached(GameObject checkPoint)
    {
        if (checkPoints[nextCheckPointIndex] == checkPoint)
        {
            checkPoint.GetComponent<Renderer>().material.color = Color.green;
            nextCheckPointIndex++;
            Debug.Log(nextCheckPointIndex);
        }
    }
    public void FinishReached(GameObject finishBlock)
    {
        if (nextCheckPointIndex == checkPoints.Count)
        {
            finishBlock.GetComponent<Renderer>().material.color = Color.green;
            completedCircles++;
            Debug.Log("пройдено кругов: " + completedCircles);
            UpdateUI();

            StartCoroutine(Timer(0.5f, finishBlock));
            if (completedCircles >= circlesToWin)
            {
                Debug.Log("победа!");
                winPanel.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UpdateUI()
    {
        completedCirclesText.text = "circles complete: " + completedCircles.ToString();
    }

    private void ResetCheckPoints(GameObject finishBlock)
    {
        nextCheckPointIndex = 0;
        foreach (GameObject block in checkPoints)
        {
            block.GetComponent<Renderer>().material.color = Color.white;
        }
        finishBlock.GetComponent<Renderer>().material.color = new Color32(178, 113, 97, 255);
    }
    IEnumerator Timer(float deltaTime, GameObject finishBlock)
    {
        yield return new WaitForSeconds(deltaTime);
        ResetCheckPoints(finishBlock);
    }
}
