using UnityEngine;

public class Fade : MonoBehaviour
{
    AnimatorCtrl animatorCtrl;
    void Start() {
        animatorCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimatorCtrl>();
    }
    public void FadeEvent() {
        animatorCtrl.OnFadeComplete();
    }
}
