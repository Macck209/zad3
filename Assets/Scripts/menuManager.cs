using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{

    public GameObject startPage;
    public GameObject audioSettPage;
    public GameObject screenSettPage;
    public GameObject infoPage;
    public GameObject exitPage;

    private bool musicToggled=true;
    private bool soundEffToggled=true;
    private float volume =0.8f;
    private int resolutionType=0;

    private void disactivateAll()
    {
        startPage.SetActive(false);
        audioSettPage.SetActive(false);
        screenSettPage.SetActive(false);
        infoPage.SetActive(false);
        exitPage.SetActive(false);
    }

    private void loadSettings()
    {
        musicToggled = PlayerPrefs.GetInt("musicToggled",1)==1 ? true: false;
        Toggle musicToggle = GameObject.Find("toggleMusic").GetComponent<Toggle>();
        musicToggle.isOn = musicToggled;

        soundEffToggled = PlayerPrefs.GetInt("soundEffToggled",1)==1 ?true:false;
        Toggle soundEffToggle = GameObject.Find("toggleSoundEffects").GetComponent<Toggle>();
        soundEffToggle.isOn = soundEffToggled;

        volume = PlayerPrefs.GetFloat("volume",0.8f);
        Slider volumeSlider = GameObject.Find("volumeSlider").GetComponent<Slider>();
        volumeSlider.value = volume;

        resolutionType = PlayerPrefs.GetInt("resolutionType");


        //check whether fullscreen shold be turned on when launching the game
        Screen.fullScreen = true;
        Screen.fullScreen = PlayerPrefs.GetInt("fullscreenOn",1)==1 ? true : false;
        Toggle fullScreenToggle = GameObject.Find("toggleFullscreen").GetComponent<Toggle>();
        fullScreenToggle.isOn = PlayerPrefs.GetInt("fullscreenOn", 1) == 1 ? true : false;


    }

    void Start()
    {
        loadSettings();
        disactivateAll();
    }


    //main buttons
    public void onStartClicked()
    {
        disactivateAll();
        startPage.SetActive(true);
    }
    public void onAudioSettClicked()
    {
        disactivateAll();
        audioSettPage.SetActive(true);
    }
    public void onScreenSettClicked()
    {
        disactivateAll();
        screenSettPage.SetActive(true);
    }
    public void onInfoClicked()
    {
        disactivateAll();
        infoPage.SetActive(true);
    }
    public void onExitClicked()
    {
        disactivateAll();
        exitPage.SetActive(true);
    }


    //start options
    public void onNewGameClicked()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void onGameResume()
    {
        //nothing here yet
    }


    //audio options
    public void onMusicToggled(bool _isToggled)
    {
        musicToggled = _isToggled;
        PlayerPrefs.SetInt("musicToggled", musicToggled?1:0);
    }
    public void onSoundEffToggled(bool _isToggled)
    {
        soundEffToggled = _isToggled;
        PlayerPrefs.SetInt("soundEffToggled", soundEffToggled ? 1 : 0);
    }
    public void onVolumeChanged(Single perc)
    {
        volume = perc;
        PlayerPrefs.SetFloat("volume", volume);
    }


    //graphics options
    public void onFullscreenToggled(bool _isToggled)
    {
        Screen.fullScreen = _isToggled;
        PlayerPrefs.SetInt("fullscreenOn", _isToggled ? 1 : 0);
    }
    public void onResolutionChanged(int type)
    {
        resolutionType = type;
        PlayerPrefs.SetInt("resolutionType", type);
    }


    //exit options
    public void onSaveAndExit()
    {
        //saving gamestate disabled (only settings are being saved)
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void onGameExit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
