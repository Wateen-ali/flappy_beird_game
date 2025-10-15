using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1;
    private float timer = 0;
    public float heightOffset = 5;
    public GameObject coinPrefab;
    public float coinChance = 0.5f; // 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ModeSelectionScript.selectMode=="Easy"){
            spawnRate=2.5f; // the pipe rate 
            heightOffset=4f;// the space between pipe
        } else if (ModeSelectionScript.selectMode=="Hard"){
            spawnRate=1.5f;
            heightOffset=3.5f;
        } else if (ModeSelectionScript.selectMode=="Mission"){
            spawnRate=2.0f;
            heightOffset=4f;
        }
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer = timer + Time.deltaTime;
        }
        else
        {
           spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
         Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint),0), transform.rotation);
         if (Random.value < coinChance)
{
    float coinY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
    Vector3 coinPosition = new Vector3(transform.position.x, coinY, 0);
    Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    Debug.Log("Coin spawned at: " + coinPosition);

}


    }
}
