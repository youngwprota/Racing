using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    public int countLabs {get; private set;}
    [SerializeField] protected GameObject[] Tracks;
    [SerializeField] protected GameObject[] Transports;
    public GameObject pickedTrack {get; protected set;}
    public GameObject pickedTransport {get; protected set;}
    public GameObject mainCamera;
    public GameObject playerController;
    public GameObject startTimer;
    public GameObject enemy;


    private void SpawnTrack() 
    {
        pickedTrack = Instantiate(Tracks[PlayerPrefs.GetInt("TrackIndex")], new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Track: " + PlayerPrefs.GetInt("TrackIndex"));
    }
    private void SpawnPlayer() 
    {
        pickedTransport = Instantiate(Transports[PlayerPrefs.GetInt("CarIndex")], new Vector3(9.5f, 0.5f, -60), Quaternion.identity);
        Debug.Log("Car: " + PlayerPrefs.GetInt("CarIndex"));
    }

    private void SpawnEnemy() 
    {
        enemy = Instantiate(enemy, new Vector3(9.5f, 0.5f, -20), Quaternion.identity);
    }

    private void SpawnCamera()
    {
        mainCamera = Instantiate(mainCamera, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void SpawnController()
    {
        playerController = Instantiate(playerController, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void SpawnTimer()
    {
        startTimer = Instantiate(startTimer, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private IEnumerator SpawnAfterTimer()
    {
        yield return new WaitForSeconds(3f);
        SpawnController();
        SpawnEnemy();
    }

    private void InitializeGame()
    {
        SpawnTrack();
        SpawnPlayer();
        SpawnCamera();
        SpawnTimer();

        StartCoroutine(SpawnAfterTimer());
    }

    private void Awake()
    {
        countLabs = PlayerPrefs.GetInt("LapIndex") + 1;
        pickedTrack = Tracks[PlayerPrefs.GetInt("TrackIndex")];
        pickedTransport = Transports[PlayerPrefs.GetInt("CarIndex")];

        InitializeGame();
    }
}
