using UnityEngine;
public class playermovement : MonoBehaviour
{

    public float speed;
    public float jump;
    float moveVelocity;
    Rigidbody2D rb;
    SpriteRenderer SpriteRenderer;
    bool isGrounded;
    bool doublejump;
    bool jumping;
    pausemenu codemenu;

    private void Start()
    {
        codemenu = gameObject.GetComponent<pausemenu>();
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAbillities.IsImmuneToFire = PlayerPrefs.HasKey("fireimmunityenabled");
        PlayerAbillities.CanDoubleJump = PlayerPrefs.HasKey("doublejumpunlocked");
    }

    void Update()
    {
        if (!pausemenu.isPaused)
        {
            if (!PlayerAbillities.CanDoubleJump)
            {
                if (isGrounded && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jump);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(isGrounded || doublejump)
                    {
                        jumping = true;
                        rb.velocity = new Vector2(rb.velocity.x, jump);
                        doublejump = !doublejump;
                    }
                }
                if (isGrounded && !Input.GetKeyDown(KeyCode.Space) && !jumping)
                {
                    doublejump = false;
                }

            }

            /*if (Input.GetKeyDown(KeyCode.T))
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("all prefs deleted");
            }*/

            moveVelocity = 0;

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveVelocity = -speed;
                SpriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveVelocity = speed;
                SpriteRenderer.flipX = false;
            }

            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "background" && collision.tag != "cambounds")
        isGrounded = true;
        jumping = false;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "background" && collision.tag != "cambounds")
            isGrounded = false;
    }
}
