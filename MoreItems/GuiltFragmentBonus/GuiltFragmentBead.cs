using ModdingAPI.Items;
using UnityEngine;

namespace MoreItems.GuiltFragmentBonus
{
    class GuiltFragmentBead : ModRosaryBead
    {
        protected override string Id => "RB502";

        protected override string Name => "Miniature Bloody Helmet";

        protected override string Description => "This old worn helmet is caked in dried blood and ashes. It feels bizarrely familiar somehow. Increases the benefits of picking up your guilt fragments.";

        protected override string Lore => "Lore";

        protected override bool CarryOnStart => false;

        protected override bool PreserveInNGPlus => true;

        protected override bool AddToPercentCompletion => true;

        protected override bool AddInventorySlot => true;

        protected override void LoadImages(out Sprite picture)
        {
            picture = null;
        }
    }

    class GuiltFragmentEffect : ModItemEffectOnEquip
    {
        public static bool Active { get; private set; }

        protected override void ApplyEffect() => Active = true;

        protected override void RemoveEffect() => Active = false;
    }
}
