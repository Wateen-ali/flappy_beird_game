using UnityEngine;

public class heroScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
      public LogicScript logic;
      public bool heroIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


         if(ModeSelectionScript.selectMode=="Easy"){
            flapStrength=4f; // the jump stringth
         }
         else if(ModeSelectionScript.selectMode=="Hard"){
            flapStrength=6f;
         } 
          else if(ModeSelectionScript.selectMode=="Mission"){
            flapStrength=4f;
         }

         if (gameObject.name != StartMenuScript.selectedCharacter)
        {
            gameObject.SetActive(false); // 
            return;
        }
         
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
   
        

         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && heroIsAlive){
        myRigidbody.linearVelocity= Vector2.up * flapStrength;}
    }

    private void OnCollisionEnter2D(Collision2D collision){
        logic.gameOver();
        heroIsAlive= false;
    }
}
