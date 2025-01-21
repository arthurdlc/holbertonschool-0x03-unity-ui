using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody rb;
    public TextMeshProUGUI scoreText;  
    public TextMeshProUGUI healthText;  
    public int health = 5;
    private int score = 0;
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    void Update()
    {
         // Check if health is 0
        if (health <= 0)
        {
            Debug.Log("Game Over!");

            // Reload the current scene
            SceneManager.LoadScene(this.gameObject.scene.name);
            // Reset health and score (done automatically since the scene is reloaded)
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the object is tagged as "Pickup"
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You Win!");
            Application.Quit();
        }
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        rb.AddForce(move * speed);
    }
}
