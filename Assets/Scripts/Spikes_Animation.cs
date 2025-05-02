using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_Animation : MonoBehaviour
{
    public Animator animator;
    private bool isActive = false;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpikeRoutine());
    }

    private System.Collections.IEnumerator SpikeRoutine()
    {
        while (true)
        {
            animator.SetTrigger("PopOut");
            yield return new WaitForSeconds(0.5f);
            isActive = true;
            yield return new WaitForSeconds(2.0f);

            animator.SetTrigger("PopIn");
            yield return new WaitForSeconds(0.5f);
            isActive = false;
            yield return new WaitForSeconds(2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsDangerous()
    {
        return isActive;
    }
}
