using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    Coroutine co1;
    void Start()
    {
        co1 = StartCoroutine(Countdown());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) { 
            StopCoroutine(co1);
        }
    }

    IEnumerator Countdown()
    {
        Debug.Log("Countdown started");
        for (int i = 10; i >= 1; i--)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(i);
        }
        Debug.Log("Blastoff");
    }
}


