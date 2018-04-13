using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager _instance;

    public Text shootNumText;
    public Text scoreText;
    public Text message;

    public int shootNum = 0;
    public int score = 0;

    public Toggle musicToggle;
    public AudioSource musicAudio;
    public bool musicOn = true;

    private void Awake()
    {
        _instance = this;
        if (PlayerPrefs.HasKey("MusicIsOn"))
        {
            if (PlayerPrefs.GetInt("MusicIsOn") == 1)
            {
                musicToggle.isOn = true;
                musicAudio.enabled = true;
            }
            else
            {
                musicToggle.isOn = false;
                musicAudio.enabled = false;
            }
        }
        else
        {
            musicToggle.isOn = true;
            musicAudio.enabled = true;
        }
    }

    private void Update()
    {
        shootNumText.text = shootNum.ToString();
        scoreText.text = score.ToString();
    }

    public void MusicSwitch()
    {
        if (musicToggle.isOn == false)
        {
            musicOn = false;
            musicAudio.enabled = false;
            //用Playerfabs保存音乐开关的状态
            PlayerPrefs.SetInt("MusicIsOn", 0);
        }
        else
        {
            musicOn = true;
            musicAudio.enabled = true;
            PlayerPrefs.SetInt("MusicIsOn", 1);
        }
        PlayerPrefs.Save();
    }

    public void AddShootNum()
    {
        shootNum += 1;
    }

    public void AddSorce()
    {
        score += 1;
    }

    public void ShowMessage(string str)
    {
        message.text = str;
    }

}
