using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [Header("Propriedades do Player")]
    [SerializeField]
    private float playerSpeed;

    private Animator animator;
    private PhotonView photonView;

    // Start is called before the first frame update
    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.photonView = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if(this.photonView.IsMine == false)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(horizontal, vertical, 0);

        this.transform.position += input.normalized * playerSpeed * Time.deltaTime;

        if (input == Vector3.zero)
        {
            this.animator.SetBool("Flying", false);
        } else
        {
            this.animator.SetBool("Flying", true);
        }
    }
}
