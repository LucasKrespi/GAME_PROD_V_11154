using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
   
    private void Update()
    {
        if (Mathf.Abs(GameControl.ship_Transform.position.magnitude - transform.position.magnitude) > 15)
        {
            ThrowBackInPool();
        }
    }
    public void OnTakeFromPool(Vector3 pos)
    {
        FindObjectOfType<GameControl>().Occupied_pos.AddLast(pos);
        transform.position = pos;
        gameObject.SetActive(true);
    }

    public void ThrowBackInPool()
    {
        gameObject.SetActive(false);
    }
}
