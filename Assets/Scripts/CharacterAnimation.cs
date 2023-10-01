using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public float speed = 0f;
    public float turn = 0f;
    public float acceleration = 0.1f;
    private Animator animator;

    int speedHash;
    int turnHash;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        speed = 0;
        speedHash = Animator.StringToHash("Speed");
        turnHash = Animator.StringToHash("Turn");
    }

    // Update is called once per frame
    void Update()
    {
        //#region 1D Blend Tree
        //bool walk = Input.GetKey("w");
        //if (walk)
        //{
        //    speed = Mathf.Min(1, speed + Time.deltaTime * acceleration);
        //}
        //else
        //{
        //    speed = Mathf.Max(0, speed - Time.deltaTime * acceleration);
        //}

        //animator.SetFloat(speedHash, speed);
        //#endregion

        #region 2D Blend Tree
        bool walk = Input.GetKey("w");
        bool left = Input.GetKey("a");
        bool right = Input.GetKey("d");

        if (walk)
        {
            speed = Mathf.Min(1, speed + Time.deltaTime * acceleration);
        }
        else
        {
            speed = Mathf.Max(0, speed - Time.deltaTime * acceleration);
        }

        if (left)
        {
            turn = Mathf.Max(-2, turn - Time.deltaTime * acceleration);
        }
        if (right)
        {
            turn = Mathf.Min(2, turn + Time.deltaTime * acceleration);
        }
        animator.SetFloat(speedHash, speed);
        animator.SetFloat(turnHash, turn);
        #endregion
    }


}
