using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowTransition : MonoBehaviour
{

    public Transform newFollowTarget; // Set this in the Inspector or assign it dynamically in code
    public CinemachineVirtualCamera virtualCamera;
    public float transitionDuration = 1.0f;

    void Start()
    {
        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        // Change the follow target with a smooth transition
        StartCoroutine(ChangeFollowTargetSmooth(newFollowTarget, transitionDuration));
    }

    IEnumerator ChangeFollowTargetSmooth(Transform newTarget, float duration)
    {
        if (virtualCamera != null)
        {
            CinemachineBrain cinemachineBrain = FindObjectOfType<CinemachineBrain>();

            // Set the default blend to ease in and out
            cinemachineBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
            cinemachineBrain.m_DefaultBlend.m_Time = duration;

            // Change the follow target with a smooth transition
            virtualCamera.Follow = newTarget;

            // Wait for the transition to complete
            yield return new WaitForSeconds(duration);

            // Reset the default blend to its original values
            cinemachineBrain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
            cinemachineBrain.m_DefaultBlend.m_Time = 0f;
        }
    }
}


