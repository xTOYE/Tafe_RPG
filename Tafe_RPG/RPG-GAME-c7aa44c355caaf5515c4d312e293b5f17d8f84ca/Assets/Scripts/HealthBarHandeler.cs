using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandeler : MonoBehaviour
{
    public GameObject healthCanvas;
    public Image healthBar;

    void lateupdate ()
    {
        if(healthBar.fillAmount < 1 && healthBar.fillAmount > 0)
        {
            healthCanvas.SetActive(true);
            healthCanvas.transform.LookAt(Camera.main.transform);
            healthCanvas.transform.Rotate(0, 100, 0);
        }
        else
        {
            healthCanvas.SetActive(false);
        }
    }
}
