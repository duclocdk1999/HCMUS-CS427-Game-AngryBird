using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : MonoBehaviour
{
    private Vector3 _initialPosition;
    // private float _timeSittingAround = 0;
    // bool birdWasLaunched = false;

    [SerializeField] private float _launchPower = 150;
    // --------------------------------------------------------------
    // Start is called before the first frame update
    private void Start()
    {
        _initialPosition = transform.position;
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
    }
    // --------------------------------------------------------------
    // Update is called once per frame
    private void Update()
    {
        // GetComponent<LineRenderer>().SetPosition(0, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
    }
    // --------------------------------------------------------------
    private void OnMouseDown()
    {
        GetComponent<LineRenderer>().enabled = true;
    }
    // --------------------------------------------------------------
    private void OnMouseDrag()
    {
        // the postion of mouse is different from the world-game-position
        // therefore, need this below step to handle mouse position
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // when we click the mouse, the z dimension of bird is modified to -10
        // --> near camera, camera can't observe the bird
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
    // --------------------------------------------------------------
    private void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce((_initialPosition - transform.position) * _launchPower);
        GetComponent<LineRenderer>().enabled = false;
    }
}

















