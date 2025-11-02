using StarterAssets;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Windows;

public class WeaponGun : MonoBehaviour
{

    [Header("Weapon Data")]
    [SerializeField] private int ammo = 8;
    [SerializeField] private int maxAmmo = 32;

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
    }
    private void FireWeapon()
    {
        if (Time.time >= lastFire + fireCooldown)
        {
            Vector3 spawnPosition = barrel.transform.position;
            Quaternion spawnRotation = barrel.transform.rotation;
            Instantiate(projectilePrefab, spawnPosition, spawnRotation);
            lastFire = Time.time;
        }
    }
}
