using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI buttons, if you're using UI buttons to click.

public class SpriteChanger : MonoBehaviour
{
    public RawImage targetRawImage; // The RawImage component to change.
    public List<Texture> textureList; // List of textures to cycle through.

    private int currentIndex = 0; // Current texture index.

    void Start()
    {
        if (textureList == null || textureList.Count == 0)
        {
            Debug.LogError("Texture list is empty. Please assign textures to the textureList.");
            return;
        }

        // Set the initial texture.
        if (targetRawImage != null)
        {
            targetRawImage.texture = textureList[currentIndex];
        }
    }

    public void NextTexture()
    {
        if (textureList == null || textureList.Count == 0) return;

        currentIndex++;
        if (currentIndex >= textureList.Count)
        {
            currentIndex = 0; // Loop back to the first texture.
        }

        UpdateTexture();
    }

    public void PreviousTexture()
    {
        if (textureList == null || textureList.Count == 0) return;

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = textureList.Count - 1; // Loop back to the last texture.
        }

        UpdateTexture();
    }

    private void UpdateTexture()
    {
        if (targetRawImage != null)
        {
            targetRawImage.texture = textureList[currentIndex];
        }
    }
}
