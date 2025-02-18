using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //������, ���������� ��� ���� ��
    private Rigidbody2D rigidbody2D;
    private Animator animator;                          //1) animator

    [SerializeField] private AudioSource DeathSoundEffect; //die sound
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();            //2) ���������
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))     //spikes -> tag -> trap
        {
            Die();
        }
    }
    // ������ (���� �����) 
    private void Die()
    {
        DeathSoundEffect.Play();                        // die sound play
        rigidbody2D.bodyType = RigidbodyType2D.Static;  // dynamic -> static (���� ����� ��������� ��������)
        animator.SetTrigger("Death Trigger");           // 3) �������
    }
    // ���������� ��� ���� ����� 
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
