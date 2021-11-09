using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody cow_rigidbody;
    void Start()
    {
        cow_rigidbody = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(TurnOnGravity());

    }

    private void Update()
    {
        if(Mathf.Abs(GameControl.ship_Transform.position.magnitude - transform.position.magnitude) > 10)
        {
            ThrowBackInPool();
            
        }
    }

    IEnumerator TurnOnGravity()
    {

        yield return new WaitForSeconds(0.3f);

        cow_rigidbody.useGravity = true;

    }

    public void ThrowBackInPool()
    {
        gameObject.SetActive(false);
        cow_rigidbody.useGravity = true;
        cow_rigidbody.transform.rotation = Quaternion.identity;
    }

    public void OnTakeFromPool(Vector3 pos)
    {
        FindObjectOfType<GameControl>().Occupied_pos.AddLast(pos);
        this.gameObject.SetActive(true);
        this.transform.position = pos;
    }
}
