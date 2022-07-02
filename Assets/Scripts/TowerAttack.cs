using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float attackRange = 40f;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackOnEnemy());
    }

    private IEnumerator AttackOnEnemy()
    {
        while (true)
        {
            GameObject enemy = FindEnemyNearby();
            if (enemy != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, new Vector3(0,5,10), Quaternion.identity);
                Debug.Log("instantiate object");
                bullet.GetComponent<BulletMovement>().Initialize(enemy);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }
        }
    }

    private GameObject FindEnemyNearby()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);
        if (hitEnemies.Length > 0)
        {
            return hitEnemies[0].gameObject;
        }

        return null;
    }
}
