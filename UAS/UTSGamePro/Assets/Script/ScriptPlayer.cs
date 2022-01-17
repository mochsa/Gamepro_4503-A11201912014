using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    public float jumpPower = 10.0f;
    Rigidbody2D myRigidbody;
    bool checkLompat = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallangeController myChallangeController;
    GameController myGameController;
    public float launchForce;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallangeController = GameObject.FindObjectOfType<ChallangeController>();
        myGameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && checkLompat && !isGameOver) {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }
        //hitCheck
        if (transform.position.x < posX) {
            GameOver();
        }
    }

    void Update() {
        
    }

    void GameOver() {
        isGameOver = true;
        myChallangeController.GameOver();
    }

    public void OnCollisionEnter2D(Collision2D other){
        if (other.collider.tag == "Lompat"){
            checkLompat = true;
        }
        if (other.collider.tag == "Enemy") {
            GameOver();
        }
        if(other.gameObject.CompareTag("Trampoline")){
            rb.velocity = Vector2.up * launchForce;
        }
    }

    void OnCollisionStay2D(Collision2D other){
        if (other.collider.tag == "Lompat"){
            checkLompat = true;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.collider.tag == "Lompat"){
            checkLompat = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Coin") {
            myGameController.IncrementStore();
            Destroy(other.gameObject);
        }
    }
}
