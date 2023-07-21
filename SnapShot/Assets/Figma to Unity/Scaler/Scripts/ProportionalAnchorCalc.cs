using UnityEngine;

[ExecuteInEditMode]
public class ProportionalAnchorCalc : MonoBehaviour
{
    [Header("Targets")]
    [Tooltip("The reference RectTransform for normalized anchor calculation. Default value is the parent RectTransform.")]
    public RectTransform anchorRect;
    [Tooltip("The target RectTransform for normalized anchor calculation. Anchor values are applied to this target. Default value is the current RectTransform.")]
    public RectTransform currentRect;

    [Header("Anchors")]
    public float minXAnchor;
    public float minYAnchor;
    public float maxXAnchor;
    public float maxYAnchor;

    void Start()
    {
        try
        {
            anchorRect = transform.parent.GetComponent<RectTransform>();
            currentRect = GetComponent<RectTransform>();
        }
        catch { }

        calcAnchors();
    }

    void Update()
    {
        calcAnchors();
    }

    private void calcAnchors()
    {
        if (anchorRect && currentRect)
        {
            minXAnchor = currentRect.offsetMin.x / anchorRect.rect.width;
            minYAnchor = currentRect.offsetMin.y / anchorRect.rect.height;
            maxXAnchor = (currentRect.offsetMax.x + anchorRect.rect.width) / anchorRect.rect.width;
            maxYAnchor = (currentRect.offsetMax.y + anchorRect.rect.width) / anchorRect.rect.height;
        }
    }

    public void setAnchors()
    {
        if (anchorRect && currentRect)
        {
            currentRect.offsetMin = Vector2.zero;
            currentRect.offsetMax = Vector2.zero;

            currentRect.anchorMin = new Vector2(minXAnchor, minYAnchor);
            currentRect.anchorMax = new Vector2(maxXAnchor, maxYAnchor);
        }
        else
        {
            Debug.Log("Anchor Calc could not set anchors. Invalid target rects.");
        }
    }

    public void resetTargetRects()
    {
        try
        {
            anchorRect = transform.parent.GetComponent<RectTransform>();
            currentRect = GetComponent<RectTransform>();
        }
        catch { }
    }
}
