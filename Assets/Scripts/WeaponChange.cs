
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public int selectedWeapon = 0;
    public GameObject colliderAttack;



    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetButtonDown("Fire1"))
        {
            selectedWeapon = 0;
            colliderAttack.layer = LayerMask.NameToLayer("Chainsaw");
        }

        if (Input.GetButtonDown("Fire2") && transform.childCount >= 2)
        {
            selectedWeapon = 1;
            colliderAttack.layer = LayerMask.NameToLayer("Katana");
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
