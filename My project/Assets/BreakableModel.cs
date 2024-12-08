using UnityEngine;

public class BreakableModel : MonoBehaviour
{

    public void DetachChildrenAndAddRigidbody()
    {
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.gameObject.AddComponent<Rigidbody>();


            rb.mass = 4f; 
            rb.useGravity = true;
            rb.drag = 0.5f;

            if (child.gameObject.GetComponent<Collider>() == null)
            {
                child.gameObject.AddComponent<MeshCollider>().convex = true;
            }

            child.SetParent(null);
        }

        gameObject.SetActive(false); 
    }
}
