using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirlEffect : MonoBehaviour
{
    enum GirlType {Shock,Final};
    [SerializeField] GirlType girlType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (girlType == GirlType.Shock)
            {
                StartCoroutine(ShockScene());
            }
            else if (girlType == GirlType.Final)
            {
                //Final Scene
            }
        }
    }

    public IEnumerator ShockScene()
    {
        SoundManager.Instance.m_Black.active = true;
        //shock effect
        //ritim effect
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.m_Black.active = false;
        SoundManager.Instance.m_MainCamera.active = false;
        SoundManager.Instance.m_ShockCamera.active = true;

        yield return new WaitForSeconds(2f);
        SoundManager.Instance.m_Black.active = true;
        SoundManager.Instance.m_MainCamera.active = true;
        SoundManager.Instance.m_ShockCamera.active = false;
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.m_Black.active = false;
    }
}
