using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float force;
    public float topBound { get; private set; } = 6;
    public float bottomBound { get; private set; } = -4;
    public static PlayerController Instance;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOver == false)
        {
            playerRb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }
        KeepPlayerInBound();
    }

    void KeepPlayerInBound()
    {
        if ( gameOver == false )
        {
            if (transform.position.y > topBound)
            {
                transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
                playerRb.AddForce(Vector3.up * -5, ForceMode.Impulse);
            }
            if (transform.position.y < bottomBound)
            {
                transform.position = new Vector3(transform.position.x, bottomBound, transform.position.z);
                playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            GameManager.instance.points ++;
        }
    }
}
