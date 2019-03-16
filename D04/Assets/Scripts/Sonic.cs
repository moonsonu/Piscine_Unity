using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sonic : MonoBehaviour
{
	[HideInInspector]public int			rings;
    [HideInInspector]public int lifelost;
	public float		speedFactor;
	[HideInInspector]public float		speed;
	public float		maxSpeed;
	public float		jumpHeight;
	public float		rollingBoost;

	private Animator	animator;
    //public Animator flaganimator;
	private Rigidbody2D	rbody;
	private Vector2 velocity;
	private float vMagnitude;
	private float acceleration;
	private float launchTime;
	[HideInInspector]public bool isGrounded;
	private bool isOnGroundNow;
    public bool isFinish = false;
	[HideInInspector]public bool isCharging;
	[HideInInspector]public bool isRolling;
	[HideInInspector]public bool isJumpball;
	[HideInInspector]public bool isAirborne;
    [HideInInspector]public bool isHit;
	[HideInInspector]public bool isDead;
	[HideInInspector]public bool isInvincible;
	[HideInInspector]public bool isShielded;
	[HideInInspector]public float charge;
	public GameObject currentShield;
	public PhysicsMaterial2D standardMat;
	public PhysicsMaterial2D rollMat;
	private PhysicsMaterial2D currentMat;
	public GameObject checkpoint;
	public AudioSource aRoll;
	public AudioSource aJump;
	public AudioSource aCharge;
	public AudioSource aDestroy;
	public AudioSource aLoseRings;
	public AudioSource aSpike;
	public AudioSource aDeath;
    public AudioSource aRing;
    public AudioSource aNextlevel;
    public AudioSource aBumper;
    //public GameObject flag;
    public GameObject coinexplosion;
    public GameObject brokenTV;

	void Awake()	{
		animator = GetComponent<Animator>();
        //flaganimator = flag.GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D>();
		currentMat = GetComponent<CircleCollider2D>().sharedMaterial;
        //flaganimator.SetBool("flag", false);
	}

	void FixedUpdate() 	{
		accelerate();
		checkRoll();
	}

	void Update() {
		calcAcceleration();
		checkCharge();
		lookUpAndDown();
		checkSpaceButton();
		checkFalling();
	}

	void Start() {
		respawn();
	}

	void checkFalling() {
		if (transform.position.y < -15 && isDead == false)
			dead ();
	}

	void calcAcceleration() {
		acceleration = Input.GetAxis("Horizontal") * speedFactor;
		if (isRolling == true) {
			if (isGrounded == false)
				acceleration = acceleration / 3;
			else
				acceleration = 0;
		}
		if (acceleration != 0 && isHit == false && isCharging == false) {
			if (rbody.velocity.x < -0.05f)
				transform.localScale = new Vector2(-1, 1);
			else if (rbody.velocity.x > 0.05f)
				transform.localScale = new Vector2(1, 1);
		}
		velocity = rbody.velocity;
		vMagnitude = velocity.magnitude;
		animator.SetFloat("speed", Mathf.Abs(vMagnitude));
	}

	void accelerate() {
		if (vMagnitude < maxSpeed && isHit == false && isCharging == false)
			rbody.AddForce(new Vector2(acceleration, 0));
	}

	void lookUpAndDown() {
		if (Input.GetAxis("Vertical") < 0) {
			if (vMagnitude == 0)
				animator.SetBool("down", true);
		}
		else
			animator.SetBool("down", false);
	}

	void checkRoll() {
		if (Input.GetAxis("Vertical") < 0 && vMagnitude > 5 && isGrounded == true) {
			isRolling = true;
			GetComponent<CircleCollider2D>().sharedMaterial  = rollMat;
			rbody.drag = 0;
			animator.SetBool ("rolling", true);
			if (!aRoll.isPlaying)
				aRoll.Play();
		}
		if (vMagnitude < 5 && Time.time > launchTime ) {
			isRolling = false;
			GetComponent<CircleCollider2D>().sharedMaterial = standardMat;
			rbody.drag = 0.5f;
			animator.SetBool ("rolling", false);
		}
	}


	void checkCharge() {
		if ((Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.DownArrow)) && isCharging == true) {
			animator.SetBool ("rolling", true);
			animator.SetBool ("charge", false);
			aRoll.Play();
			isRolling = true;
			isCharging = false;
			launchTime = Time.time + 1;
			rbody.AddForce(new Vector2(charge * maxSpeed * transform.localScale.x, 0), ForceMode2D.Impulse);
			charge = 0;
		}
	}

	void checkSpaceButton() {
		if (Input.GetKeyDown("space") && isGrounded == true && rbody.velocity.y < 5 && isHit == false) {
			if (vMagnitude == 0 && Input.GetAxis("Vertical") < 0 )
				chargeRoll();
			else
				jump ();
		}
	}

	void jump() {
		isRolling = false;
		isJumpball = true;
		isGrounded = false;
		aJump.Play();
		animator.SetBool("rolling", false);
		animator.SetBool("jumpball", true);
		rbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
	}

	void chargeRoll() {
		aCharge.Play ();
		animator.SetBool("charge", true);
		isCharging = true;
		charge += 0.75f;
		if (charge >= 2.25f)
			charge = 2.25f;
	}


	public void rampBoost(float direction, float boost) {
		if (rbody.velocity.x > 2.5f) {
			rbody.AddForce(new Vector2(boost * transform.localScale.x, 1), ForceMode2D.Impulse);
		}
	}

	public void bumper(float boostX, float boostY) {
		if (boostY  > 0) {
			isJumpball = false;
			isAirborne = true;
			animator.SetBool("jumpball", false);
			animator.SetBool("airborne", true);
		}
		if (boostY != 0)
			rbody.velocity = new Vector2(rbody.velocity.x, 0);
		if (boostX != 0)
			rbody.velocity = new Vector2(0, rbody.velocity.y);
		if (boostX < 0)
			transform.localScale = new Vector2(-1, 1);
		else
			transform.localScale = new Vector2(1, 1);
		rbody.AddForce(new Vector2(boostX * 4, boostY * 4), ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "moving") {
			isJumpball = false;
			animator.SetBool("jumpball", false);
			isAirborne = false;
			animator.SetBool("airborne", false);
		}
        if (collision.gameObject.tag == "Ring")
        {
            aRing.Play();
            Destroy(collision.gameObject);
            rings += 1;
        }
        if (collision.gameObject.tag == "Flag")
        {
            finishGame();
        }
        if (collision.gameObject.tag == "Trap")
        {
            getHit();
            Instantiate(coinexplosion, collision.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "TVRing")
        {
            if (isRolling)
            {
                collision.isTrigger = true;
                StartCoroutine(breakTV(collision.gameObject));
            }
            else if (!isRolling)
            {
                collision.isTrigger = false;
            }

        }
        if (collision.gameObject.tag == "Bumper")
        {
            aBumper.Play();
            bumper(5, 5);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            getHit();
            Destroy(collision.gameObject);
        }
	}

	void OnTriggerStay2D(Collider2D collision) {
		if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "moving") {
			isGrounded = true;
			isOnGroundNow = true;
			if (isHit == false)
				animator.SetBool("getHit", false);
		}
		if (collision.gameObject.tag == "moving")
			transform.parent = collision.transform;
        if (collision.gameObject.tag == "TVRing")
        {
            Debug.Log("tv");
            collision.isTrigger = false;
        }
	}

	void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.tag == "ground") {
			isOnGroundNow = false;
			Invoke("deGround", 0.4f);
		}

		if (collision.gameObject.tag == "moving") {
			isOnGroundNow = false;
			Invoke("deGround", 0.4f);
			transform.parent = null;
		}
        //if (collision.gameObject.tag == "TVRing")
        //{
        //    Debug.Log("tv");
        //    collision.isTrigger = false;
        //}
	}

	void deGround() {
		if (isOnGroundNow == false)
			isGrounded = false;
	}

	public void destroy() {
		rbody.AddForce(new Vector2(0, 12), ForceMode2D.Impulse);
		aDestroy.Play ();
	}

	public void getHit() {
        isHit = true;
        aLoseRings.Play();
        animator.SetBool("getHit", true);
        rings = 0;
        rbody.velocity = new Vector2(rbody.velocity.x, 0);
        rbody.velocity = new Vector2(0, rbody.velocity.y);
        transform.localScale = new Vector2(1, 1);
        rbody.AddForce(new Vector2(4, 5), ForceMode2D.Impulse);
        StartCoroutine(GetHit());
        StartCoroutine(invincible());
        if (rings <= 0)
            dead();

		// ▌─────────────────────────▐█─────▐
		// ▌────▄──────────────────▄█▓█▌────▐
		// ▌───▐██▄───────────────▄▓░░▓▓────▐
		// ▌───▐█░██▓────────────▓▓░░░▓▌────▐
		// ▌───▐█▌░▓██──────────█▓░░░░▓─────▐
		// ▌────▓█▌░░▓█▄███████▄███▓░▓█─────▐
		// ▌────▓██▌░▓██░░░░░░░░░░▓█░▓▌─────▐
		// ▌─────▓█████░░░░░░░░░░░░▓██──────▐
		// ▌─────▓██▓░░░░░░░░░░░░░░░▓█──────▐
		// ▌─────▐█▓░░░░░░█▓░░▓█░░░░▓█▌─────▐
		// ▌─────▓█▌░▓█▓▓██▓░█▓▓▓▓▓░▓█▌─────▐
		// ▌─────▓▓░▓██████▓░▓███▓▓▌░█▓─────▐
		// ▌────▐▓▓░█▄▐▓▌█▓░░▓█▐▓▌▄▓░██─────▐
		// ▌────▓█▓░▓█▄▄▄█▓░░▓█▄▄▄█▓░██▌────▐
		// ▌────▓█▌░▓█████▓░░░▓███▓▀░▓█▓────▐
		// ▌───▐▓█░░░▀▓██▀░░░░░─▀▓▀░░▓█▓────▐
		// ▌───▓██░░░░░░░░▀▄▄▄▄▀░░░░░░▓▓────▐
		// ▌───▓█▌░░░░░░░░░░▐▌░░░░░░░░▓▓▌───▐
		// ▌───▓█░░░░░░░░░▄▀▀▀▀▄░░░░░░░█▓───▐
		// ▌──▐█▌░░░░░░░░▀░░░░░░▀░░░░░░█▓▌──▐
		// ▌──▓█░░░░░░░░░░░░░░░░░░░░░░░██▓──▐
		// ▌──▓█░░░░░░░░░░░░░░░░░░░░░░░▓█▓──▐
		// ▌──██░░░░░░░░░░░░░░░░░░░░░░░░█▓──▐
		// ▌──█▌░░░░░░░░░░░░░░░░░░░░░░░░▐▓▌─▐
		// ▌─▐▓░░░░░░░░░░░░░░░░░░░░░░░░░░█▓─▐
		// ▌─█▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓─▐
		// ▌─█▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▌▐
		// ▌▐█▓░░░░░░░░░░░░░░░░░░░░░░░░░░░██▐
		// ▌█▓▌░░░░░░░░░░░░░░░░░░░░░░░░░░░▓█▐
		// ██████████████████████████████████
		// █░▀░░░░▀█▀░░░░░░▀█░░░░░░▀█▀░░░░░▀█
		// █░░▐█▌░░█░░░██░░░█░░██░░░█░░░██░░█
		// █░░▐█▌░░█░░░██░░░█░░██░░░█░░░██░░█
		// █░░▐█▌░░█░░░██░░░█░░░░░░▄█░░▄▄▄▄▄█
		// █░░▐█▌░░█░░░██░░░█░░░░████░░░░░░░█
		// █░░░█░░░█▄░░░░░░▄█░░░░████▄░░░░░▄█
		// ██████████████████████████████████

	}

	void stopHit() {
		isHit = false;
	}

	void dead(){
		aDeath.Play ();
		animator.SetBool("dead", true);
		isDead = true;
        lifelost += 1;
        PlayerPrefs.SetInt("lifelost", lifelost);
		rbody.AddForce (new Vector2(0, 15), ForceMode2D.Impulse);
		GetComponent<CircleCollider2D>().enabled = false;
		Camera.main.transform.parent = null;
		Invoke("newLife", 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}

	void newLife() {
		isHit = false;
		isDead = false;
		//Application.LoadLevel(Application.loadedLevel);
	}

	void respawn() {
		Camera.main.transform.parent = transform;
		Camera.main.transform.localPosition = new Vector2(0, 1.5f);
		rbody.velocity = Vector2.zero;
		transform.position = checkpoint.transform.position;
	}

    void finishGame()
    {
        isFinish = true;
        aNextlevel.Play();
        //flaganimator.SetTrigger("isRotate");
        //flaganimator.SetBool("flag", true);
        StartCoroutine(delayLoad());
        PlayerPrefs.SetInt("totalring", rings);

    }

	IEnumerator invincible() {
		isInvincible = true;
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		for (int i = 0; i < 15; i++) {
			sr.color = Color.clear;
			yield return new WaitForSeconds(0.1f);
			sr.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
		isInvincible = false;
	}
    IEnumerator delayLoad()
    {
        yield return new WaitForSeconds(5);
        if (SceneManager.GetActiveScene().name == "AngelIsland")
        {
            PlayerPrefs.SetInt("angelbestscore", rings);
            PlayerPrefs.SetInt("angelunlocked", 1);
        }
        else if (SceneManager.GetActiveScene().name == "OilOcean")
        {
            PlayerPrefs.SetInt("oilbestscore", rings);
            PlayerPrefs.SetInt("oilunlocked", 1);
        }
        else if (SceneManager.GetActiveScene().name == "FlyingBattery")
        {
            PlayerPrefs.SetInt("flyingbestscore", rings);
            PlayerPrefs.SetInt("flyingunlocked", 1);
        }
        else if (SceneManager.GetActiveScene().name == "IceZone")
        {
            PlayerPrefs.SetInt("chemicalbestscore", rings);
            PlayerPrefs.SetInt("chemicalunlocked", 1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator GetHit()
    {
        yield return new WaitForSeconds(2);
        stopHit();

    }
    IEnumerator breakTV(GameObject tv)
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(tv);
        brokenTV.transform.position = tv.transform.position;
        rings += 10;
        destroy();
    }
}
