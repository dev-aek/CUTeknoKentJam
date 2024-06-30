using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Instance
    public static SoundManager Instance { get; private set; }

    [SerializeField] private float _delay = 10f;
    private bool firstTime = true;
    private float timer = 3f;

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



    private IEnumerator RandomEffectPlay()
    {
        int i = Random.Range(0, 4);
        PlayEffect(i);
        yield return new WaitForSeconds(_delay);
        StartCoroutine(RandomEffectPlay());
    }



    private void Start()
    {
        PlayEffect(3);

    }

    private void Update()
    {


        timer -= Time.deltaTime;
        if (timer < 0 && firstTime)
        {
            StartCoroutine(RandomEffectPlay());
            firstTime = false;
            Debug.Log("firstTime");
        }
    }

}
