namespace WowItemParser.Internal.SpellSystem.SpellHandler
{
    using System;

    internal class ModTargetResistenceSpellEffectHandler : ISpellEffectHandler
    {
        public bool CanHandleSpell(SpellEffectRecord record)
        {
            if (record.Effect == SpellEffects.SpellEffectApplyAura)
            {
                if (record.AuraType == AuraType.SPELL_AURA_MOD_TARGET_RESISTANCE)
                {
                    if (record.SpellSchool == SpellSchoolMask.SpellSchoolMaskNormal) // currently only suppot arp aura
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void ApplySpellEffect(SpellEffectRecord record, ref StatInfo item)
        {
            item.ArmorPenetration += Math.Abs(record.BasePoints + record.BaseDice);
        }
    }
}