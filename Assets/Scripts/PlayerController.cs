using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float jumpForce;
  private Rigidbody playerRigidbody;
  public bool isOnGround = true;
  // Start is called before the first frame update
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space) && isOnGround)
    {
      playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isOnGround = true;
    }
  }
}
