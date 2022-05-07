using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{   // �̱���
    public static NoteManager instance;
    public static float noteSpeedScale = 1f;        // ��Ʈ�� �������� �ӵ�
    
    
    [SerializeField] private Transform spawnersParent;
    [SerializeField] private Transform hitterParent;


    public float noteFallingDistance
    {
        get
        {
            return spawnersParent.position.y - hitterParent.position.y;
        }
    }

    public float noteFallingTime
    {
        get
        {
            return noteFallingDistance / noteSpeedScale;
        }
    }
    // ��ųʸ��� �ø������� �ȵȴ�. ��, ���̷���Ű�� ������ �ȵȴ�.
    private Dictionary<KeyCode, NoteSpawner> spawners = new Dictionary<KeyCode, NoteSpawner>();
    private Queue<NoteData> noteQueue = new Queue<NoteData>();

    // ===========================================================
    // *********************Public Methods************************
    // ===========================================================
    public void StartSpawn()
    {
        if (noteQueue.Count > 0)
            StartCoroutine(E_Spawning());

    }

    IEnumerator E_Spawning()
    {
        float startTimeMark = Time.time;
        while (noteQueue.Count >0)
        {
            for (int i = 0; i < noteQueue.Count; i++)
            {
                if (noteQueue.Peek().time < (Time.time - startTimeMark)/noteSpeedScale)
                {
                    NoteData note = noteQueue.Dequeue();        // ��Ʈ���� ���ֱ�



                    spawners[note.keyCode].SpawnNote();
                }
                else
                    break;
            }
            yield return null;
        }
    }

    private void Awake()
    {
        instance = this;
        NoteSpawner[] tmpSpawners = spawnersParent.GetComponentsInChildren<NoteSpawner>();
        foreach (NoteSpawner spawner in tmpSpawners)
        {
            spawners.Add(spawner.keyCode, spawner);
        }

        // sort�� �������� ����
        List<NoteData> notes = SongSelector.instance.songData.notes;
        for (int i = 0; i < notes.Count; i++)
        {
            float speedOrigin = NoteAssets.GetNote(notes[i].keyCode).speed;

            /*if(notes[i].speed > 0)
                tmpSpeed = 
            float timeScaled = notes[i].time / NoteAssets.GetNote(notes[i].keyCode).speed;
            notes[i] = new NoteData
            {
                keyCode = notes[i].keyCode,
                time = timeScaled,
            };*/
        }

        notes.Sort((x,y) => x.time.CompareTo(y.time));
        foreach (NoteData note in notes)
            noteQueue.Enqueue(note);
    }
}
