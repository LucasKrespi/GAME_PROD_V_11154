using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TurnOnGravity());
    }

    IEnumerator TurnOnGravity()
    {

        yield return new WaitForSeconds(1);

        gameObject.GetComponent<Rigidbody>().useGravity = true;

    }

}
