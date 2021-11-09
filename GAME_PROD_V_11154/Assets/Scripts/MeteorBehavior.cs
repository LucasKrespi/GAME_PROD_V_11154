using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    public ParticleSystem trail, explosion;
    public GameObject Meteor;
    // Start is called before the first frame update
    void Start()
    {
        trail.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Meteor != null)
        {
            this.transform.position = Meteor.transform.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        explosion.Play();

        Destroy(Meteor);

        StartCoroutine(KillPartcles());
    }

    private IEnumerator KillPartcles()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
