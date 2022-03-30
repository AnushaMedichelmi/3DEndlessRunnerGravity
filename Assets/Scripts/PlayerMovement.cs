using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float jumpForce;
    Rigidbody rb;
    public int score;
    public float distance;
    public int speedToIncrease;
    public Text scoreText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // PlayerPrefs.SetString("Name","Anusha");
       // Debug.Log(PlayerPrefs.GetString("Name"));
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Physics.gravity *= -1;
        }

       score = Mathf.FloorToInt(transform.position.x);
       // PlayerPrefs.SetInt("score", 2);
        //Debug.Log(PlayerPrefs.GetInt("score"));
       
        scoreText.text = score.ToString();
        if (score == speedToIncrease)
        {
            playerSpeed = playerSpeed + 2;
            speedToIncrease = speedToIncrease + 10;
        }
       


    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector3(playerSpeed, rb.velocity.y, rb.velocity.z);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObstacleCollider>() != null)
        {
            Destroy(this.gameObject);
        }

        
    }


}
