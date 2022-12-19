using Project.Scripts.Game.Areas.Bonus.View;
using UnityEngine;

namespace Project.Scripts.Game.Areas.BonusesShop.View
{
    public class BonusesShopView : MonoBehaviour, IBonusesShopView
    {
        [SerializeField] private GameObject _shopMenu;
        [SerializeField] private GameObject _shopMenuOpener;
        [SerializeField] private BonusView _swordBonus;

        public IBonusView Sword => _swordBonus;

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
    }
}