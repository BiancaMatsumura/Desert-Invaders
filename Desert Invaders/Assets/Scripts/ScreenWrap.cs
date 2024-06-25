using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;
    private float wrapZ = 15f;

    public bool isWrapping { get; private set; } = false;
    public bool wrapped { get; private set; } = false;

    void Start()
    {
        isWrapping = false;
        wrapped = false;
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
        bool wasWrapping = isWrapping;
        isWrapping = false;


        if (playerPos.x > screenWidth / 2)
        {
            playerPos.x = -screenWidth / 2;
            isWrapping = true;
           
        }
        else if (playerPos.x < -screenWidth / 2)
        {
            playerPos.x = screenWidth / 2;
            isWrapping = true;
            
        }

        
        if (playerPos.y > screenHeight / 2)
        {
            playerPos.y = -screenHeight / 2;
            isWrapping = true;
            
        }
        else if (playerPos.y < -screenHeight / 2)
        {
            playerPos.y = screenHeight / 2;
            isWrapping = true;
            
        }

        
        if (playerPos.z > wrapZ)
        {
            playerPos.z = -wrapZ;
            isWrapping = true;
           
        }
        else if (playerPos.z < -wrapZ)
        {
            playerPos.z = wrapZ;
            isWrapping = true;
           
        }

        if (isWrapping)
        {
            transform.position = playerPos;
            wrapped = true;
        }
        else if (wasWrapping && !isWrapping)
        {
            wrapped = false;
        }


       
    }
}
