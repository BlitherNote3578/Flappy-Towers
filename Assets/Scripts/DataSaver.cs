using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static DataSaver instance;
    public bool nameTooLong;
    [SerializeField] string m_playerName;
    public string playerName
    {
        get { return m_playerName; }
        set
        {
            if (value.Length > 20)
            {
                nameTooLong = true;
            }
            else
            {
                m_playerName = value;
                nameTooLong = false;
            }
        }
    }
    [SerializeField] int m_skin;
    public int skin
    {
        get { return m_skin; }
        set
        {
            if (value < 0)
            {
                Debug.LogError("No negative skin existing!");
            }
            else
            {
                m_skin = value;
            }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null && m_playerName == null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        playerName = MenuManager.instance.playerName;
        skin = MenuManager.instance.skin;
    }
   
}
