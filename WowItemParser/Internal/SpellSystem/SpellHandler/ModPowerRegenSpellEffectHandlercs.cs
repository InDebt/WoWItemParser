namespace WowItemParser.Internal.SpellSystem.SpellHandler
{
    internal class ModPowerRegenSpellEffectHandlercs : ISpellEffectHandler
    {
        public bool CanHandleSpell(SpellEffectRecord record)
        {
            if (record.Effect == SpellEffects.SpellEffectApplyAura
                && record.AuraType == AuraType.SPELL_AURA_MOD_POWER_REGEN)
            {
                if (record.PowerType == Powers.POWER_MANA)
                {
                    return true;
                }
            }

            return false;
        }

        public void ApplySpellEffect(SpellEffectRecord record, ref StatInfo item)
        {
            item.ManaPer5 += record.BaseDice + record.BasePoints;
        }
    }
}