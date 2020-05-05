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
   

    // Initialize weapon system
    // public static string[] weaponNames = new string[] {"missile", "orb", "lazer", "mine", "blackholemaker"};
    public static string[] weaponNames = new string[] {"lazer", "missile", "orb", "mine", "blackhole"};
    public static int numOfWeapons = weaponNames.Length;
    private static int curWeaponIndex = 0;
    public static string curWeaponName = weaponNames[curWeaponIndex];
    public Dictionary<string, int> weapons = new Dictionary<string, int>();
    public Dictionary<string, Sprite> spriteList = new Dictionary<string, Sprite>();
    public Image weaponImage;
    public Text curWeaponCount;

    // Sprites of the weapons
    public Sprite missileSprite;
    public Sprite orbSprite;
    public Sprite mineSprite;
    public Sprite lazerSprite;
    public Sprite blackHoleSprite;

    // Weapon prefabs
    public GameObject lazerPrefab;
    private float bulletForce = 8f;

    public Transform firepoint;
    public GameObject missilePrefab;


    // Animations of the collectibles


    // Hit effects of the weapons


    // Start is called before the first frame update
    void Start()
    {
        // weaponImage.sprite = spriteList[curWeaponName];
        weapons["missile"] = 100;
        weapons["orb"] = 0;
        weapons["lazer"] = 12;
        weapons["mine"] = 0;
        weapons["blackhole"] = 0;
        

        spriteList["orb"] = orbSprite;
        spriteList["missile"] = missileSprite;
        spriteList["lazer"] = lazerSprite;
        spriteList["mine"] = mineSprite;
        spriteList["blackhole"] = blackHoleSprite;
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
            if(curWeaponName != "lazer")
                curWeaponCount.text = count.ToString();
            else
                curWeaponCount.text = "ꝏ";
                            
        }

        // Keep updating the count

        if(curWeaponName != "lazer")
            curWeaponCount.text = weapons[curWeaponName].ToString();
        else
            curWeaponCount.text = "ꝏ";

        // Firing mechanism and count of weapons handling
        if(Input.GetButtonDown("Fire1") && weapons[curWeaponName] > 0)
        {       
            if(curWeaponName != "lazer")
            {
                    weapons[curWeaponName] -= 1;
            }
            shoot(curWeaponName);
        }

    }


    public void shoot(string weaponName)
    {
        if(weaponName == "lazer")
        {
            GameObject bullet = Instantiate(lazerPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce,ForceMode2D.Impulse);
            Destroy(bullet,2f);

        }

        else if(weaponName == "missile")
        {
            GameObject myMissile = Instantiate(missilePrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = myMissile.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * 2f,ForceMode2D.Impulse);

        }
    }


    // Manage Collectibles and collision damage
    void OnCollisionEnter2D(Collision2D collision)
    {

        // MANAGE DAMAGE BY OVER SPEEDING AND HITTING


        // MANAGE COLLECTIBLES
        if(collision.gameObject.tag == "fuel")
        {
            // write code for refueling here
        }

        else if(collision.gameObject.tag == "healthpowerup")
        {
            // Destroy the collectible
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "orbofosuvoxpowerup")
        {
            // Destroy the collectible
            Destroy(collision.gameObject);

            // Add in the arsenal
            weapons["orb"] += 1;
        }

        else if(collision.gameObject.tag == "missilepowerup")
        {
            // Destroy the collectible
            Destroy(collision.gameObject);

            // Add in the arsenal
            weapons["missile"] += 1;
        }

        else if(collision.gameObject.tag == "minepowerup")
        {
            // Destroy the shield collectible
            Destroy(collision.gameObject);

            // Add in the arsenal
            weapons["mine"] += 1;
        }

        else if(collision.gameObject.tag == "blackholepowerup")
        {
            // Destroy the shield collectible
            Destroy(collision.gameObject);

            // Add in the arsenal
            weapons["blackhole"] += 1;
        }



    }
}
