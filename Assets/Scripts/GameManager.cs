using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float randomPosition;
    public float SpawnIntervall;
    public GameObject obstacle;
    private Vector3 obstaclePosition;
    // Start is called before the first frame update
    void Start()
    {
        obstaclePosition = obstacle.transform.position;
        StartCoroutine(MakeHolePositionRandom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MakeHolePositionRandom()
    {
        yield return new WaitForSeconds(SpawnIntervall);
        randomPosition = Random.Range(PlayerController.Instance.bottomBound + 1.5f, PlayerController.Instance.topBound - 1);
        Instantiate(obstacle,new Vector3(obstaclePosition.x, randomPosition, obstaclePosition.z), transform.rotation);
        StartCoroutine(MakeHolePositionRandom());
    }
}
