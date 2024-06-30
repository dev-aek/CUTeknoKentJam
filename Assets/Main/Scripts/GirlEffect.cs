using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GirlEffect : MonoBehaviour
{
    enum GirlType {Shock,Final};
    [SerializeField] GirlType girlType;
    [SerializeField] GameObject m_Timeline;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (girlType == GirlType.Shock)
            {
                // StartCoroutine(ShockScene());
                m_Timeline.SetActive(true);
                gameObject.SetActive(false);
            }
            else if (girlType == GirlType.Final)
            {
                //Final Scene
            }
        }
    }

    
}
