//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

//public class StandardBullet : AbstractBulletClass
//{
//    private void Awake()
//    {
//        _damage = 1f;
//        _lifetime = 5f;
//        _speed= 1f;
//    }
//    private void Start()
//    {
//        // јвтоматически уничтожаем снар€д через lifetime секунд
//        Destroy(gameObject, _lifetime);
//    }

//    private void Update()
//    {
//        // ƒвигаем снар€д вперед (в локальном направлении X)
//        transform.Translate(Vector2.right * _speed * Time.deltaTime);
//    }

//    // ”станавливаем ссылку на танк-стрелка
//    public override void SetShooter(StandardTank tank)
//    {
//        _owner = tank;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        // ≈сли снар€д столкнулс€ с землей (например, объект имеет тег "Ground")
//        if (collision.gameObject.CompareTag("f"))
//        {
//            Destroy(gameObject);
//        }
//        else
//        {
//            // ћожно добавить логику попадани€ по цели (например, если цель имеет компонент APlayer)
//            AbstractBulletClass target = collision.gameObject.GetComponent<AbstractBulletClass>();
//            if (target != null)
//            {
//                target.TakeDamage(damage);
//                Destroy(gameObject);
//            }
//        }
//    }

//    private void OnDestroy()
//    {
//        // ≈сли ссылка на танк установлена, уведомл€ем его о том, что снар€д уничтожен
//        if (_owner != null)
//        {
//            _owner.OnProjectileDestroyed();
//        }
//    }
//}
