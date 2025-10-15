 using UnityEngine;
using UnityEngine.UI;

public class MissionModeScript : MonoBehaviour
{
    public float missionDuration ;
    private float missionTime;
    public Text timerText;
    public GameObject winScreen;
     public AudioSource winSound;
    public bool isMissionActive = false; 

    void Start()
    {
        missionTime = missionDuration;
        winScreen.SetActive(false); // Hide win screen initially
    }

    void Update()
    {
        if (isMissionActive)
        {
            missionTime -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(missionTime).ToString();
            Debug.Log("timer:"+missionTime);

            if (missionTime <= 0)
            {
                MissionComplete();
            }
        }
    }

    public void StartMission()
    {
        isMissionActive = true;
        missionTime = missionDuration;
        timerText.gameObject.SetActive(true);  // Show timer
        winScreen.SetActive(false); // Hide win screen in case it's active
    }

    public void MissionComplete()
    {
        isMissionActive = false;
        winScreen.SetActive(true); // Show win screen
        winSound.Play();
        Time.timeScale = 0; // Stop the game
    }
} 