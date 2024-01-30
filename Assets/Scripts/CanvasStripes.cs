using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasStripes : MonoBehaviour
{

    [SerializeField] private Slider HungerBar;
    [SerializeField] private Slider ThirstBar;
    [SerializeField] private Slider WcBar;

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

                HungerBar.value = hunger / 500.0f;
                ThirstBar.value = thirst / 500.0f;
                WcBar.value = wc / 500.0f;
            }
        }
    }
}
