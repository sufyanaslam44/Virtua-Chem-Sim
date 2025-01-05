using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUpHand : MonoBehaviour
{
    public float popUpDuration = 0.5f; // Duration of each pop-up animation
    public float scaleFactor = 1.2f; // Scale factor for the pop-up effect
    public float intervalBetweenAnimations = 2f; // Interval between consecutive pop-up animations

    private RectTransform rectTransform;
    private Vector3 originalScale;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;

        // Start the continuous pop-up animation loop
        StartCoroutine(ContinuousPopUpAnimation());
    }

    IEnumerator ContinuousPopUpAnimation()
    {
        while (true) // Loop indefinitely
        {
            yield return new WaitForSeconds(intervalBetweenAnimations);

            float timer = 0f;
            while (timer < popUpDuration)
            {
                float scale = Mathf.Lerp(originalScale.x, originalScale.x * scaleFactor, timer / popUpDuration);
                rectTransform.localScale = new Vector3(scale, scale, 1f);
                timer += Time.deltaTime;
                yield return null;
            }

            rectTransform.localScale = new Vector3(originalScale.x * scaleFactor, originalScale.y * scaleFactor, 1f); // Ensure final scale is set
        }
    }
}
