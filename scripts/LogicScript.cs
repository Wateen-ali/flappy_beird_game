using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text scoreText2;
     public Text scoreText3;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public AudioSource winSound;
    public AudioSource GameoverSound;
    public AudioSource crashsound;
    public int coinCount;
    public Text coinText; 
     public Text coinText2; 
      public Text coinText3; 

    public GameObject background1;
    public GameObject background2;
    public GameObject pipeSpawner;
    public GameObject pipePrefab1;
    public GameObject pipePrefab2;
    public GameObject cup;
    private bool switchedTheme = false;


  
    

 void Start()
    {
       cup.SetActive(false);
    }

    void Update(){
        
       
    }

    public void WinGame(){
       winScreen.SetActive(true);
       winSound.Play();
       Time.timeScale=0;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        playerScore = playerScore + scoreToAdd;
        if(playerScore==10 && ModeSelectionScript.selectMode=="Hard" || playerScore==10 && ModeSelectionScript.selectMode=="Easy" ){
            WinGame();
        }
        if(playerScore==2){
            cup.SetActive(true);

        }
        scoreText.text= playerScore.ToString();
        scoreText2.text= playerScore.ToString();
         scoreText3.text= playerScore.ToString();
    }

    public void restartGame(){
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     

    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
         Time.timeScale=0;
          crashsound.Play();
           GameoverSound.Play();
    }

    public void AddCoin(int amount)
{
    coinCount += amount;
    coinText.text =  coinCount.ToString();
    coinText2.text =  coinCount.ToString();
    coinText3.text =  coinCount.ToString();
    if (coinCount >= 3 && !switchedTheme)
    {
        SwitchTheme();
        switchedTheme = true;
    }
}

void SwitchTheme()
{
    background1.SetActive(false);
    background2.SetActive(true);

  
    pipeSpawner.GetComponent<pipeSpawnScript>().pipe = pipePrefab2;
}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
