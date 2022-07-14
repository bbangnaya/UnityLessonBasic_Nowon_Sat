using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float dashSpeed = 5f;
    public float gravity = 9.81f;
    private Rigidbody rb;
    private Vector3 _move;
    private PlayerAnimator playerAnimator;
    private GroundSensor groundSensor;
    private Transform tr;
    private Transform cam;

    // ========================================================
    // -------------------- public Method ---------------------
    // ========================================================

    public void SetMove(float x, float z, float speed) {
        _move.x = x * speed;
        _move.z = z * speed;
    }

    // ========================================================
    // ------------------- private Method ---------------------
    // ========================================================

    private void Awake()
    {
        instance = this;
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<PlayerAnimator>();
        groundSensor = GetComponentInChildren<GroundSensor>();  // Jump�� �ʿ�.
    }
    private void Start() {
        cam = Camera.main.transform;
    }
    private void Update()
    {
        // �߷� �ǽð����� ����
        // _move += Vector3.down * gravity;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerAnimator.SetFloat("h", h);
        playerAnimator.SetFloat("v", v);

        tr.rotation = Quaternion.Euler(0, cam.eulerAngles.y, 0);
        Vector3 move = cam.rotation * new Vector3(h, 0, v);

        // shift�� ������ �޸���.
        // if���� ���� ���귮�� �����ؼ� ����.
        // ���Ǻ� �����ڸ� ���� ���귮�� ���� ���� �ͺ��� ����
        if (( h == 0 ) && ( v == 1 ) &&
            Input.GetKey(KeyCode.LeftShift)) 
        {
            SetMove(h, v, dashSpeed);
            playerAnimator.SetFloat("RunForwardBlend", 1.0f);       // 1�� �ٲ�� �ð�
            // �ȴٰ� �뽬�� �ٲ�� �ð��� ����� �������� �ڿ������� ���̴�.
        }
        else 
        {
            SetMove(h, v, moveSpeed);
        }
    }

    private void FixedUpdate() {
        if (groundSensor.isOn == false)
            // rb.position += Vector3.down * gravity * Time.fixedDeltaTime;
            rb.AddForce(Vector3.down * gravity, ForceMode.VelocityChange);

        rb.position += _move * Time.fixedDeltaTime;
    }
}
