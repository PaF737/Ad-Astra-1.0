using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private BonusGenerator _bonusGenerator;

    private LevelData _level;
    private int _indexWave;
    private int _indexEnemy;

    private List<GameObject> _enemies = new List<GameObject>();

    public void Generate()
    {
        int offset = 1;
        Vector2 startPosition = new Vector2(0, new SafeAreaDATA().GetMax().y + offset);
        foreach (var wave in _level.waves)
        {
            for (int i = 0; i < wave.CountInWave; i++)
            {
                var enemy = Instantiate(wave.EnemyPrefab, transform);

                if (enemy.TryGetComponent(out EnemyBonusDrop enemyBonusDrop))
                {
                    if(_bonusGenerator.TryGetBonus(out BaseBonus bonus))
                    {
                        enemyBonusDrop.SetBonus(bonus);
                    }
                }

                enemy.transform.position = startPosition;
                enemy.SetActive(false);
                _enemies.Add(enemy);
            }
        }
    }

    private void Awake()
    {
        int index = LevelSaveData.GetLevelIndex();
        _level = Resources.Load<LevelData>($"Levels/Level{index}");
    }

    public void Activate()
    {
        StartCoroutine(EnemyActivate());
    }

    private IEnumerator EnemyActivate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        var count = _level.waves[_indexWave].CountInWave;
        while (count > 0)
        {
            count--;
            _enemies[_indexEnemy].gameObject.SetActive(true);
            _indexEnemy++;

            yield return wait;
        }
        if (_indexWave < _level.waves.Count)
        {
            Invoke(nameof(Activate), _level.waves[_indexWave].WaitAfterWave);
            _indexWave++;
        }
    }
}
