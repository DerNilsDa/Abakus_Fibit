using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public AudioClip[] sounds;

    private float move;
    public bool isJumping;
    private AudioSource soundAudio;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 characterScale;


    // Start is called before the first frame update
    void Start()
    {
        soundAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isJumping = false;
        characterScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    // Move Left and Right; Can Jump
    // Args: None
    // Returns: None
    private void movement()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (move < 0)
            characterScale.x = -7; 
        else if (move > 0)
            characterScale.x = 7;

        if (move != 0 && !soundAudio.isPlaying && !isJumping) {
            soundAudio.pitch = 1;
            soundAudio.PlayOneShot(sounds[Random.Range(2, 4)]);
        }

        transform.localScale = characterScale;


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            anim.SetBool("isJumping", true);
            soundAudio.PlayOneShot(sounds[Random.Range(0,2)]);
        }

        anim.SetFloat("speed", Mathf.Abs(move));

    }

    // Check if Player is start colliding with Something
    // Args: Collision Object
    // Returns: None
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
    }

    // Check if Player is stops colliding with Something
    // Args: Collision Object
    // Returns: None
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("OneWayPlatform"))
        {
            isJumping = true;
        }
    }
}
