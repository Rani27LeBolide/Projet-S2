using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float turnspeed;
	public float speedback;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;
	public float TimeRespawn;
	public Vector3 initposition;
	float inertie = 0;
	float timelastinputright = 0;
	float timelastinputleft = 0;
	float jumpcooldown = 0;
	string lastkey = "";
	float todecrement = 0.5F;
	int jumphigh = 0;
	private AudioSource source;
	public AudioClip BonusSound;
	public Sprite Bonus1;
	public Sprite BonusNone;
	public AudioClip PickUpSound;
	int Timetoleftbonus = 0;
    PhotonView _view;

	void Awake () 
	{
		source = GetComponent<AudioSource>();
        _view = GetComponent<PhotonView>();
    }
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
        

	}

    void FixedUpdate()
    {

        if (_view.isMine)
        {
            decrement();
            transform.Translate(Vector3.forward * Time.deltaTime * inertie);
            transform.Translate(Vector3.up * Time.deltaTime * jumphigh);
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumpcooldown <= 0)
                {
                    jumpcooldown = 60;
                    jumphigh = 20;
                }

            }
            if (Timetoleftbonus > 0)
            {
                inertie = speed * 1.3F;
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * -(turnspeed + (inertie)));
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    transform.Rotate(Vector3.up * Time.deltaTime * (turnspeed + (inertie)));
                }
            }
            else
            {
                /*if (inertie > speed) {
                    todecrement = 10;
                }*/
                if (Input.GetKey(KeyCode.Q) & !(Input.GetKey(KeyCode.S)))
                {
                    if (timelastinputright > 0)
                    {
                        todecrement = 0.5F;
                        if (inertie < speed)
                        {
                            inertie += timelastinputright / 25;
                            if (lastkey == "q")
                            {
                                timelastinputright = 0;
                            }
                        }
                    }
                    else
                    {

                        transform.Rotate(Vector3.up * Time.deltaTime * -(turnspeed - (inertie * 2.5F)));
                        if (inertie < speed / 2)
                        {
                            todecrement = 0.1F;
                        }
                    }
                    timelastinputleft = 60;
                    lastkey = "q";
                }
                else if (Input.GetKey(KeyCode.S) & !(Input.GetKey(KeyCode.Q)))
                {
                    if (timelastinputleft > 0)
                    {
                        todecrement = 0.5F;
                        if (inertie < speed)
                        {
                            inertie += timelastinputleft / 25;
                            if (lastkey == "s")
                            {
                                timelastinputleft = 0;
                            }
                        }
                    }
                    else
                    {

                        transform.Rotate(Vector3.up * Time.deltaTime * (turnspeed - (inertie * 2.5F)));
                        if (inertie < speed / 2)
                        {
                            todecrement = 0.1F;
                        }
                    }
                    timelastinputright = 60;
                    lastkey = "s";
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(-Vector3.forward * Time.deltaTime * speedback);
                }
            }
        }
    
    }

	void decrement ()
	{
		if (inertie > 0) {
			inertie = inertie - todecrement;
		}
		if (timelastinputleft > 0) {
			timelastinputleft--;
		}
		if (timelastinputright > 0) {
			timelastinputright--;
		}
		if (jumpcooldown > 0) {
			jumpcooldown--;
		}
		if (jumphigh > 0) {
			jumphigh--;
		}
		if (Timetoleftbonus > 0) {
			Timetoleftbonus--;
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Pick Up"))
		{
			other.gameObject.SetActive (false);
			source.PlayOneShot (PickUpSound);
			count = count + 1;
		}
		if (other.gameObject.CompareTag ("Bonus"))
		{
			other.gameObject.SetActive (false);
			source.PlayOneShot (BonusSound);
			Timetoleftbonus = 250;

		}

	}
}
