using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        
            // Nesneleri tek tek aç
           /* foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(delay);
            }*/

        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            if (i>0)
            {
                Vector3 pos = objectsToActivate[i].transform.position;
                objectsToActivate[i].transform.position = objectsToActivate[i - 1].transform.position;
                objectsToActivate[i].SetActive(true);
                objectsToActivate[i].transform.DOMove(pos, delay-0.05f);
            }
            else
            {
                objectsToActivate[i].SetActive(true);
            }
            yield return new WaitForSeconds(delay);
        }

        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            Vector3 pos = objectsToActivate[i].transform.position;
            if (i < objectsToActivate.Count-1)
            {
                Vector3 nextPos= objectsToActivate[i + 1].transform.position;
                objectsToActivate[i].transform.DOMove(nextPos, delay - 0.05f).OnComplete(()=> objectsToActivate[i].SetActive(false));
            }
            else
            {
                objectsToActivate[i].SetActive(false);
            }
            yield return new WaitForSeconds(delay);
            objectsToActivate[i].transform.position = pos;

        }

        // Nesneleri tek tek kapat
        /*foreach (GameObject obj in objectsToActivate)
            {
                yield return new WaitForSeconds(delay);
                obj.SetActive(false);
            }*/
        StartCoroutine(LoopActivationDeactivation());
    }

    public void PathStarer()
    {
        StartCoroutine(LoopActivationDeactivation());
    }
}
