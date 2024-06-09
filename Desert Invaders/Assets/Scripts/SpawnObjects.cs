using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectToSpawn;
    public AudioSource audioDropping;
    public int positiveRange = 10;
    public int negativeRagne = -10;

    public float startSpawn;
    public float intervalSpawn;

    void Start()
    {
        InvokeRepeating("StartSpawn",startSpawn,intervalSpawn);
    }

    public void StartSpawn()
    {
        int positionX = Random.Range(positiveRange,negativeRagne);
        int positioZ = Random.Range(positiveRange, negativeRagne);

        Vector3 newPosition = new Vector3(positionX, 0, positioZ);

        Instantiate(objectToSpawn, newPosition, Quaternion.identity);
        audioDropping.Play();
    }
 
}
