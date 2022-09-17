using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    public Material flashMaterial;
    private SpriteRenderer _spriteRenderer;
    private Material _originalMaterial;

    void Start()
    {
        // Get the SpriteRenderer to be used.
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the material that the SpriteRenderer uses, 
        // so we can switch back to it after the flash ended.
        _originalMaterial = _spriteRenderer.material;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        _spriteRenderer.material = flashMaterial;
        this.gameObject.GetComponent<AudioSource>().Play();
        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(0.1f);

        // After the pause, swap back to the original material.
        _spriteRenderer.material = _originalMaterial;
    }
}
