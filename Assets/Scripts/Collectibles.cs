using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{

    [HideInInspector]
    public GameObject shield;

    //Inspector variables
    public GameObject shieldPrefab;
   
    [HideInInspector]
    public float shieldLife = 0f;

    // Initialize weapon system
    public static string[] weaponNames = new string[] {"missile", "orb"};
    public static int numOfWeapons = weaponNames.Length;
    private static int curWeaponIndex = 0;
    public string curWeaponName = weaponNames[curWeaponIndex];
    public Dictionary<string, int> weapons = new Dictionary<string, int>();
    public Dictionary<string, Sprite> spriteList = new Dictionary<string, Sprite>();
    public Image weaponImage;
    public Text curWeaponCount;

    public Sprite missileSprite;
    public Sprite orbSprite;

    // Start is called before the first frame update
    void Start()
    {
        weapons["orb"] = 0;
        weapons["missile"] = 0;

        spriteList["orb"] = orbSprite;
        spriteList["missile"] = missileSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            curWeaponIndex = (curWeaponIndex + 1) % numOfWeapons;

            // Fetch new count and new image
            curWeaponName = weaponNames[curWeaponIndex];
            int count = weapons[curWeaponName];
            weaponImage.sprite = spriteList[curWeaponName];
            curWeaponCount.text = count.ToString();
        }

        curWeaponCount.text = weapons[curWeaponName].ToString();

    }


    // Manage Collectibles and collision damage
    void OnCollisionEnter2D(Collision2D collision)
    {

        // MANAGE DAMAGE BY OVER SPEEDING AND HITTING


        // MANAGE COLLECTIBLES
        if(collision.gameObject.tag == "shieldpowerup")
        {   
            // Destroy the shield collectible
            Destroy(collision.gameObject);

            //Instantiate the shield prefab and assign spaceship as parent
            shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            shield.transform.parent = gameObject.transform;

            shieldLife = 50f;
            Debug.Log(shieldLife);
        }

        else if(collision.gameObject.tag == "fuel")
        {
            // write code for refueling here
        }

        else if(collision.gameObject.tag == "healthpowerup")
        {
            // Destroy the shield collectible
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "orbofosuvoxpowerup")
        {
            // Destroy the shield collectible
            Destroy(collision.gameObject);

            // Add in the arsenal
            weapons["orb"] += 1;
        }

        else if(collision.gameObject.tag == "missilepowerup")
        {
            // Destroy the shield collectible
            Destroy(collision.gameObject);

            // Add in the arsenal
            weapons["missile"] += 1;
        }

    }
}
