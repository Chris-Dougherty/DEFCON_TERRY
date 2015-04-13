using UnityEngine;
using System.Collections;

public class DefenceTurret : MonoBehaviour {

    // Player camera
    private Camera camera;

    // Health I guess
    [SerializeField]
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public int MaxHealth = 200;

    private bool selected;
    public bool Selected
    {
        get
        {
            return selected;
        }
        set
        {
            selected = value;
            CheckBool(selected, Group);
        }
    }

    // Navmesh
    public NavMeshAgent Agent;

    public GroupManager Group;

    // Animator
    //public Animator anim;

    //Shooting
    float fireRate = 1.0f;
    private float lastShot = 0.0f;
    public float FireRate = 1.6f;
    protected float NextFire = 0.0f;
    public GameObject Bullet;

    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
        Group = FindObjectOfType<GroupManager>();
        //Group.DeactiveSelected.Add(this.gameObject);
        Health = MaxHealth;
    }

    void FixedUpdate()
    {
        DetectOthers();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckSelected();
        //CheckMovement();
        //DoAnims();
    }

    void DoAnims()
    {
        //if (Agent.velocity == Vector3.zero)
        //{
        //    anim.SetBool("Moving", false);
        //}
        //else
        //{
        //    anim.SetBool("Moving", true);
        //}
    }

    protected void CheckSelected()
    {
        // Only check if unit is on screen
        if (Input.GetMouseButton(0))
        {
            // Get Camera view and use selection box
            Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
            camPos.y = CameraManager.InvertMouseY(camPos.y);
            Selected = CameraManager.Selection.Contains(camPos);

            // Raycast to select invididual unit
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    Selected = true;
                }
            }

            // Raycast to select all units of same types
            if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.A))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "PlayerUnit")
                    {
                        Selected = true;
                    }
                }
            }
        }

        // Set visuals if unit is selected or not
        if (Selected)
        {
            //GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            //GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    protected void CheckMovement()
    {
        // Right click and move unit to where player clicked
        if (Input.GetMouseButtonDown(1))
        {
            if (Selected)
            {
                // Raycast
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        // Move unit cooooooool
                        Agent.SetDestination(hit.point);
                    }
                }
            }
        }
    }

    // Detect for combat
    void DetectOthers()
    {
        //int LayerMask = 1 << 11;

        Collider[] hits = Physics.OverlapSphere(this.transform.position, 10.0f);

        // Detect unit and shoot if enemy
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.tag == "PlayerUnit" || hits[i].gameObject.tag == "PlayerUnitPlane" || hits[i].gameObject.tag == "PlayerUnitTank")
            {
                NextFire = Time.time + FireRate;
                //hits[i].gameObject.GetComponent<TankUnit>().TakeDamage(1, Group);
                Shoot(hits[i]);
            }
        }
    }

    // combat
    void Shoot(Collider c)
    {
        // If they can shoot, launch out bullet and take damage away from target
        if (Time.time > fireRate + lastShot)
        {
            GameObject clone = Instantiate(Bullet, this.transform.position, Quaternion.identity) as GameObject;
            clone.gameObject.GetComponent<Bullet>().LerpToTarget(c);
            if (c.gameObject.tag == "PlayerUnit")
                c.gameObject.GetComponent<TransportUnit>().TakeDamage(15, Group);
            if (c.gameObject.tag == "PlayerUnitPlane")
                c.gameObject.GetComponent<PlaneUnit>().TakeDamage(15, Group);
            if (c.gameObject.tag == "PlayerUnitTank")
                c.gameObject.GetComponent<TankUnit>().TakeDamage(15, Group);
            lastShot = Time.time + fireRate;
        }
    }

    // Check if object is selected or not
    protected void CheckBool(bool select, GroupManager Group)
    {
        // If object is selected
        if (select)
        {
            // If its not already in the list, add to active remove from deactive
            if (!Group.ActiveSelected.Contains(this.gameObject))
            {
                Group.ActiveSelected.Add(this.gameObject);
                Group.DeactiveSelected.Remove(this.gameObject);
            }
        }
        else if (!select)
        {
            // If is in the active list remove and add to deactive
            if (Group.ActiveSelected.Contains(this.gameObject))
            {
                Group.ActiveSelected.Remove(this.gameObject);
                Group.DeactiveSelected.Add(this.gameObject);
            }
        }
    }

    // Live or die
    public void TakeDamage(int val)
    {
        if (health > 0)
        {
            health -= val;
        }
        else if (Health <= 0)
        {
            Destroy(this.gameObject, 0);
        }
    }

    IEnumerator WaitInTime(float valTime)
    {
        yield return new WaitForSeconds(valTime);
    }
}
