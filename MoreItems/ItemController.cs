using ModdingAPI;
using MoreItems.AmanecidaQuest;
using MoreItems.ChargeTimeDecrease;
using MoreItems.DamageRemovalOnce;
using MoreItems.GuiltFragmentBonus;

namespace MoreItems
{
    public class ItemController : Mod
    {
        public ItemController(string modId, string modName, string modVersion) : base(modId, modName, modVersion) { }

        protected override void Initialize()
        {
            RegisterItem(new ChargeTimeBead().AddEffect<ChargeTimeEffect>()); // RB501
            RegisterItem(new GuiltFragmentBead().AddEffect<GuiltFragmentEffect>()); // RB502
            RegisterItem(new DamageRemovalBead().AddEffect<DamageRemovalEffect>()); // RB503

            RegisterItem(new AmanecidaCoreHeart().AddEffect<AmanecidaCoreEffect>()); // HE501
        }

        protected override void LevelLoaded(string oldLevel, string newLevel)
        {
            if (newLevel == "MainMenu")
            {
                Log("RB503: Regain damage removal (mainmenu)");
                DamageRemovalEffect.RegainDamageRemoval();
            }
        }
    }
}
