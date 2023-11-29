using TMPro;
using UnityEngine;

public class HungerStripe : MonoBehaviour
{
    public TextMeshProUGUI textHunger;
    public TextMeshProUGUI textThirst;
    public TextMeshProUGUI textWc;

    private void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            moveTo moveToComponent = playerObject.GetComponent<moveTo>();

            if (moveToComponent != null)
            {
                float hunger = moveToComponent.hunger;
                float thirst = moveToComponent.thirst;
                float wc = moveToComponent.wc;

                textHunger.text = "G³ód: " + Mathf.RoundToInt((hunger / 500f) * 100f) + " %";
                textThirst.text = "Pragnienie: " + Mathf.RoundToInt((thirst / 500f) * 100f) + " %";
                textWc.text = "WC: " + Mathf.RoundToInt((wc / 500f) * 100f) + " %";
            }
        }
    }
}
