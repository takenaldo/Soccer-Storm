using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWallController : MonoBehaviour
{
    Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) - defaultPos.y > 15)
        {
            transform.position = defaultPos;
        }
    }
}
