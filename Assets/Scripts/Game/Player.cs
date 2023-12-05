using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Transform BoxParent, ShootPoint;
    public List<GameObject> nearbyBox = new List<GameObject>();
    public Vector3 boxPos;
    public Box box1;
    Player character;
    public int indexMage;
    public float StartPosY;
    Plane plane = new Plane(Vector3.up, Vector3.zero);

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        BoxParent = GameObject.Find("BoxParent").transform;
        StartPosY = transform.position.y;
        Invoke("AniIsAttack", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        nearbyBox.Clear();
        for (int i = 0; i < BoxParent.childCount; i++)
        {
            Box box = BoxParent.GetChild(i).gameObject.GetComponent<Box>();
            float distance = Vector3.Distance(BoxParent.GetChild(i).transform.position, transform.position);
            if (distance < 1 && box.isCheckBox == false)
            {
                nearbyBox.Add(BoxParent.GetChild(i).gameObject);
            }
        }
        GameObject nearestBox = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject box in nearbyBox)
        {
            float distance = Vector3.Distance(box.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestBox = box;
            }
        }
        if (nearestBox != null)
        {
            // Debug.Log("Nearest box is " + nearestBox.name);
            Box box = nearestBox.GetComponent<Box>();
            for (int i = 0; i < BoxParent.childCount; i++)
            {
                if (box.transform.position == BoxParent.GetChild(i).transform.position)
                {
                    box.checkSpriteRenderer(true);
                    boxPos = box.transform.position;
                    box1 = box;
                }
            }
        }
    }

    Vector3 offsetPos;
    void OnMouseDown()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float ent = 100f;
        if (plane.Raycast(ray, out ent))
        {
            var hitPoint = ray.GetPoint(ent);

            offsetPos = transform.position - hitPoint;
        }
    }

    private void OnMouseDrag()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float ent = 100f;
        if (plane.Raycast(ray, out ent))
        {
            var hitPoint = ray.GetPoint(ent);

            transform.position = hitPoint + offsetPos;
        }
        /*   Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
          Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
          transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z); */
        if (box1 != null)
        {
            box1.checkSpriteRenderer(false);
        }
        // transform.SetParent(GameObject.Find("OnMouseMage").transform);
        transform.tag = "OnMage";
        AniIsIdle();
    }

    private void OnMouseUp()
    {
        if (character != null)
        {
            character.box1.checkSpriteRenderer(false);
            box1.checkSpriteRenderer(false);
            if (indexMage == character.indexMage)
            {
                Game.game.UpdateMageLevelUp(character.transform.position, indexMage);
                Game.game.ShowEffect(character.transform, 0);
                Destroy(character.gameObject);
                Destroy(gameObject);
            }
            else if (indexMage != character.indexMage)
            {
                transform.tag = "Character";
                transform.position = new Vector3(boxPos.x, StartPosY, boxPos.z);
                // transform.SetParent(GameObject.Find("MageParent").transform);
                character = null;
            }
        }
        else if (character == null)
        {
            transform.tag = "Character";
            transform.position = new Vector3(boxPos.x, StartPosY, boxPos.z);
            // transform.SetParent(GameObject.Find("MageParent").transform);
        }
        AniIsAttack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            character = other.gameObject.GetComponent<Player>();
            character.AniIsIdle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            character = other.gameObject.GetComponent<Player>();
            character.AniIsAttack();
            character = null;
        }
    }

    public void Shoot()
    {
        Game.game.ShowBullet(ShootPoint, indexMage);
    }

    public void AniIsIdle()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsAttack", false);
    }

    public void AniIsAttack()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsAttack", true);
        animator.speed = 1;
    }
}
