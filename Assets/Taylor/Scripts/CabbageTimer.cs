using UnityEngine;
using UnityEngine.UI;

public class CabbageTimer : MonoBehaviour
{
    // timer starting number and ending number
    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        // subtracts 1 every second
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        // resets back to 10 once reaching 0
        if (currentTime <= 0)
        {
            currentTime = 10;
        }
    }
}
