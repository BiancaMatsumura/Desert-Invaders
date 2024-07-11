using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float timeToDisappear = 2f;
    
    void Start()
    {
        
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(timeToDisappear);

        Destroy(gameObject);
        

    }

}
