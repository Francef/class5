using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int secondsRemaining = 15;
    Coroutine tick;
    bool isMenuOpen = false;
    [SerializeField] TextMeshProUGUI timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining.text = "Start Game";
        tick = StartCoroutine(Tick());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // pause count if menu is open, otherwise continue countdown
            if (!isMenuOpen)
            {
                StopCoroutine(tick);
                isMenuOpen = true;
            }
            else
            {
                tick = StartCoroutine(Tick());
                isMenuOpen = false;
            }
        }
    }
    IEnumerator Tick()
    {
        yield return new WaitForSeconds(1);
        for (int i = secondsRemaining; i >= 1; i--)
        {
            secondsRemaining = i;
            if (i == 1)
            {
                timeRemaining.text = secondsRemaining + " second remaining";
            }
            else
            {
                timeRemaining.text = secondsRemaining + " seconds remaining";
            }
            yield return new WaitForSeconds(1);

        }
        timeRemaining.text = "Game Over";
    }
}
