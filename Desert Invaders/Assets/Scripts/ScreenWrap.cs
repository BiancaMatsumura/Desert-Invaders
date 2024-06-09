using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;
    private float wrapZ = 15f; 

    void Start()
    {
        mainCamera = Camera.main;
        screenWidth = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        screenHeight = mainCamera.orthographicSize * 2;
    }

    void Update()
    {
        WrapPlayer();
    }

    void WrapPlayer()
    {
        Vector3 playerPos = transform.position;

        
        if (playerPos.x > screenWidth / 2)
        {
            playerPos.x = -screenWidth / 2;
        }
        else if (playerPos.x < -screenWidth / 2)
        {
            playerPos.x = screenWidth / 2;
        }

        
        if (playerPos.y > screenHeight / 2)
        {
            playerPos.y = -screenHeight / 2;
        }
        else if (playerPos.y < -screenHeight / 2)
        {
            playerPos.y = screenHeight / 2;
        }

        
        if (playerPos.z > wrapZ)
        {
            playerPos.z = -wrapZ;
        }
        else if (playerPos.z < -wrapZ)
        {
            playerPos.z = wrapZ;
        }

        transform.position = playerPos;
    }
}
