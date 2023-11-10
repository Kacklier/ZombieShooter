using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    void Start() {
        this.weaponName = "Shotgun";
        this.hasInfiniteAmmo = false;
        this.ammoCount = 20;
        this.fireRate = 1f;
        this.clipSize = 5;
        this.clipCount = this.clipSize;
    }
    
    public override void Fire(Transform player)
    {
        float currentTime = Time.time;
        if (currentTime - this.lastFireTime >= this.fireRate)
        {
            this.lastFireTime = currentTime;
            if (this.clipCount > 0) {
                this.ChangeGunSpriteToFire();

                GameObject bullet = Instantiate(bulletType, player.position, player.rotation);
                Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), player.GetComponent<CircleCollider2D>());
                Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
                bulletBody.velocity = bulletBody.transform.up * 40;

            if (this.hasInfiniteAmmo){
                this.clipCount -= 1;
            }

            if (!this.hasInfiniteAmmo && this.ammoCount > 0 && this.clipCount > 0) {
                this.ammoCount -= 1;
                this.clipCount -= 1;
                }
            }
        }
    }

    public override void ChangeGunSpriteToFire(){
        gameObject.GetComponent<SpriteRenderer>().sprite = gunFireSprite;
    }

    public override void ChangeGunSpriteToIdle(){
        gameObject.GetComponent<SpriteRenderer>().sprite = gunSprite;
    }

}

