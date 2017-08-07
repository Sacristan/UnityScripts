﻿/*
 * Origin JoaoPaul54: https://forum.unity3d.com/threads/text-with-underline.436291/
 * TODO: optimise
 */

using UnityEngine.UI;
using UnityEngine;

namespace Sacristan.Utils.UI
{
    public class ExtendedText : Text
    {
        private int underlineEnd = 0;
        private RectTransform textRectTransform = null;
        private TextGenerator textGenerator = null;

        private GameObject lineGameObject = null;
        private Image lineImage = null;
        private RectTransform lineRectTransform = null;

        [Tooltip("Must be a positive integer")]
        public int underlineStart = 0;
        public bool Underline;
        private bool currentUnderlineState;
        private new CanvasRenderer canvasRenderer;

        private void Update()
        {
            if (currentUnderlineState != Underline)
            {
                if (Underline == false)
                {
                    GetUnderlineObject();
                    DestroyImmediate(lineGameObject);
                }
                currentUnderlineState = Underline;
            }

            if (Underline && underlineStart >= 0)
            {
                if (lineGameObject == null || textGenerator == null || lineImage == null || lineRectTransform == null || textRectTransform == null)
                {
                    GetUnderlineObject();
                    if (lineGameObject == null)
                        AddUnderline();
                }
                UpdateUnderline();
            }
        }

        public void UpdateUnderline()
        {
            if (Underline && lineGameObject != null)
            {
                if (underlineEnd != text.Length)
                {
                    underlineEnd = text.Length;
                }

                lineImage.color = this.color;
                if (textGenerator.characterCount < 0)
                    return;
                UICharInfo[] charactersInfo = textGenerator.GetCharactersArray();
                if (!(underlineEnd > underlineStart && underlineEnd < charactersInfo.Length))
                    return;
                UILineInfo[] linesInfo = textGenerator.GetLinesArray();
                if (linesInfo.Length < 1)
                    return;
                float height = linesInfo[0].height;
                Canvas canvas = gameObject.GetComponentInParent<Canvas>();
                float factor = 1.0f / canvas.scaleFactor;
                lineRectTransform.anchoredPosition = new Vector2(
                    factor * (charactersInfo[underlineStart].cursorPos.x + charactersInfo[underlineEnd].cursorPos.x) / 2.0f,
                    factor * (charactersInfo[underlineStart].cursorPos.y - height / 1.0f)
                    );
                lineRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, factor * Mathf.Abs(charactersInfo[underlineStart].cursorPos.x - charactersInfo[underlineEnd].cursorPos.x));
                lineRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height / 10.0f);
            }
        }

        private void GetUnderlineObject()
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Underline")
                {
                    textRectTransform = gameObject.GetComponent<RectTransform>();
                    textGenerator = cachedTextGenerator;
                    lineGameObject = child.gameObject;
                    lineImage = lineGameObject.GetComponent<Image>();
                    canvasRenderer = GetComponent<CanvasRenderer>();
                    lineImage.color = canvasRenderer.GetColor();
                    lineRectTransform = lineGameObject.GetComponent<RectTransform>();
                    lineRectTransform.SetParent(transform, false);
                    lineRectTransform.anchorMin = textRectTransform.pivot;
                    lineRectTransform.anchorMax = textRectTransform.pivot;
                }
            }
        }

        private void AddUnderline()
        {
            textRectTransform = gameObject.GetComponent<RectTransform>();
            textGenerator = cachedTextGenerator;
            lineGameObject = new GameObject("Underline");
            lineImage = lineGameObject.AddComponent<Image>();
            canvasRenderer = GetComponent<CanvasRenderer>();

            lineRectTransform = lineGameObject.GetComponent<RectTransform>();
            lineRectTransform.SetParent(transform, false);
            lineRectTransform.anchorMin = textRectTransform.pivot;
            lineRectTransform.anchorMax = textRectTransform.pivot;
        }
    }
}