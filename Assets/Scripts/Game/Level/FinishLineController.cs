using System.Collections;
using TMPro;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    private Collider[] finishLine;
    private int currentLab { get; set; } = -1;
    private GameInitializer gameScript;
    private TextMeshProUGUI totalRaceScoreText;
    private GameObject lapTime;
    private GameObject endMenu;

    private bool timerRunning; 
    private float time; 
    private float lapStartTime;

    private int yOffset = 0;

    void Start()
    {
        gameScript = FindObjectOfType<GameInitializer>();

        finishLine = GetComponents<Collider>();
        finishLine[0].isTrigger = true;
        finishLine[1].isTrigger = false;

        totalRaceScoreText = transform.Find("GameHUD/TotalRaceTime").GetComponent<TextMeshProUGUI>();
        lapTime = transform.Find("GameHUD/LapTime").gameObject;
        endMenu = transform.Find("GameHUD/EndMenu").gameObject;


        timerRunning = false; 
        StartCoroutine(StartTimerAfterDelay(3f)); 
    }

    IEnumerator StartTimerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartNewLap();
        timerRunning = true; 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            System.Array.ForEach(finishLine, col => col.isTrigger = !col.isTrigger);

            if (!finishLine[0].isTrigger)
            {
                currentLab++;
                if (currentLab == gameScript.countLabs)
                {
                    timerRunning = false;
                    UpdateLapTime();
                    ShowEndMenu();
                }
                else if (currentLab != 0)
                {
                    Debug.Log("Need to update lap");
                    UpdateLapTime();
                    StartNewLap();
                }
            }
        }
    }

    void Update()
    {
        if (timerRunning) 
        {
            time += Time.deltaTime;
            totalRaceScoreText.text = GetCurrentTime();
        }
    }

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

    public void StartNewLap()
    {
        lapStartTime = time;
    }

    public void UpdateLapTime()
    {
        GameObject newLapTime = Instantiate(lapTime, lapTime.transform.parent);

        newLapTime.transform.localPosition = new Vector3(lapTime.transform.localPosition.x, lapTime.transform.localPosition.y - yOffset, lapTime.transform.localPosition.z);
        newLapTime.transform.localScale = Vector3.one;

        TextMeshProUGUI newLapTimeText = newLapTime.GetComponent<TextMeshProUGUI>();
        newLapTimeText.text = $"Lap {currentLab}: {GetLapTime()}";

        yOffset += 60;
    }

    public void ShowEndMenu()
    {
        endMenu.SetActive(true);

        TextMeshProUGUI endMenuTotalScoreText = endMenu.transform.Find("Image/TotalScore").GetComponent<TextMeshProUGUI>();
        endMenuTotalScoreText.text = GetCurrentTime();

        System.Array.ForEach(finishLine, col => col.enabled = false);
    }
}
