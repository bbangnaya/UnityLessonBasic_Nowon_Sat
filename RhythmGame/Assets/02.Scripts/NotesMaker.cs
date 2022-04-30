using UnityEngine;
using UnityEditor;
using UnityEngine.Video;
using System;

/// <summary>
/// 뮤직비디오를 재생하고 사용자가 노트에 대한 해당 뮤직비디오에 대한
/// 노트들을 입력해서 저장할 수 있도록 하는 클래스
/// </summary>
public class NotesMaker : MonoBehaviour
{
    SongData songData;      // 노래데이터
    // 키보드 입력 목록
    KeyCode[] keyCodes = {KeyCode.S,
                          KeyCode.D,
                          KeyCode.W,
                          KeyCode.A,
                          KeyCode.Space,
                          KeyCode.J,
                          KeyCode.K,
                          KeyCode.L};


    // 녹화중인가?
    private bool OnRecord
    {
        get
        {
            return vp.isPlaying ? true : false;
        }
    }
        
    
    
    
    [SerializeField] private VideoPlayer vp;        // 

    private void Update()
    {
        // Debug.Log(vp.time);

        if (OnRecord)
        {
            Recording();
        }
            
    }
    /// <summary>
    /// 노래데이터 생성 및 뮤직 비디오 시작
    /// </summary>
    public void StartRecording()
    {        
        songData = new SongData();      // 노래 데이터 객체 생성
        songData.videoName = vp.clip.name;  // 노래 데이터에 현재 클립이름 대입
        vp.Play();  // 비디오 재생
        // 뮤직비디오 시작
    }

    /// <summary>
    /// 녹화중에 호출하는 함수
    /// 키 입력에 따라 노트 데이터를 생성하도록 함
    /// </summary>
    private void Recording()
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
                CreateNoteData(keyCode);
        }
    }
    /// <summary>
    /// 재생중이던 뮤직비디오를 정지하고
    /// 여태까지 생성한 노래 데이터를 저장하도록 함.
    /// </summary>
    public void StopRecording()
    {
        SaveSongData();     // 노래데이터 저장
        vp.Stop();          // 뮤직비디오 정지        
    }

    /// <summary>
    /// 키코드와 시간에 따른 노트 데이터를 생성해서 노래 데이터에 추가하는 함수
    /// </summary>
    /// <param name="keyCode">현재 키보드 입력</param>     // 매개변수 설명
    private void CreateNoteData(KeyCode keyCode)
    {
        float roundedTime = (float)Math.Round(vp.time, 2);         // 소숫점 2째자리까지 발올림
        // 뮤직비디오 현재 시간에 맞춰서 멤버 세팅
        NoteData noteData = new NoteData(); // 노트 데이터 생성
        noteData.time = roundedTime;
        noteData.keyCode = keyCode;
        Debug.Log($"노트데이터 생성 : {keyCode}, {roundedTime}");
        songData.notes.Add(noteData);       // 


        // noteData.time = 뮤직비디오 현재 시간 반올림된 거

        noteData.keyCode = keyCode;
        songData.notes.Add(noteData);   // 노래 데이터에 생성한 노트 데이터 추가
    }
    /// <summary>
    /// 저장 패널 띄운 후에
    /// 사용자가 저장할 디렉토리를 입력해주면
    /// 해당 디렉토리에 Deserilization(역직렬화)된 노래 데이터를 쓰는 함수
    /// </summary>
    private void SaveSongData()
    {
        // 저장 패널 띄우고 사용자의 저장할 디렉토리 받아옴
        string dir = EditorUtility.SaveFilePanel("저장할 곳을 입력하세요.", "", songData.videoName,"json");
        // JsonUtility.ToJson()을 통해 노래데이터를 Deserilization해서 만들어진 텍스트를 파일로 씀.
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(songData));
    }









}
