using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockController : MonoBehaviour
{
    [SerializeField] private GameObject m_Black;
    [SerializeField] private GameObject m_MainCamera;
    [SerializeField] private GameObject m_ShockCamera;

    public IEnumerator ShockScene()
    {
        m_Black.SetActive(true);
        //shock effect
        //ritim effect
        yield return new WaitForSeconds(0.5f);
        m_Black.SetActive(false);
        m_MainCamera.SetActive(false);
        m_ShockCamera.SetActive(true);

        yield return new WaitForSeconds(2f);
        m_Black.SetActive(true);
        m_MainCamera.SetActive(true);
        m_ShockCamera.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        m_Black.SetActive(false);
    }
}
