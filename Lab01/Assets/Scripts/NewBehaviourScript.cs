using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        if (count >= 9)
        {
            winText.SetActive(true);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickupCyl")
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

        }
        else if (other.gameObject.tag == "PickupCap")
        {
            other.gameObject.SetActive(false);
            count += 3;
            SetCountText();

        }
    }
}
