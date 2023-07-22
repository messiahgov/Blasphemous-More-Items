using ModdingAPI;
using MoreItems.ChargeTimeDecrease;
using MoreItems.GuiltFragmentBonus;

namespace MoreItems
{
    public class ItemController : Mod
    {
        public ItemController(string modId, string modName, string modVersion) : base(modId, modName, modVersion) { }

        protected override void Initialize()
        {
            RegisterItem(new ChargeTimeBead().AddEffect<ChargeTimeEffect>());
            RegisterItem(new GuiltFragmentBead().AddEffect<GuiltFragmentEffect>());
        }
    }
}
