using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float charSpeed = 1.0f;
    private Animator charAnimator;
    private CharacterController charController;

    public AnimationCurve aniCurve;
    public Renderer myRend;
    private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        charAnimator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        myMaterial = myRend.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(horizontal, 0.0f, vertical);

        charAnimator.SetBool("forward", (vertical > 0.1f));
        charAnimator.SetBool("backward", (vertical < -0.1f));

        if ((vertical < 0.1f)&&(vertical > -0.1f))
        {
            charAnimator.SetBool("right", (horizontal > 0.1f));
            charAnimator.SetBool("left", (horizontal < -0.1f));
        }   
        else
        {
            charAnimator.SetBool("right", false);
            charAnimator.SetBool("left", false);
        }
        charController.Move(moveVec*Time.deltaTime*charSpeed);
    }

    private IEnumerator ReactCoroutine ()
    {
        float timer = Time.time;
        float starttime = Time.time;
        Color myColor = myMaterial.color;
        while (timer<(starttime+3.0f))
        {
            timer += Time.deltaTime;
            float value = aniCurve.Evaluate((timer-starttime)/(3.0f));
            myColor.r = value;
            myMaterial.color = myColor;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ReactCoroutine());
    }

}
