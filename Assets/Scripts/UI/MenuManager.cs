using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public static bool canIOpenMenu = true;
    public static bool isMainMenu;
    //public static bool isGamePaused;
    private bool isSettingsOpen = false;

    public GameObject pauseMenuUI;
    //public GameObject gameoverMenuUI;

    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public Toggle fullscreenToggle;

    public int[] screnWidths;

    private int lastResolutionIndex;

    public AudioMixer mixer;

    private Animator menuAnimator;

    [HideInInspector] public int currentSceneIndex;

    private Color normalColor = Color.white;
    private Color activeColor = new Color(0.35f, 0.6f, 1f, 1f);

    [Header("SELECTED BUTTONS")]
    public Button firstMenuButton;
    public Button firstSettingsMenuButton;
    //public Button firstGameOverButton;

    //public TMP_Text settingsLabel;

    private void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        menuAnimator = pauseMenuUI.GetComponent<Animator>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            isMainMenu = true;
            Pause();
        }
        else
        {
            isMainMenu = false;
            AudioManager.instanse.PlayMusic(SoundLibrary.instance.levelTheme);
        }

        SelectedMenuButton("FirstButton");

        //isGamePaused = false;
        isSettingsOpen = false;
        canIOpenMenu = true;
        AudioManager.instanse.SoundMode(0);        

        LaodOptions();
    }

    void Update()
    {

        Debug.Log(Controls.pause);
        if (Controls.pause && canIOpenMenu == true)
        {
            Debug.Log("This is it!");
            //if (isMainMenu == false)
            //    CheckPause();

            //CheckSubMenu();
        }
    }

    //private void CheckPause()
    //{
    //    if (isGamePaused)
    //    {
    //        if (!isSettingsOpen)
    //            ContinueGame();
    //    }
    //    else
    //        Pause();
    //}

    public void ContinueGame()
    {
        AudioManager.instanse.SoundMode(0);

        pauseMenuUI.SetActive(false);
        //isGamePaused = false;
    }

    public void Pause()
    {
        // play another clip only in game
        if (isMainMenu == false)
            AudioManager.instanse.SoundMode(1);

        pauseMenuUI.SetActive(true);
        SelectedMenuButton("FirstButton");
        //isGamePaused = true;
    }

    public void PlayCoop()
    {
        
    }

    public void PlayMultiplayer()
    {

    }

    public void LetsTestSomething()
    {

    }

    //public void ReloadGame()
    //{
    //    AudioManager.instanse.SoundMode(0);
    //    SceneManager.LoadScene(currentSceneIndex);
    //}

    //public void GoToNextLevel()
    //{
    //    AudioManager.instanse.SoundMode(0);
    //    SceneManager.LoadScene(currentSceneIndex + 1);
    //}

    //public void GameOver()
    //{
    //    gameoverMenuUI.SetActive(true);
    //    SelectedMenuButton("GameOverButton");
    //    isGamePaused = true;
    //    Time.timeScale = 0f;

    //    AudioManager.instanse.musicSource.Pause();
    //    AudioManager.instanse.PlayUISound("GameoverSound", 1);
    //}

    public void QuitToMainMenu()
    {
        //Time.timeScale = 1.0f;
        //isGamePaused = false;
        AudioManager.instanse.SoundMode(0);

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CheckSubMenu()
    {
        if (isSettingsOpen == true) SettingsMenuBack();
    }

    #region Options
    private void LaodOptions()
    {
        if (PlayerPrefs.HasKey("Resolution"))
            lastResolutionIndex = PlayerPrefs.GetInt("Resolution");
        else
            lastResolutionIndex = resolutionToggles.Length - 1;

        resolutionToggles[lastResolutionIndex].isOn = true;

        bool isFullscreen;

        if (PlayerPrefs.HasKey("isFullscreen"))
            isFullscreen = (PlayerPrefs.GetInt("isFullscreen") == 1 ? true : false);
        else
            isFullscreen = true;

        fullscreenToggle.isOn = isFullscreen;
        SetFullscreen(isFullscreen);
    }

    public void SetScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            float aspectRatio = 16.0f / 9.0f;
            lastResolutionIndex = i;
            if (fullscreenToggle.isOn == false)
                Screen.SetResolution(screnWidths[i], (int)(screnWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("Resolution", lastResolutionIndex);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen == true)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
            SetScreenResolution(lastResolutionIndex);

        PlayerPrefs.SetInt("Fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume(float value)
    {
        AudioManager.instanse.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instanse.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetEffectsVolume(float value)
    {
        AudioManager.instanse.SetVolume(value, AudioManager.AudioChannel.Effects);
    }

    #endregion Options

    #region Submenus
    public void SettingsMenu()
    {
        menuAnimator.Play("SettingsAnimation");
        isSettingsOpen = true;
        SelectedMenuButton("Settings");        
    }

    public void SettingsMenuBack()
    {
        menuAnimator.Play("BackSettingsAnimation");
        isSettingsOpen = false;
        SelectedMenuButton("FirstButton");
    }

    #endregion Submenus

    public void PlayMouseOverSound()
    {
        AudioManager.instanse.PlayUISound("ButtonSound");
    }

    public void SelectedMenuButton(string alias)
    {
        EventSystem.current.SetSelectedGameObject(null);
        switch (alias)
        {
            case "FirstButton":
                firstMenuButton.Select();
                firstMenuButton.OnSelect(null);
                break;

            case "Settings":
                firstSettingsMenuButton.Select();
                firstSettingsMenuButton.OnSelect(null);
                //settingsLabel.color = activeColor;
                break;

            //case "GameOverButton":
            //    firstGameOverButton.Select();
            //    firstGameOverButton.OnSelect(null);
            //    break;

            default:
                break;
        }

    }

    public void ActiveButtonColor(TMP_Text obj)
    {
        if (obj != null)
        {
            normalColor = obj.color;
            obj.color = activeColor;
        }

    }

    public void UnactiveButtonColor(TMP_Text obj)
    {
        if (obj != null)
            obj.color = normalColor;
    }
}
