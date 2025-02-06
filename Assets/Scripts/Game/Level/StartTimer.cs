using System.Collections;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startScoreText;

    private bool timerRunning = true;
    public bool IstimerRunning => timerRunning;

    private void Start()
    {
        StartCoroutine(TimerStart()); 
    }

    private IEnumerator TimerStart()
    {
        timerRunning = true;
        float time = 3f;

        while (time > 0)
        {
            startScoreText.text = Mathf.Ceil(time).ToString(); 
            yield return null; 
            time -= Time.deltaTime; 
        }

        startScoreText.text = "START!";
        yield return new WaitForSeconds(1f);

        timerRunning = false;
        Destroy(gameObject);
    }
}
