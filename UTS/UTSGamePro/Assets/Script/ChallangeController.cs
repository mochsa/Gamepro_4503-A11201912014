using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallangeController : MonoBehaviour
{
    public float scrollSpeed = 5.0f;
    public GameObject[] challanges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challangesSpawnPoint;
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomChallange();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        //Generate Object
        if (counter <= 0.0f) {
            GenerateRandomChallange();
        }else{
            counter -=Time.deltaTime * frequency;
        }


        //scrolling
        GameObject currentChild;
        for (int i = 0; i < transform.childCount; i++) {
            currentChild = transform.GetChild(i).gameObject;
            ScrollChallange(currentChild);
            if (currentChild.transform.position.x <= -25.0f){
                Destroy(currentChild);
            }
        }
    }

    void ScrollChallange(GameObject currentChallange) {
        currentChallange.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallange() {
        GameObject newChallange = Instantiate (challanges[Random.Range(0,challanges.Length)], challangesSpawnPoint.position, Quaternion.identity) as GameObject;
        newChallange.transform.parent = transform;
        counter = 1.0f;
    }

    public void GameOver(){
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
    }
}
