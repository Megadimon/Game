using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalsDestr : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Explo")
        {
            Destroy(collision.gameObject);
        }
    }
}
