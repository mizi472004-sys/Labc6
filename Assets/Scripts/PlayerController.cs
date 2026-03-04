using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    // Hash parameter (Bonus tối ưu)
    private int speedHash;
    private int attackHash;

    private float currentSpeed = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Dùng StringToHash (tối ưu)
        speedHash = Animator.StringToHash("Speed");
        attackHash = Animator.StringToHash("Attack");
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        float newSpeed = Mathf.Abs(move);

        // ✅ Chỉ set nếu giá trị thay đổi (tối ưu)
        if (newSpeed != currentSpeed)
        {
            animator.SetFloat(speedHash, newSpeed);
            currentSpeed = newSpeed;
        }

        // Di chuyển
        transform.Translate(Vector2.right * move * 5f * Time.deltaTime);

        // Attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(attackHash);
        }
    }
}