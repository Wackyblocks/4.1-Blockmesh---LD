using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Windows;

public class WeaponGun : MonoBehaviour
{

    [Header("Weapon Data")]
    [SerializeField] public int ammo = 12;
    [SerializeField] private int maxAmmo = 32;
    [SerializeField] private TMP_Text ammoCount;

    [Header("Aiming")]
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireCooldown = 0.5f;

    //inputs
    private StarterAssetsInputs inputs;

    //weapon
    private float lastFire = 0f;
    //Fire weapon

    private void Start()
    {
        inputs = Object.FindFirstObjectByType<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (inputs != null && inputs.fire)
        {
            FireWeapon();
        }
        // Consume input
        inputs.fire = false;

        //update ammo text field
        ammoCount.text = $"Ammo: {ammo}";
    }
    private void FireWeapon()
    {
        if (Time.time >= lastFire + fireCooldown && ammo > 0)
        {
            Vector3 spawnPosition = barrel.transform.position;
            Quaternion spawnRotation = barrel.transform.rotation;
            Instantiate(projectilePrefab, spawnPosition, spawnRotation);
            ammo --;
            ammoCount.text = $"Ammo: {ammo}";
            lastFire = Time.time;
        }
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        Debug.Log("ammo added");
    }
}
