using System.Collections.Generic;
using Project.Scripts.Game.Areas.Bonus.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.BonusesShop.View
{
    public class BonusesShopView : MonoBehaviour, IBonusesShopView
    {
        [SerializeField] private GameObject _shopMenu;
        [SerializeField] private GameObject _shopMenuOpener;
        [SerializeField] private GameObject _bonuses;
        [SerializeField] private BonusView _bonusPrefab;

        public IDictionary<string, IBonusView> CollectionOfBonuses { get; set; }

        public void OpenShopMenu()
        {
            _shopMenu.SetActive(true);
            _shopMenuOpener.SetActive(false);
        }

        public void CloseShopMenu()
        {
            _shopMenu.SetActive(false);
            _shopMenuOpener.SetActive(true);
        }

        public IBonusView CreateBonusView()
        {
            var bonusView = Instantiate(_bonusPrefab, _bonuses.transform, true);
            return bonusView;
        }
    }
}