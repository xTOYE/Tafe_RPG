using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class PlayerHandler : MonoBehaviour
{
    [Header("Value Variables")]
    public float maxHealth;
    public float maxStamina;
    public float maxMana;
    public float curHealth;
    public float curStamina;
    public float curMana;
    [Header("Value Variables")]
    public Slider healthBar;
    public Slider staminaBar;
    public Slider manaBar;
    [Header("Damage Effect Variables")]
    public Image damageImage;
    public Image deathImage;
    public Text text;
    public AudioClip deathClip;
    public float flashSpeed = 5;
    public Color flashcolour = new Color(1, 0, 0, 0.2f);
    AudioSource playerAudio;
    public static bool isDead;
    bool damaged;

    [Header("Check Point")]
    public Transform curCheckPoint;
    [HeaderAttribute("save")]
    public PlayerSaveAndLoad PlayerSaveAndLoad;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Display Health
        if (healthBar.value != Mathf.Clamp01(curHealth/maxHealth))
        {
            curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
            healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
        }

        if (manaBar.value != Mathf.Clamp01(curMana/ maxMana))
        {
            curMana = Mathf.Clamp(curMana, 0, maxMana);
            manaBar.value = Mathf.Clamp01(curMana / maxMana);
        }

        if (staminaBar.value != Mathf.Clamp01(curStamina / maxStamina))
        {
            curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
            staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
        }

        if (curHealth <= 0 && !isDead)
        {
            Death();
        }
        ///Damage
        if (Input.GetKeyDown(KeyCode.X))
        {
            damaged = true;
            curHealth -= 5;
        }
        if(damaged && !isDead)
        {
            damageImage.color = flashcolour;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

    }
    void Death()
    {
        //set the death flag so this function isnt called again
        isDead = true;
        text.text = "";

        //set the AudioSource to play the death clip
        playerAudio.clip = deathClip;
        playerAudio.Play();
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
        Invoke("DeathText", 2f);
        Invoke("ReviveText", 6f);
        Invoke("Revive", 9f);
    }

    void Revive()
    {
        isDead = false;
        curHealth = maxHealth;
        curMana = maxMana;
        curStamina = maxStamina;
        //move and rotate spaw location
        this.transform.position = curCheckPoint.position;
        this.transform.rotation = curCheckPoint.rotation;

        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Revive");
    }

    void DeathText()
    {
        text.text = "U ded";
    }

    void ReviveText()
    {
        text.text = "Try again";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            curCheckPoint = other.transform;
        }
    }
}
