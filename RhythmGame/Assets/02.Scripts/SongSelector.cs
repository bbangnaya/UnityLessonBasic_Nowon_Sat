using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongSelector : MonoBehaviour
{
    //싱글톤 이용
    public static SongSelector instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public VideoClip clip;
    public SongData songData;

    public void LoadSongData(string clipName)
    {
        // 비디오 클립 로드
        clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");
        // 노래 jSon 데이터 로드
        TextAsset songDataText = Resources.Load<TextAsset>($"SongDatas/{clipName}");
        // json데이터 DeSerialize
        songData = JsonUtility.FromJson<SongData>(songDataText.ToString());
    }
}
