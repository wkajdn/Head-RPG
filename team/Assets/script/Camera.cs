using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    void Start()
    {


    }




    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -1000f);


    }
}