using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Laser : Tower
{
    // ���� ������ �޾ƿ���
    [SerializeField] private LineRenderer beam;
    [SerializeField] private Transform firePoint;
    // ����ũ Ƣ�� ȿ�� �ޱ�
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private int damage;
    [SerializeField] private int damageIncrementPercent;
    private float beamTimer;
    private int damageStep;
    private Enemy targetEnemy;
    private GameObject oldTargetObject;
    // ���鿡�� ����� �����ϴ� ȿ��
    // ���ӿ��� ��� �����ý����� ������� �˾ƺ���


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
            // Ÿ���� ����ɶ� ���ŵǵ��� �ٲ�.
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
            // �� ��Ʈ��
            beam.SetPosition(0, firePoint.position);
            beam.SetPosition(1, target.position);
            if (beam.enabled == false)
                beam.enabled = true;
            if (hitEffect.isStopped)
                hitEffect.Play();

            // todo -> raycast�� ��Ȯ�� ǥ���� ��ġ�� �޾ƿ� ���� �ű⼭ ����Ʈ ����
            Vector3 dir = (firePoint.position - target.position).normalized;
            // �ѿ� ����ũ ȿ�� ���̱� = Raycast
            hitEffect.transform.position = target.position + dir * 0.25f;
            hitEffect.transform.rotation = Quaternion.LookRotation(dir);
            // �ѹ��� ȣ���ϰ� �����
        }
    }

    private void Clear()
    {
        // ������ �� ��Ȱ��ȭ
        if (beam.enabled)
            beam.enabled = false;
        // Ÿ���̺�Ʈ ���� ���̸� ����
        // Ÿ���� ���� �� �ʱ�ȭ�ϴ� �ڵ�
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
