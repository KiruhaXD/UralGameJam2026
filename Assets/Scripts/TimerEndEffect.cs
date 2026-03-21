using System.Collections;
using TMPro;
using UnityEngine;

public class TimerEndEffect : MonoBehaviour
{
    public IEnumerator Timer(int startTime)
    {
        while (startTime > 0) 
        {
            yield return new WaitForSeconds(1);
            startTime--;

            if(startTime <= 0)
                startTime = 0;

        }

        yield return new WaitForSeconds(1);
    }
}
