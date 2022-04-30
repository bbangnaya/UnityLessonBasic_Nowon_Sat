using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongSelector : MonoBehaviour
{
    //�̱��� �̿�
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
        // ���� Ŭ�� �ε�
        clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");
        // �뷡 jSon ������ �ε�
        TextAsset songDataText = Resources.Load<TextAsset>($"SongDatas/{clipName}");
        // json������ DeSerialize
        songData = JsonUtility.FromJson<SongData>(songDataText.ToString());
    }
}