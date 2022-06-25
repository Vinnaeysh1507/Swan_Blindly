using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [Header("Player Health Amount")]
    public static float currentPlayerHealth = 100.0f;
    [SerializeField] public static float maxPlayerHealth = 100.0f;
    [SerializeField] private int regenRate = 1;
    private bool canRegen = false;

    [Header("Add Blood Splatter Image")]
    [SerializeField] private Image redSplatterImage = null;

    //[Header("Add Hurt Image")]
    //[SerializeField] private Image hurtImage = null;
    //[SerializeField] private float hurtTimer = 0.1f;

    [Header("Heal Timer")]
    [SerializeField] private float healCooldown = 3.0f;
    [SerializeField] private float maxHealCooldown = 3.0f;
    [SerializeField] private bool startCooldown = false;

    //[Header("Audio Name")]
    //[SerializeField] private AudioClip hurtAudio = null;
    //private AudioSource healthAudioSource;

    private void Start()
    {
        //healthAudioSource = GetComponent<AudioSource>();
    }

    void UpdateHealth()
    {
        Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        redSplatterImage.color = splatterAlpha;
    }

    //IEnumerator HurtFlash()
    //{
    //    hurtImage.enabled = true;
    //    healthAudioSource.PlayOneShot(hurtAudio);
    //    yield return new WaitForSeconds(hurtTimer);
    //    hurtImage.enabled = false;
    //}

    public void TakeDamage()
    {
        if(currentPlayerHealth >= 0)
        {
            PostProcessingManager.ID = 1;
            canRegen = false;
           // StartCoroutine(HurtFlash());
            UpdateHealth();
            healCooldown = maxHealCooldown;
            startCooldown = true;
        }
    }

    private void Update()
    {
        if (startCooldown)
        {
            healCooldown -= Time.deltaTime;
            if(healCooldown <= 0)
            {
                canRegen = true;
                startCooldown = false;
                PostProcessingManager.ID = 0;
            }
        }

        if (canRegen)
        {
            if(currentPlayerHealth <= maxPlayerHealth - 0.01)
            {
                currentPlayerHealth += Time.deltaTime * regenRate;
                UpdateHealth();
            }
            else
            {
                currentPlayerHealth = maxPlayerHealth;
                healCooldown = maxHealCooldown;
                canRegen = false;
            }
        }

        if (currentPlayerHealth == 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
