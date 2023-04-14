using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIAutoAlign : MonoBehaviour
{
    public enum AlignType
    {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    [SerializeField] private AlignType Align = AlignType.TopRight;
    [SerializeField] private float Offset = 10f;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        AlignPanel(Align, Offset);
    }

    void LateUpdate()
    {
        AlignPanel(Align, Offset);
    }

    private void AlignPanel(AlignType alignType, float offset)
    {
        if (rectTransform != null) {
            if(offset < 0f) {
                offset = 0f;
            }

            switch (alignType) {
                case AlignType.TopLeft:
                    rectTransform.anchorMin = new Vector2(0f, 1f);
                    rectTransform.anchorMax = new Vector2(0f, 1f);
                    rectTransform.anchoredPosition = new Vector3(
                        rectTransform.rect.width / 2f + offset,
                        rectTransform.rect.height / -2f - offset,
                        0f
                    );
                    break;
                case AlignType.TopCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 1f);
                    rectTransform.anchorMax = new Vector2(0.5f, 1f);
                    rectTransform.anchoredPosition = new Vector3(
                        0f,
                        rectTransform.rect.height / -2f - offset,
                        0f
                    );
                    break;
                case AlignType.TopRight:
                    rectTransform.anchorMin = new Vector2(1f, 1f);
                    rectTransform.anchorMax = new Vector2(1f, 1f);
                    rectTransform.anchoredPosition = new Vector3(
                        rectTransform.rect.width / -2f - offset,
                        rectTransform.rect.height / -2f - offset,
                        0f
                    );
                    break;
                case AlignType.MiddleLeft:
                    rectTransform.anchorMin = new Vector2(0f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0f, 0.5f);
                    rectTransform.anchoredPosition = new Vector3(
                        rectTransform.rect.width / 2f + offset,
                        0f,
                        0f
                    );
                    break;
                case AlignType.MiddleCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    rectTransform.anchoredPosition = new Vector3(
                        0f,
                        0f,
                        0f
                    );
                    break;
                case AlignType.MiddleRight:
                    rectTransform.anchorMin = new Vector2(1f, 0.5f);
                    rectTransform.anchorMax = new Vector2(1f, 0.5f);
                    rectTransform.anchoredPosition = new Vector3(
                        rectTransform.rect.width / -2f - offset,
                        0f,
                        0f
                    );
                    break;
                case AlignType.BottomLeft:
                    rectTransform.anchorMin = new Vector2(0f, 0f);
                    rectTransform.anchorMax = new Vector2(0f, 0f);
                    rectTransform.anchoredPosition = new Vector3(
                        rectTransform.rect.width / 2f + offset,
                        rectTransform.rect.height / 2f + offset,
                        0f
                    );
                    break;
                case AlignType.BottomCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 0f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0f);
                    rectTransform.anchoredPosition = new Vector3(
                        0f,
                        rectTransform.rect.height / 2f + offset,
                        0f
                    );
                    break;
                case AlignType.BottomRight:
                    rectTransform.anchorMin = new Vector2(1f, 0f);
                    rectTransform.anchorMax = new Vector2(1f, 0f);
                    rectTransform.anchoredPosition = new Vector3(
                        rectTransform.rect.width / -2f - offset,
                        rectTransform.rect.height / 2f + offset,
                        0f
                    );
                    break;
            }
        }
    }
}
