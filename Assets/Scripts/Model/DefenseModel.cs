using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefanse
{
    public class DefenseModel : MonoBehaviour, iDefense, iSelectable
    {
        [SerializeField] private string _nameDefense = "MachineGunTurret"; //имя башни
        [SerializeField] private Transform _startFirePosition;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _timeShots = 1f; //время между выстрелами
        [SerializeField] private int _shotPower = 1; //сила выстрела
        [SerializeField] private float _shotRange = 5f; //дальность выстрале и дальность нахождения цели


        public int PriceInstantiate = 100;

        private bool _enableClick = true;



        //private List<iTarget> _enemy = null;
        private Dictionary<int, iTarget> _enemy = null;
        private List<int> _numsEnemy = new List<int>();
        private bool _flag = true;
        private iSelectable _selec;

        public string NameDefense => _nameDefense; //имя врага
        public Transform TransformDefense => transform;

        public bool EnableClick { get => _enableClick; set => _enableClick = value; }
        public Transform Position => transform;
        public string Name => _nameDefense;
        public GameObject Obj => gameObject;

        private void Start()
        {
            _enemy = new Dictionary<int, iTarget>();
            _selec = GetComponent<iSelectable>();
        }

        private void FindNearestEnemy()
        {
            for (int i = 0; i < GameProfile.Enemys.Count; i++)
            {
                if (Vector3.Distance(transform.position, GameProfile.Enemys[i].TargetTransform.position) <= _shotRange)
                {
                    if (!_enemy.ContainsKey(i))
                    { 
                        _enemy.Add(i, GameProfile.Enemys[i]);
                        _numsEnemy.Add(i);
                    }
                }
            }

            if(_enemy.Count > 0)
            {
                foreach (var ene in _enemy)
                {
                    if (Vector3.Distance(transform.position, ene.Value.TargetTransform.position) > _shotRange)
                    {
                        _numsEnemy.Remove(ene.Key);
                        _enemy.Remove(ene.Key);
                        return;
                    }
                    if(ene.Value.Hp <= 0)
                    {
                        _numsEnemy.Remove(ene.Key);
                        _enemy.Remove(ene.Key);
                        return;
                    }
                }
            }
        }

        private void LookAt()
        {
            if (_enemy.Count > 0)
            {
                transform.LookAt(new Vector3(_enemy[_numsEnemy[0]].TargetTransform.position.x, 1.33f, _enemy[_numsEnemy[0]].TargetTransform.position.z), Vector3.up);
            }
            else
            {
                //transform.LookAt(transform.forward);
                transform.rotation = Quaternion.identity;
            }

        }

        private IEnumerator Fire()
        {
            while (_enemy.Count > 0)
            {
                var bullet = Instantiate(_bullet, _startFirePosition.position, transform.rotation).GetComponent<IAmmunition>();  //откорректировать
                bullet.ShotPower = _shotPower;
                bullet.Target = _enemy[_numsEnemy[0]];
                
                yield return new WaitForSeconds(_timeShots);
            }

            _flag = true;
        }

        

        private void Update()
        {
            FindNearestEnemy();

            LookAt();

            if (_enemy.Count > 0 && _flag)
            {
                _flag = false;
                StartCoroutine(Fire());
            }
        }

        public iSelectable Selected()
        {
            return _selec;
        }
    }
}


