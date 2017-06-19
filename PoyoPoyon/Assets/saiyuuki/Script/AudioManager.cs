using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    //フェード時間
    public const float FADE_SPEED_RATE_HIGH = 0.9f;
    public const float FADE_SPEED_RATE_LOW = 0.3f;
    private float _bgmFadeSpeedRate = FADE_SPEED_RATE_HIGH;

    string nextName_BGM;
    string nextName_SE;

    bool isFadeOut = false;

    public AudioSource attachSESource,attachBGMSource;

    Dictionary<string, AudioClip> _seDic,_bgmDic;

    void Awake()
    {
        //インスタンスがない場合
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //SEのファイルを読み込んでセットする
        _seDic = new Dictionary<string, AudioClip>();
        _bgmDic = new Dictionary<string, AudioClip>();

        object[] seList = Resources.LoadAll("SE");
        object[] bgmList = Resources.LoadAll("BGM");

        foreach(AudioClip se in seList)
        {
            _seDic[se.name] = se;
        }

        foreach(AudioClip bgm in bgmList)
        {
            _bgmDic[bgm.name] = bgm;
        }
    }

    //--------------------------------------------------------
    // SE
    //--------------------------------------------------------

    public void PlaySE(string seName,float delay = 0.0f)
    {
        //SEがなかったら終わり
        if(!_seDic.ContainsKey(seName))
        {
            return;
        }

        nextName_SE = seName;
        Invoke("DelayPlaySE", delay);
    }

    void DelayPlaySE()
    {
        attachSESource.PlayOneShot(_seDic[nextName_SE] as AudioClip);
    }

    //--------------------------------------------------------
    // BGM
    //--------------------------------------------------------

    public void PlayBGM(string bgmName,float fadeSpeedRate = FADE_SPEED_RATE_HIGH)
    {
        if(!_bgmDic.ContainsKey(bgmName))
        {
            return;
        }

        if(!attachBGMSource.isPlaying)
        {
            nextName_BGM = "";
            attachBGMSource.clip = _bgmDic[bgmName] as AudioClip;
            attachBGMSource.Play();
        }
        else if(attachBGMSource.clip.name != bgmName)
        {
            nextName_BGM = bgmName;
            FadeOutBGM(fadeSpeedRate);
        }
    }

    public void FadeOutBGM(float fadespeedRate = FADE_SPEED_RATE_LOW)
    {
        _bgmFadeSpeedRate = fadespeedRate;
        isFadeOut = true;
    }

    void Update()
    {
        if(!isFadeOut)
        {
            return;
        }

        attachBGMSource.volume -= Time.deltaTime * _bgmFadeSpeedRate;

        if(attachBGMSource.volume <= 0)
        {
            attachBGMSource.Stop();
            isFadeOut = false;

            if(!string.IsNullOrEmpty(nextName_BGM))
            {
                PlayBGM(nextName_BGM);
            }
        }
    }
}
