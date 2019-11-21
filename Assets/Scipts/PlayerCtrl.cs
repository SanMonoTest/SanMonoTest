using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    Animator playerAnime;
    public float speed;
    [SerializeField]private float inputH;
    [SerializeField]private float inputV;

    // Start is called before the first frame update
    void Start() {
        playerAnime = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        //Debug.Log(this.GetComponent<SpriteRenderer>().sprite);

        float angle = Mathf.Atan2(inputV, inputH);
        Vector2 movement = new Vector2(Mathf.Abs(inputH) * Mathf.Cos(angle), Mathf.Abs(inputV) * Mathf.Sin(angle)) * speed * Time.deltaTime;
        this.transform.Translate(movement);

        if (Input.anyKey) {
            playerAnime.SetFloat("inputH", inputH);
            playerAnime.SetFloat("inputV", inputV);
        }
        if (inputH != 0 || inputV != 0) {
            playerAnime.SetBool("moveCheck", true);
        } else {
            playerAnime.SetBool("moveCheck", false);
        }
    }
}