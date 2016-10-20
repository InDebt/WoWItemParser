namespace WowItemParser.Internal.SpellSystem.SpellHandler
{
    internal class ModDamageSpellEffectHandler : ISpellEffectHandler
    {
        public bool CanHandleSpell(SpellEffectRecord record)
        {
            return record.Effect == SpellEffects.SpellEffectApplyAura
                   && record.AuraType == AuraType.SPELL_AURA_MOD_DAMAGE_DONE
                   && (record.SpellSchool & SpellSchoolMask.SpellSchoolMaskMagic) > 0;
        }

        public void ApplySpellEffect(SpellEffectRecord record, ref StatInfo item)
        {
            var spellDamage = record.BaseDice + record.BasePoints;
            switch (record.SpellSchool)
            {
                case SpellSchoolMask.SpellSchoolMaskArcane:
                    item.SpellArcaneDamage += spellDamage;
                    break;
                case SpellSchoolMask.SpellSchoolMaskFire:
                    item.SpellFireDamage += spellDamage;
                    break;
                case SpellSchoolMask.SpellSchoolMaskFrost:
                    item.SpellFrostDamage += spellDamage;
                    break;
                case SpellSchoolMask.SpellSchoolMaskHoly:
                    item.SpellHolyDamage += spellDamage;
                    break;
                case SpellSchoolMask.SpellSchoolMaskNature:
                    item.SpellNatureDamage += spellDamage;
                    break;
                case SpellSchoolMask.SpellSchoolMaskShadow:
                    item.SpellShadowDamage += spellDamage;
                    break;
                case SpellSchoolMask.SpellSchoolMaskMagic:
                    item.SpellDamage += spellDamage;
                    break;
            }
        }
    }
}