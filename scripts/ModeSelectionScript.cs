using UnityEngine;
using UnityEngine.SceneManagement;
public class ModeSelectionScript : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject ModeSelection;
    public static string selectMode = "Easy"; //defulte mode
    public MissionModeScript missionMode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         missionMode = FindFirstObjectByType<MissionModeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenModeSelection(){
        startMenu.SetActive(false);
        ModeSelection.SetActive(true);
    }

    public void SelectEasy(){
        selectMode = "Easy";
  
        StartGame();
    }

      public void SelectHard(){
        selectMode = "Hard";
     
        StartGame();
    }

      public void SelectMission(){
        selectMode = "Mission";
        StartGame();
    }

    public void BackToMenu(){
        ModeSelection.SetActive(false);
        startMenu.SetActive(true);
    }

    public void StartGame(){
         SceneManager.LoadScene("gameProject");///
    }

}
