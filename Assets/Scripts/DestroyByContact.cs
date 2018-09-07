using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int ScoreValue;
    private GameController gameController;
   

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider o)
    {
        if(o.tag == "boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(o.tag == "Player")
        {
            Instantiate(playerExplosion, o.transform.position, o.transform.rotation);
            gameController.Gameover();
        }

        gameController.AddScore(ScoreValue);
        Destroy(o.gameObject);
        Destroy(gameObject);
    }
}
