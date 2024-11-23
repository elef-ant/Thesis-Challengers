using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter01_Actions : MonoBehaviour
{
    public float jumping_speed = 1.0f;
    public GameObject fighter01;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JumpingUp()
    {
        fighter01.transform.Translate(0, jumping_speed, 0);
    }
}
