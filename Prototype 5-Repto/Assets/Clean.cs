using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    public int len = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, len);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
