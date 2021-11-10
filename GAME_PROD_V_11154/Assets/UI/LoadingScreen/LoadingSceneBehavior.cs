using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loadinscene());
    }
    
    private IEnumerator Loadinscene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(2);

    }
}
