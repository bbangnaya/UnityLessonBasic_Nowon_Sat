using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Laser : Tower
{
    // 라인 랜더러 받아오기
    [SerializeField] private LineRenderer beam;
    [SerializeField] private Transform firePoint;
    // 스파크 튀는 효과 받기
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private int damage;
    [SerializeField] private int damageIncrementPercent;
    private float beamTimer;
    private int damageStep;
    private Enemy targetEnemy;
    private GameObject oldTargetObject;
    // 적들에게 디버프 적용하는 효과
    // 게임에서 어떻게 버프시스템을 만드는지 알아보자


    [SerializeField] private Buff buffSlow;

    
    protected override void Update()
    {
        base.Update();
        UpdateLaser();
    }

    private void FixedUpdate()
    {
        FixedUpdateLaser();
    }
    public void UpdateLaser()
    {
        if (target == null)
        {
            Clear();
        }
        else
        {
            // 타겟이 변경될때 갱신되도록 바꿈.
            if (target.gameObject != oldTargetObject)
            {
                oldTargetObject = target.gameObject;
                target = null;

                Clear();
            }
            else if (targetEnemy == null)
            {
                targetEnemy = target.GetComponent<Enemy>();
                BuffManager.instance.ActiveBuff(targetEnemy, buffSlow);
            }

            else if (targetEnemy != null)
            {
                targetEnemy.hp -= damage * (1f + damageIncrementPercent / 100.0f) * (damageStep + 1) * Time.deltaTime;

                switch (damageStep)
                {
                    case 0:
                        if (beamTimer > 1f) damageStep++;
                        break;
                    case 1:
                        if (beamTimer > 2f) damageStep++;
                        break;
                    case 2:
                        if (beamTimer > 3f) damageStep++;
                        break;
                    default:
                        break;
                }
                beamTimer += Time.deltaTime;
            }
        }
        if(targetEnemy != null)
        {
            Clear();
        }
    }


    private void FixedUpdateLaser()
    {
        if (target == null)
        {
            // 선 컨트롤
            beam.SetPosition(0, firePoint.position);
            beam.SetPosition(1, target.position);
            if (beam.enabled == false)
                beam.enabled = true;
            if (hitEffect.isStopped)
                hitEffect.Play();

            // todo -> raycast로 정확한 표면의 위치를 받아온 다음 거기서 이펙트 생성
            Vector3 dir = (firePoint.position - target.position).normalized;
            // 겉에 스파크 효과 보이기 = Raycast
            hitEffect.transform.position = target.position + dir * 0.25f;
            hitEffect.transform.rotation = Quaternion.LookRotation(dir);
            // 한번만 호출하게 만들기
        }
    }

    private void Clear()
    {
        // 레이저 빔 비활성화
        if (beam.enabled)
            beam.enabled = false;
        // 타격이벤트 실행 중이면 멈춤
        // 타겟이 없을 때 초기화하는 코드
        if (hitEffect.isPlaying)
            hitEffect.Stop();

        if (targetEnemy != null)
            targetEnemy = null;

        if (buffSlow.doBuff)
            buffSlow.TurnOff();
        if (beamTimer > 0)
            beamTimer = 0;
        if (damageStep > 0)
            damageStep = 0;
    }



}
