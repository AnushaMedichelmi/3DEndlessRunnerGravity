using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public PlayerMovement player;
    public GameObject[] blockPrefab;
    public float spawnPoint;
    public float spawnMargin;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
       

        while ((player != null) && (spawnPoint < player.transform.position.x + spawnMargin) )
        {
            int k = Random.Range(0, blockPrefab.Length);
            if (spawnPoint < 5f)
            {
                k = 0;
            }
            GameObject temp = Instantiate(blockPrefab[k]);
            PlatformController platform = temp.GetComponent<PlatformController>();
            
            temp.transform.position = new Vector3(spawnPoint + platform.platformSize / 2, 0f, 0f);
            spawnPoint = spawnPoint + platform.platformSize;
        }

        if (player != null)
        {
            cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z); //Camera following the player
        }
    }
}
