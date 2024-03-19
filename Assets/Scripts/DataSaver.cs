using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public bool nameTooLong;
    public string m_playerName;
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
    public static DataSaver instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
}
