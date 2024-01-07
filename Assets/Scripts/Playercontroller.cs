using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Playercontroller : MonoBehaviour
{


    public Rigidbody2D rigidbody2D;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;
    public GameObject pausePanel;


    private bool isGameOver=false;
     
    void Update()
    {
        if (isGameOver)
        {
            return;
        }
    
        HandleMovementInput();
        CheckForEscapeKey();

    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;

        if (inputVector != Vector2.zero && Input.GetAxis("Jump") == 0)
        {
            transform.Translate(inputVector * speed * Time.deltaTime);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "door")
        {
            Debug.Log("you won");
            gameWonPanel.SetActive(true);
            isGameOver = true;
        }
        if (other.tag == "Enemy")
        {
            Debug.Log("you lost");
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }


    }

    void CheckForEscapeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
