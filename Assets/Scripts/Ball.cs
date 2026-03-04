using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 8f;
    public Score score;

    public Rigidbody2D rbody;
    public Transform paddle;
    public Grid grid;

    private void Awake(){
        rbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        BallMovement();
    }

    private void BallMovement()
    {
        // setting xVelocity to -1 for left and 1 for right
        float xVelocity = UnityEngine.Random.Range(-1f, 1f);

        // using random to set the y velocity to a value between -1 and 1
        float yVelocity = 1f;

        // setting the velocity of the ball based on the x and y velocities multiplied by the speed
        rbody.linearVelocity = new Vector2(xVelocity * speed, yVelocity * speed);
    }

    private void ResetObj()
    {
        // sets the position y to a random value between -1 and 1 along y axis
        float posX = UnityEngine.Random.Range(-1f, 1f);
        // sets the position x to the startX value (center of the screen)
        Vector2 newPosition = new Vector2(posX, 0f);
        // updates the ball's position to the new position
        transform.position = newPosition;

        paddle.transform.position = new Vector2(0f, -4.5f);
    }

    private void ResetScore()
    {
        score.playerScore = 0;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Compares zonetag for collision and retrieves the id of the spicific zone from the gameManager
        if (collision.CompareTag("Zone"))
        {
            grid.CreateGrid();
            ResetObj();
            ResetScore();
            BallMovement();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Block"))
    {
        // remove this block from the grid list
        if (grid != null)
        {
            grid.blocks.Remove(collision.collider.gameObject);

            // if no blocks are left, you win!
            if (grid.blocks.Count == 0)
            {
                grid.ShowWinScreen();
            }
        }

        if (CameraShake.instance != null)
        {
            CameraShake.instance.Shake();
        }

        Destroy(collision.gameObject);
        score.playerScore++;
    }
}
}