using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;     

public class NoteHitter : MonoBehaviour
{

    [SerializeField] private HitJudgeInfo hitJudgeInfo;    
    [SerializeField] private LayerMask noteLayer;
    [SerializeField] private KeyCode keyCode;

    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private Color pressedColor;
    private Color originalColor;

    private void Awake()
    {
        icon = GetComponent<SpriteRenderer>();
        originalColor = icon.color;
    }

    private void ChangeColor() => 
        icon.color = pressedColor;
    
    private void RollbackColor() =>
        icon.color = originalColor;
    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
            TryHitNote();

        if (Input.GetKey(keyCode))
            ChangeColor();
        else
            RollbackColor();

    }

    private bool TryHitNote()
    {
        // �߽ɿ��� ���� �����.
        HitType hitType = HitType.Miss;

        List<Collider2D> overlaps =
            Physics2D.OverlapBoxAll(transform.position,
                                    new Vector2(transform.lossyScale.x / 2, 
                                    hitJudgeInfo.hitJudgeHeight_Bad),
                                    0, noteLayer).ToList();

        if (overlaps.Count > 0)
        {
            overlaps.OrderBy(x => Mathf.Abs(transform.position.y - x.transform.position.y));
            float distance = Mathf.Abs(transform.position.y - overlaps[0].transform.position.y);

            if (distance < hitJudgeInfo.hitJudgeHeight_Cool)
                hitType = HitType.Cool;
            else if(distance < hitJudgeInfo.hitJudgeHeight_Great)
                hitType = HitType.Great;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Good)
                hitType = HitType.Good;
            else if (distance < hitJudgeInfo.hitJudgeHeight_Miss)
                hitType = HitType.Miss;
            else 
                hitType = HitType.Bad;

            overlaps[0].GetComponent<Note>().Hit(hitType);
            overlaps[0].gameObject.SetActive(false);        // ��Ʈ�� ��� ���� ���̴�.
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        // Bad ���� �����
        Gizmos.color = Color.grey;
        Gizmos.DrawWireCube(transform.position, 
            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Bad));
        // Bad ���� �����
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, 
            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Miss));
        // Bad ���� �����
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, 
            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Good));
        // Bad ���� �����
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, 
            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Great));
        // Bad ���� �����
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, 
            new Vector3(transform.lossyScale.x / 2, hitJudgeInfo.hitJudgeHeight_Cool));
    }
}
