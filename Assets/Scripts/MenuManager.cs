using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI errorMessages;
    public TextMeshProUGUI nameField;
    public static MenuManager instance;
    public string playerName = "Player";
    public int skin;
    public TextMeshProUGUI skinText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ReadStringInput("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (DataSaver.instance.nameTooLong == true)
        {
            errorMessages.text = "This name is too long!";
        }else
        {
            errorMessages.text = " ";
            WriteOutName();
        }
    }
    void WriteOutName()
    {
        if ( DataSaver.instance.nameTooLong == false)
        {
            nameField.text = DataSaver.instance.playerName;
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReadStringInput(string name)
    {
        playerName = name;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ChangeSkin()
    {
        if (skin == 0)
        {
            skin++;
            skinText.text = ("Plane skin selected");
        }
        else
        {
            skin--;
            skinText.text = ("Default skin selected");
        }
    }
}
