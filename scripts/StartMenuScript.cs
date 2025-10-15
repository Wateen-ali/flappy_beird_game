using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject modeSelection;
    public GameObject gameUI;
    public GameObject pipeSpawner;
    public MissionModeScript missionMode;
    public GameObject timerUI;
    public GameObject counterUI;
    ////
    public GameObject hero1;
    public GameObject backgroundgame;
    public GameObject characterSelectionPanel;
    public GameObject hero2; 
    public GameObject hero3; 
    public GameObject hero4; 
    private GameObject selectedHero;
    public static string selectedCharacter = "Hero1"; 



    void Start()
    {

      if (string.IsNullOrEmpty(selectedCharacter))
        {
            selectedCharacter = "Hero1"; // Hero1
        }

        startMenu.SetActive(true);
        modeSelection.SetActive(false);
        gameUI.SetActive(false);
        characterSelectionPanel.SetActive(false);
        backgroundgame.SetActive(false);

        hero1.SetActive(false);
        hero2.SetActive(false);
        hero3.SetActive(false);
        hero4.SetActive(false);

        Time.timeScale = 0;

        // 
        switch (selectedCharacter)
        {
            case "Hero1":
                selectedHero = hero1;
                break;
            case "Hero2":
                selectedHero = hero2;
                break;
            case "Hero3":
                selectedHero = hero3;
                break;
            case "Hero4":
                selectedHero = hero4;
                break;
        }

        if (selectedHero != null)
        {
            selectedHero.SetActive(true);
            selectedHero.GetComponent<Rigidbody2D>().simulated = false;
        }

        if (pipeSpawner != null)
        {
            pipeSpawner.SetActive(false);
        }

        timerUI.SetActive(false);
        counterUI.SetActive(false);
    }

    public void PlayGame()
    {
        startMenu.SetActive(false);
        gameUI.SetActive(true);
       // hero1.SetActive(true);
         backgroundgame.SetActive(true);
        modeSelection.SetActive(false);
        Time.timeScale = 1;

         hero1.SetActive(false);
         hero2.SetActive(false);
         hero3.SetActive(false);
         hero4.SetActive(false);

         switch (selectedCharacter)
    {
        case "Hero1":
            selectedHero = hero1;
            break;
        case "Hero2":
            selectedHero = hero2;
            break;
        case "Hero3":
            selectedHero = hero3;
            break;
        case "Hero4":
            selectedHero = hero4;
            break;
        default:
            selectedHero = hero1;
            break;
        
        
    }
      

       if (selectedHero != null)
    {
        selectedHero.SetActive(true);
        selectedHero.GetComponent<Rigidbody2D>().simulated = true;
    }

    if (pipeSpawner != null)
    {
        pipeSpawner.SetActive(true);
    }

        counterUI.SetActive(true);

        // Check if the mission mode is active
        if (ModeSelectionScript.selectMode=="Mission")
        {
            timerUI.SetActive(true);
            missionMode.StartMission();
        }
        else
        {
            timerUI.SetActive(false);
            missionMode.isMissionActive = false; 
        }

        Debug.Log("Game started: " + Time.timeScale);
    }

    public void OpenSelectMode()
    {
        startMenu.SetActive(false);
        modeSelection.SetActive(true);
        Debug.Log("The select button has been clicked!");
    }

    public void BackToMenu()
    {
        modeSelection.SetActive(false);
        startMenu.SetActive(true);
        characterSelectionPanel.SetActive(false);
    }


    public void StartMissionMode()
    {
         ModeSelectionScript.selectMode = "Mission";
        SceneManager.LoadScene("gameProject");

        GameObject hero = GameObject.Find("hero");
        if (hero != null)
        {
            hero.GetComponent<Rigidbody2D>().simulated = true;
        }
        if (pipeSpawner != null)
        {
            pipeSpawner.SetActive(true);
        }

        timerUI.SetActive(true);  // Ensure timer is visible
        counterUI.SetActive(true);

        Debug.Log("Mission Mode Started!");
    }

    public void OpenCharacterSelection()
{
   // startMenu.SetActive(false);
    characterSelectionPanel.SetActive(true);
}

public void SelectCharacter(string characterName)
{

        hero1.SetActive(false);
         hero2.SetActive(false);
         hero3.SetActive(false);
         hero4.SetActive(false);

    switch (characterName)
    {
        case "Hero1":
            selectedHero = hero1;
            break;
        case "Hero2":
            selectedHero = hero2;
            break;
        case "Hero3":
            selectedHero = hero3;
            break;
        case "Hero4":
            selectedHero = hero4;
            break;
    }
    if (selectedHero != null)
{
    selectedHero.SetActive(true);
    selectedHero.GetComponent<Rigidbody2D>().simulated = true;
}

    selectedCharacter = characterName;
    characterSelectionPanel.SetActive(false);
}



}
