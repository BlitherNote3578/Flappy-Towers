using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [HideInInspector]public float speed = 4;
    public static MoveLeft instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
