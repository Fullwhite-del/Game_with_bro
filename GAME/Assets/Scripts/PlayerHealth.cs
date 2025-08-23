using TMPro;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    

    public TMP_Text healthText;
    public Animator healthTextAnim;

    //GameObject parentObj;

    private void Start()
    {
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;
        //parentObj = GetComponentInParent<GameObject>();

    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        healthTextAnim.Play("Animation_textHP");
        healthText.text = "HP: " + currentHealth + "/" + maxHealth;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //parentObj.SetActive(false);
        }

    }
}
