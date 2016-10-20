namespace WowItemParser.Internal.SpellSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WowItemParser.Internal.DBC;
    using WowItemParser.Internal.SpellSystem.SpellHandler;

    /// <summary>
    ///     Loads and holds the spell.dbc
    /// </summary>
    internal class SpellMgr
    {
        private static readonly Lazy<SpellMgr> Inst = new Lazy<SpellMgr>(() => new SpellMgr());

        private readonly DbcFile spellDbc;

        private readonly List<ISpellEffectHandler> spellHandler = new List<ISpellEffectHandler>();

        private SpellMgr()
        {
            // add spellhandler here
            this.spellHandler.Add(new ModAttackPowerSpellEffectHandler());
            this.spellHandler.Add(new ModDamageSpellEffectHandler());
            this.spellHandler.Add(new ModHealSpellEffectHandler());
            this.spellHandler.Add(new ModTargetResistenceSpellEffectHandler());
            this.spellHandler.Add(new ModPowerRegenSpellEffectHandlercs());

            // load dbc file
            this.spellDbc = new DbcFile("Spell.dbc");
        }

        public static SpellMgr Instance
        {
            get
            {
                return Inst.Value;
            }
        }

        /// <summary>
        ///     Applies the spell with the given entry to the current item.
        /// </summary>
        /// <param name="spellEntry">The spell entry.</param>
        /// <param name="item">The item.</param>
        public void ApplyItemSpell(int spellEntry, StatInfo item)
        {
            if (spellEntry != 0)
            {
                var record = new SpellRecord(this.spellDbc.Records[spellEntry], this.spellDbc);
                foreach (var effect in record.SpellEffects)
                {
                    this.ApplySpellEffect(effect, ref item);
                }
            }
        }

        private void ApplySpellEffect(SpellEffectRecord effect, ref StatInfo item)
        {
            foreach (var handler in this.spellHandler.Where(handler => handler.CanHandleSpell(effect)))
            {
                handler.ApplySpellEffect(effect, ref item);
                break;
            }
        }
    }

    internal enum SpellDbcFieldOffsets
    {
        SpellPowerType = 35,

        SpellEffect = 65,

        SepllDiceSides = 68,

        SpellBaseDice = 71,

        SpellBasePoints = 80,

        SpellAuraEffect = 95,

        SpellMiscValue = 110,

        SpellName = 130
    }
}