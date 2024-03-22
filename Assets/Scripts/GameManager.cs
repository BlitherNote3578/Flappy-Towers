using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

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
    public TextMeshProUGUI nameField;
    public GameObject player;
    public GameObject plane;
    private int highscore;
    public TextMeshProUGUI highscoreText;
    private string playerName;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        obstaclePosition = obstacle.transform.position;
        StartCoroutine(MakeHolePositionRandom());
        if(DataSaver.instance != null && DataSaver.instance.skin == 1)
        {
            player.gameObject.transform.position = new Vector3(999, 999, 999);
            plane.gameObject.SetActive(true);
        }else
        {
            plane.gameObject.SetActive(false);
        }
        if (DataSaver.instance != null)
        {
            nameField.text = DataSaver.instance.playerName;
            playerName = DataSaver.instance.playerName;
        }
        LoadScore();
        
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
        if (points >= 5)
        {
            SpeedUp(5);
            SpawnIntervall = 3;
        }
        if (points >= 10)
        {
            SpeedUp(8);
            SpawnIntervall = 4;
        }
        if (points >= 20)
        {
            SpeedUp(7);
            SpawnIntervall = 2;
        }
        HighScore();
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
    public void SpeedUp(int speed)
    {
        MoveLeft.instance.speed = speed;
    }
    void HighScore()
    {
        highscoreText.text = ("Highscore: " + highscore + "(" + playerName + ")");
        if (points > highscore && DataSaver.instance != null)
        {
            playerName = DataSaver.instance.playerName;
            highscore = points;
            SaveScore();
        }
    }
    void SaveScore()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        if (DataSaver.instance != null)
        {
            data.name = DataSaver.instance.playerName;
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
            playerName = data.name;
        }
    }
    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string name;
    }
}
