using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private BonusQueue _bonusQueue;
    [SerializeField] private GameBonuseDataSO _gameBonusData;

    private List<int> _bonusChance = new List<int>();
    private int _maxChance;

    private void Awake()
    {
        Calculate();
    }

    private void Calculate()
    {
        for (int i = 0; i < _gameBonusData.Bonuses.Count; i++)
        {
            _maxChance += _gameBonusData.Bonuses[i].Weight;
            _bonusChance.Add(_maxChance);
        }

        _bonusChance.Add(_maxChance * 3);
    }

    public bool TryGetBonus()
    {
        int chance = UnityEngine.Random.Range(0, _bonusChance[_bonusChance.Count - 1]);
        bool yesChance = false;

        if (chance < _maxChance)
        {
            int min = 0;
            for (int i = 0; i < _bonusChance.Count -1; i++)
            {
                if (chance >= min && chance < _bonusChance[i])
                {
                    Generate(_gameBonusData.Bonuses[i].gameObject);
                    yesChance = true;
                    break;
                }

                min = _bonusChance[i];
            }
        }

        return yesChance;
    }

    private void Generate(GameObject bonusPrefab)
    {
        GameObject bonus = Instantiate(bonusPrefab, _bonusQueue.transform);
        bonus.SetActive(false);
        _bonusQueue.AddObject(bonus);
    }
}
