using UnityEngine;

public class destroy_object_after_animation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}