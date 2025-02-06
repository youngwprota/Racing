using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject LevelSettingsMenu;
    [SerializeField] private Sprite SoundOn;
    [SerializeField] private Sprite SoundOff;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button[] carButtons;
    [SerializeField] private Button[] trackButtons;
    [SerializeField] private Button[] lapButtons;
    [SerializeField] private Sprite[] carButtonsImagesDef;
    [SerializeField] private Sprite[] trackButtonsImagesDef;
    [SerializeField] private Sprite[] lapButtonsImagesDef;
    [SerializeField] private Sprite[] carButtonsImagesSelected;
    [SerializeField] private Sprite[] trackButtonsImagesSelected;
    [SerializeField] private Sprite[] lapButtonsImagesSelected;

    private void Awake()
    {
        if (MainMenu) MainMenu.SetActive(true);
        if (LevelSettingsMenu) LevelSettingsMenu.SetActive(false);

        if (!PlayerPrefs.HasKey("CarIndex")) PlayerPrefs.SetInt("CarIndex", 0);
        if (!PlayerPrefs.HasKey("TrackIndex")) PlayerPrefs.SetInt("TrackIndex", 0);
        if (!PlayerPrefs.HasKey("LapIndex")) PlayerPrefs.SetInt("LapIndex", 0);
        if (!PlayerPrefs.HasKey("SoundState")) PlayerPrefs.SetInt("SoundState", 1);

        PlayerPrefs.Save();

        bool soundOn = PlayerPrefs.GetInt("SoundState") == 1;
        AudioListener.volume = soundOn ? 1 : 0;
        soundButton.image.sprite = soundOn ? SoundOn : SoundOff;

        for (int i = 0; i < carButtons.Length; i++)
        {
            int index = i;
            carButtons[i].onClick.AddListener(() => SelectCar(index));
        }

        for (int i = 0; i < trackButtons.Length; i++)
        {
            int index = i;
            trackButtons[i].onClick.AddListener(() => SelectTrack(index));
        }

        for (int i = 0; i < lapButtons.Length; i++)
        {
            int index = i;
            lapButtons[i].onClick.AddListener(() => SelectLap(index));
        }
    }

    private void SelectCar(int index)
    {
        int prev = PlayerPrefs.GetInt("CarIndex");

        if (prev != index)
        {
            carButtons[prev].image.sprite = carButtonsImagesDef[prev];
            carButtons[index].image.sprite = carButtonsImagesSelected[index];

            PlayerPrefs.SetInt("CarIndex", index);
            PlayerPrefs.Save();
        }
    }

    private void SelectTrack(int index)
    {
        int prev = PlayerPrefs.GetInt("TrackIndex");

        if (prev != index)
        {
            trackButtons[prev].image.sprite = trackButtonsImagesDef[prev];
            trackButtons[index].image.sprite = trackButtonsImagesSelected[index];

            PlayerPrefs.SetInt("TrackIndex", index);
            PlayerPrefs.Save();
        }
    }

    private void SelectLap(int index)
    {
        int prev = PlayerPrefs.GetInt("LapIndex");

        if (prev != index)
        {
            lapButtons[prev].image.sprite = lapButtonsImagesDef[prev];
            lapButtons[index].image.sprite = lapButtonsImagesSelected[index];

            PlayerPrefs.SetInt("LapIndex", index);
            PlayerPrefs.Save();
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void LevelSettingsButton()
    {
        int carIndex = PlayerPrefs.GetInt("CarIndex");
        int trackIndex = PlayerPrefs.GetInt("TrackIndex");
        int lapIndex = PlayerPrefs.GetInt("LapIndex");

        carButtons[carIndex].image.sprite = carButtonsImagesSelected[carIndex];
        trackButtons[trackIndex].image.sprite = trackButtonsImagesSelected[trackIndex];
        lapButtons[lapIndex].image.sprite = lapButtonsImagesSelected[lapIndex];

        MainMenu.SetActive(false);
        LevelSettingsMenu.SetActive(true);
    }

    public void HomeButton()
    {
        LevelSettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void SoundSettingsButton()
    {
        bool soundOn = PlayerPrefs.GetInt("SoundState") == 1;

        soundOn = !soundOn; 
        AudioListener.volume = soundOn ? 1 : 0;
        soundButton.image.sprite = soundOn ? SoundOn : SoundOff;

        PlayerPrefs.SetInt("SoundState", soundOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
