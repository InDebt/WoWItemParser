namespace WowItemParser.Internal.GemSystem
{
    using System;

    using WowItemParser.Internal.DBC;
    using WowItemParser.Internal.SpellSystem;

    internal class GemMgr
    {
        private static readonly Lazy<GemMgr> Ins = new Lazy<GemMgr>(() => new GemMgr());

        private readonly DbcFile enchantFile;

        private GemMgr()
        {
            this.enchantFile = new DbcFile("SpellItemEnchantment.dbc");
        }

        public static GemMgr Instance
        {
            get
            {
                return Ins.Value;
            }
        }

        public void ApplySocketBonus(int entry, StatInfo info)
        {
            if (entry != 0)
            {
                var values = this.enchantFile.Records[entry];
                var type = (ItemEnchantmentType)values[(int)SpellItemEnchantDbcOffsets.EffectType];

                // only parse those two types here, we won't have combat spell like gem bonuses and resistence socket bonuses are not supportet if there are any?e
                switch (type)
                {
                    case ItemEnchantmentType.ItemEnchantmentTypeEquipSpell:
                        SpellMgr.Instance.ApplyItemSpell(values[(int)SpellItemEnchantDbcOffsets.SpellId], info);
                        break;
                    case ItemEnchantmentType.ItemEnchantmentTypeStat:
                        info.ParseBaseAttribute(
                            values[(int)SpellItemEnchantDbcOffsets.SpellId],
                            values[(int)SpellItemEnchantDbcOffsets.Amount]);
                        break;
                }
            }
        }
    }

    internal enum SpellItemEnchantDbcOffsets
    {
        EffectType = 1,

        Amount = 4,

        SpellId = 10
    }

    internal enum ItemEnchantmentType
    {
        ItemEnchantmentTypeNone = 0,

        ItemEnchantmentTypeCombatSpell = 1,

        ItemEnchantmentTypeDamage = 2,

        ItemEnchantmentTypeEquipSpell = 3,

        ItemEnchantmentTypeResistance = 4,

        ItemEnchantmentTypeStat = 5,

        ItemEnchantmentTypeTotem = 6
    };
}