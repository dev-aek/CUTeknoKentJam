using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Instance
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] private AudioSource[] m_Effects;
    [SerializeField] private AudioSource[] m_Musics;

    public void PlayEffect(int i)
    {
        if (i < m_Effects.Length)
        {
            m_Effects[i].Play();
        }
    }
    public void StopEffect(int i)
    {
        if (i < m_Effects.Length)
        {
            m_Effects[i].Stop();
        }
    }
    public void PlayMusic(int i)
    {
        if (i < m_Musics.Length)
        {
            m_Musics[i].Play();
        }
    }
    public void StopMusic(int i)
    {
        if (i < m_Musics.Length)
        {
            m_Musics[i].Stop();
        }
    }


}
