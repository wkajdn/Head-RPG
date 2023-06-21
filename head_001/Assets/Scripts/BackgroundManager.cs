using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject[] background = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            background[i].transform.position -= new Vector3(speed * Time.deltaTime , 0.0f, 0.0f);

            if(background[i].transform.position.x <= -7.89f)
            {
                background[i].transform.position += new Vector3(15.78f, 0.0f, 0.0f);
            }
        }
    }
}
