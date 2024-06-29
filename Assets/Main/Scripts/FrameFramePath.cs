using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameFramePath : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public float delay = 0.5f;

    private void Start()
    {
        //StartCoroutine(LoopActivationDeactivation());
    }

    private IEnumerator LoopActivationDeactivation()
    {
        while (true)
        {
            // Nesneleri tek tek aç
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(delay);
            }

            // Nesneleri tek tek kapat
            foreach (GameObject obj in objectsToActivate)
            {
                yield return new WaitForSeconds(delay);
                obj.SetActive(false);
            }
        }
    }

    public void PathStarer()
    {
        StartCoroutine(LoopActivationDeactivation());
    }
}
