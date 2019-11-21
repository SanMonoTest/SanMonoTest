using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorCtrl : MonoBehaviour
{
    protected Animator animator;
    protected string destination;   
    void Start()
    {
        animator = GameObject.Find("Canvas").GetComponent<Animator>();
    }
    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "changeScene") {
            destination = other.name;
            animator.SetTrigger("FadeOut");            
        }
    }
    public void OnFadeComplete() {
        SceneManager.LoadScene(destination);
    }
    
}
