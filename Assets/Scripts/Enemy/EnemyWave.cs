using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private BonusGenerator _bonusGenerator;
    [SerializeField] private Camera _camera;

    private LevelData _level;
    private int _indexWave;
    private int _indexEnemy;

    private float _maxY => _camera.ScreenToWorldPoint(Screen.safeArea.max).y;

    private List<Enemy> _enemies = new List<Enemy>();

    public void Generate()
    {
        int offset = 1;
        Vector2 startPosition = new Vector2(0, _maxY + offset);
        foreach (var wave in _level.waves)
        {
            for (int i = 0; i < wave.CountInWave; i++)
            {
                var enemy = Instantiate(wave.EnemyPrefab, transform);

                if (enemy.TryGetComponent(out EnemyBonusDrop enemyBonusDrop))
                {
                    if (_bonusGenerator.TryGetBonus(out BaseBonus bonus))
                    {
                        enemyBonusDrop.SetBonus(bonus);
                    }
                }

                enemy.transform.position = startPosition;
                enemy.Deactivate();
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
        while (_indexWave < _level.waves.Count)
        {
            var wave = _level.waves[_indexWave];

            WaitForSeconds wait = new WaitForSeconds(wave.SpawnCD);
            var count = wave.CountInWave;
            while (count > 0)
            {
                count--;
                _enemies[_indexEnemy].Activate();
                _indexEnemy++;

                yield return wait;
            }
            
            if (_indexWave < _level.waves.Count)
            {
                _indexWave++;
                yield return new WaitForSeconds(wave.WaitAfterWave);
            }
        }
    }
}
