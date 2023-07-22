using ModdingAPI.Items;
using UnityEngine;

namespace MoreItems.ChargeTimeDecrease
{
    class ChargeTimeBead : ModRosaryBead
    {
        protected override string Id => "RB501";

        protected override string Name => "Shard of an Executioner's Axe";

        protected override string Description => "A small rusted piece of an executioner's axe. Significantly decreases the charge up time of the charged attack.";

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

    class ChargeTimeEffect : ModItemEffectOnEquip
    {
        public static bool Active { get; private set; }

        protected override void ApplyEffect() => Active = true;

        protected override void RemoveEffect() => Active = false;
    }
}
