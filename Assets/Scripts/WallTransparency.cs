using UnityEngine;

public class WallTransparencyTrigger : MonoBehaviour
{
    [Header("Solid Wall Configuration")]
    public GameObject solidWall;          // The actual solid wall to make transparent

    [Header("Materials")]
    public Material transparentMaterial;  // Material for transparency
    private Material originalMaterial;    // Cache the original material

    private Renderer wallRenderer;        // Renderer of the solid wall

    void Start()
    {
        // Ensure the solid wall is properly assigned and has a Renderer
        if (solidWall != null)
        {
            wallRenderer = solidWall.GetComponent<Renderer>();

            if (wallRenderer != null)
            {
                originalMaterial = wallRenderer.material; // Cache the original material
            }
            else
            {
                Debug.LogError("WallTransparencyTrigger: No Renderer found on the solid wall.");
            }
        }
        else
        {
            Debug.LogError("WallTransparencyTrigger: Solid wall is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detect the player entering the trigger
        {
            Debug.Log("WallTransparencyTrigger: Player entered trigger zone.");
            MakeWallTransparent();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Detect the player exiting the trigger
        {
            Debug.Log("WallTransparencyTrigger: Player exited trigger zone.");
            RestoreWallMaterial();
        }
    }

    private void MakeWallTransparent()
    {
        if (wallRenderer != null && transparentMaterial != null)
        {
            wallRenderer.material = transparentMaterial; // Change to transparent material
            Debug.Log("WallTransparencyTrigger: Wall made transparent.");
        }
        else
        {
            Debug.LogError("WallTransparencyTrigger: Missing Renderer or Transparent Material.");
        }
    }

    private void RestoreWallMaterial()
    {
        if (wallRenderer != null && originalMaterial != null)
        {
            wallRenderer.material = originalMaterial; // Restore original material
            Debug.Log("WallTransparencyTrigger: Wall restored to original material.");
        }
        else
        {
            Debug.LogError("WallTransparencyTrigger: Missing Renderer or Original Material.");
        }
    }
}
