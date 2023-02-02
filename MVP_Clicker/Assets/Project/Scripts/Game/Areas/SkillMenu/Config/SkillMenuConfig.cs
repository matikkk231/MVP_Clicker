using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Game.Areas.Skill.Config;
using UnityEngine;

namespace Project.Scripts.Game.Areas.SkillMenu.Config
{
    [CreateAssetMenu(fileName = "newCollectionOfSkills", menuName = "ScriptableObjects/SkillCollection")]
    public class SkillMenuConfig : ScriptableObject, ISkillMenuConfig
    {
        [SerializeField] private List<SkillConfig> _collection;

        public Dictionary<string, ISkillConfig> Collection
        {
            get { return _collection.ToDictionary(k => (string)k.Id, v => (ISkillConfig)v); }
        }
    }
}