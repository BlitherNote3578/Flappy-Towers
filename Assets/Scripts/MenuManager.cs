using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI errorMessages;
    public TextMeshProUGUI name;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        WriteOutName();
    }
    void WriteOutName()
    {
        name.text = DataSaver.instance.playerName;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReadStringInput(string name)
    {
        DataSaver.instance.playerName = name;
    }
}
