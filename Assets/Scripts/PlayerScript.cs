using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject jumpScare;
    public string sceneName;
    public int speed;
    public int spawnX;
    public int spawnY;
    Rigidbody2D rb;
    public Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        rb.MovePosition(mousePosition);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Finish"))
        {
            print("Collision");
            SceneManager.LoadScene(sceneName);
            transform.position = new Vector2(spawnX, spawnY);
        }

        if (collision.gameObject.name.Contains("JumpScare"))
        {
            GetComponent<AudioSource>().Play();
            jumpScare.SetActive(true);
            

            
        }
        if (collision.gameObject.name.Contains("Wall"))
        {
            
            mousePosition.x = spawnX; mousePosition.y = spawnY;
            
        }
        print(collision.gameObject.name);
    }

}
