using UnityEngine;

public class PlayerAbakus : MonoBehaviour
{
    private GameObject bar;
    private AudioSource audioSource;
    public AudioClip click;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Check if Player presses "E" or "Q" to increase or decrease the bar value
    // Args: None
    // Returns: None
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (bar != null) 
            {
                audioSource.pitch = 1f;
                audioSource.PlayOneShot(click);
                bar.GetComponent<Bar>().add();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (bar != null)
            {
                bar.GetComponent<Bar>().remove();
                audioSource.pitch = 0.6f;
                audioSource.PlayOneShot(click);
            }
        }
    }

    // Check if Player is start colliding with Something
    // Args: Collision Object
    // Returns: None
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            bar = collision.gameObject;
        }

    }

    // Check if Player is stop colliding with Something
    // Args: Collision Object
    // Returns: None
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            bar = null;
        }
    }
}
