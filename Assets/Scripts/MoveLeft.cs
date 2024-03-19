using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
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
