using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BallColourChange
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [SerializeField] private float curveTimeMultiplier;
        [SerializeField] private AnimationCurve scrollCurve;

        void FixedUpdate()
        {
            float xScrollSpeed = Time.time * curveTimeMultiplier;
            image.uvRect = new Rect(image.uvRect.position + new Vector2(scrollCurve.Evaluate(xScrollSpeed), 0) * Time.deltaTime, image.uvRect.size);
        }
    } 
}

