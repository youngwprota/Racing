using UnityEngine;
using TMPro;
using System.Collections;

public class RaceTimer : MonoBehaviour 
{ 
    private bool enable;
    private float time; 
    private float lapStartTime;

    public string GetCurrentTime()
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        return $"{min:D2}:{sec:D2}";
    }

    public string GetLapTime()
    {
        float lapTime = time - lapStartTime;
        int min = Mathf.FloorToInt(lapTime / 60);
        int sec = Mathf.FloorToInt(lapTime % 60);
        return $"{min:D2}:{sec:D2}";
    }

    public void Start()
    {
        time = 0;
        lapStartTime = 0;
    }

    public void Update()
    {
        if (!enable || time >= 3600) return;
        time += Time.deltaTime;
        Debug.Log(time);
    }

    public void TimerEnable(bool isEnable)
    {
        enable = isEnable;
    }

    public void StartNewLap()
    {
        lapStartTime = time;
    }

    
}
