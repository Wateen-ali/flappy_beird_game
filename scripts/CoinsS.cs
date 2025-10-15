using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Tag = "Player"
        {
            FindObjectOfType<LogicScript>().AddCoin(1);

            if (collectSound != null)
                collectSound.Play();

            Destroy(gameObject);
        }
    }
}

