using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    //maybe add a score timer/lives? LOW PRIORITY
    //maybe spawn/rain bombs on the track
    void Start()
    {
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //if falls off screen, teleport back on.
        //NOTE: X= how far along the track, going NEGATIVE.
        //Y controls the height instead of Z. Z
        //controls left/right with right being positive
        if (Player.transform.position.y <= -10) { 
            Player.transform.position = new Vector3(Player.transform.position.x, 1, 0); 
            Player.transform.rotation = Quaternion.Euler (0,0,0);
            //Player.PlayerMovement.currentspd = 0f;
        }
        
    }
}
