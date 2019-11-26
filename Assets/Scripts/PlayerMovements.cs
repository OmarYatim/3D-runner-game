using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    Transform[] positions = new Transform[3];
    int i = 1;

    [SerializeField]
    GameObject Ground;

    [SerializeField]
    GameObject LosePanel;

    [SerializeField]
    Text scoreText;

    float score;
    bool canJump;
    Rigidbody rb;
    Animator Anim;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            score += Time.deltaTime;
            scoreText.text = Mathf.RoundToInt(score).ToString();
            if (Input.GetButtonDown("Left") && i > 0)
            {
                i -= 1;
                transform.position = Vector3.MoveTowards(transform.position, positions[i].position, 1.2f);
            }
            if (Input.GetButtonDown("Right") && i < 2)
            {
                i += 1;
                transform.position = Vector3.MoveTowards(transform.position, positions[i].position, 1.2f);
            }
            if (Input.GetButtonDown("Jump") && canJump)
            {
                rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
                Anim.SetBool("Jumping", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Instantiate(Ground, other.transform.position + new Vector3(0,0,other.bounds.size.z) * 2, Quaternion.identity);
        Destroy(other.gameObject.transform.parent.gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            Anim.SetBool("Jumping", false);
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Lost");
            Anim.SetBool("Death", true);
            isDead = true;
            //Time.timeScale = 0;
            LosePanel.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
