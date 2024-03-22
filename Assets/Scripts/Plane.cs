using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : PlayerController
{
    public static Plane instance;
    private Rigidbody playerRbP;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerRbP = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOver == false)
        {
            playerRbP.AddForce(Vector3.up * force, ForceMode.VelocityChange);
        }
        KeepPlayerInBound();
    }
    public override void KeepPlayerInBound()
    {
        if (gameOver == false)
        {
            if (transform.position.y > topBound)
            {
                transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
                playerRbP.AddForce(Vector3.up * -5, ForceMode.Impulse);
            }
            if (transform.position.y < bottomBound)
            {
                transform.position = new Vector3(transform.position.x, bottomBound, transform.position.z);
                playerRbP.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerController.Instance.gameOver = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            GameManager.instance.points++;
        }
    }

}
