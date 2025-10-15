using UnityEngine;

public class musicScript : MonoBehaviour
{
       private static musicScript instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       void Awake()
    {
        // Ensure only one instance exists (prevent duplicates on reload)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }
}
