namespace WowItemParser.Internal.SpellSystem.SpellHandler
{
    internal class ModHealSpellEffectHandler : ISpellEffectHandler
    {
        public bool CanHandleSpell(SpellEffectRecord record)
        {
            return record.Effect == SpellEffects.SpellEffectApplyAura
                   && record.AuraType == AuraType.SPELL_AURA_MOD_HEALING_DONE
                   && record.SpellSchool == SpellSchoolMask.SpellSchoolMaskMagic;
        }

        public void ApplySpellEffect(SpellEffectRecord record, ref StatInfo item)
        {
            item.AddHeal += record.BaseDice + record.BasePoints;
        }
    }
}