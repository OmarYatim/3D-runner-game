using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Obstacle;
    [SerializeField]
    Transform[] positions = new Transform[3];

    Transform Player;

    float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > 1.5f)
        {
            Timer = 0;
            int i = Random.Range(0, 2);
            Instantiate(Obstacle, new Vector3(positions[i].position.x, positions[i].position.y, Player.position.z + 10), Quaternion.identity);
        }
    }
}
