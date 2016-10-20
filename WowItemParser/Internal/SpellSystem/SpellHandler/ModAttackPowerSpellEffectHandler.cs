namespace WowItemParser.Internal.SpellSystem.SpellHandler
{
    internal class ModAttackPowerSpellEffectHandler : ISpellEffectHandler
    {
        public bool CanHandleSpell(SpellEffectRecord record)
        {
            return record.Effect == SpellEffects.SpellEffectApplyAura
                   && (record.AuraType == AuraType.SPELL_AURA_MOD_ATTACK_POWER
                       || record.AuraType == AuraType.SPELL_AURA_MOD_RANGED_ATTACK_POWER);
        }

        public void ApplySpellEffect(SpellEffectRecord record, ref StatInfo item)
        {
            switch (record.AuraType)
            {
                case AuraType.SPELL_AURA_MOD_ATTACK_POWER:
                    item.Attackpower += record.BaseDice + record.BasePoints;
                    break;
                case AuraType.SPELL_AURA_MOD_RANGED_ATTACK_POWER:
                    item.RangedAttackpower += record.BaseDice + record.BasePoints;
                    break;
            }
        }
    }
}