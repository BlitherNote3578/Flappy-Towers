using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float randomPosition;
    private float SpawnIntervall = 5;
    public GameObject obstacle;
    private Vector3 obstaclePosition;
    public static GameManager instance;
    [HideInInspector] public int points;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        obstaclePosition = obstacle.transform.position;
        StartCoroutine(MakeHolePositionRandom());
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameOver == false)
        {
            UpdateScore();
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
    IEnumerator MakeHolePositionRandom()
    {
        yield return new WaitForSeconds(SpawnIntervall);
        randomPosition = Random.Range(PlayerController.Instance.bottomBound + 1.7f, PlayerController.Instance.topBound - 1);
        Instantiate(obstacle,new Vector3(obstaclePosition.x, randomPosition, obstaclePosition.z), transform.rotation);
        StartCoroutine(MakeHolePositionRandom());
    }
    void UpdateScore()
    {
        scoreText.text = ("Score: " + points);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
