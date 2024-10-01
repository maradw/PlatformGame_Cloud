using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite backcardSprite;
    private bool firstGuess, secondGuess;
   // public CardInfoSO[] cardPool;
    public GameObject card;
    public GameObject cardField;
    //public GameObject winPanel;
    private List<GameObject> cards = new List<GameObject>();
    private List<Button> buttons = new List<Button>();


    private int index;
   // private Card firstchoise;
   // private Card secondchoise;
    private bool evaluating;

    private int matches;
    private int totalMatches;

    [SerializeField]private ProgressData progressData;

    //public AudioSource mainAudioSource;
    //public AudioSource audioSourceone;
    //public AudioSource audioSourcetwo;
    //public AudioClip goodAudio;
    //public AudioClip wrongAudio;

    public void SaveProgress()
    {
        string json = JsonUtility.ToJson(progressData);
        SaveData.Save("progressdata2.json", json);
        print("data saved");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Save Progress"))
        {
            SaveProgress();
        }
    }

    public void LoadProgress()
    {
        progressData = JsonUtility.FromJson<ProgressData>(SaveData.Load("progressdata2.json"));
    }

    void Start()
    {
       

    }
    void AddListeners()
    {
       
    }

   
}
