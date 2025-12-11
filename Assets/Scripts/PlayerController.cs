using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    //public TextMeshProUGUI countText;
    public TMP_Text countText;
    public GameObject youWinText;
    Rigidbody rb;
    int count;
    int totalCount;
    float movementX;
    float movementY;
    GameObject enemyGameObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        totalCount = GameObject.
            FindGameObjectsWithTag("PICKUP").Length;
        SetCountText();
        youWinText.SetActive(false);
        enemyGameObject = GameObject.
            FindGameObjectWithTag("ENEMY");
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector 
            = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("PICKUP"))
        if (other.CompareTag("PICKUP"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            if (count >= totalCount)
            {
                youWinText.SetActive(true);
                //Destroy(GameObject.FindGameObjectWithTag("ENEMY"));
                Destroy(enemyGameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ENEMY"))
        {
            this.gameObject.SetActive(false);
            youWinText.SetActive(true);
            youWinText.GetComponent<TMP_Text>().text
                = "You Lose!";
        }
    }

    void SetCountText()
    {
        countText.text = $"Count : {count}";
    }
}
