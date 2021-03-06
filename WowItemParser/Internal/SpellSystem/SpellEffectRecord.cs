﻿// This source is for use by Netfira developers or development partners only.
// 
// File: SpellEffectRecord.cs
// Date: 2015-11-18

namespace WowItemParser.Internal.SpellSystem
{
    using System;
    using System.Security.Policy;

    internal class SpellEffectRecord
    {
        public SpellEffectRecord(int[] record, int effectNumber)
        {
            this.Effect = (SpellEffects)record[(int)SpellDbcFieldOffsets.SpellEffect + effectNumber];
            this.AuraType = (AuraType)record[(int)SpellDbcFieldOffsets.SpellAuraEffect + effectNumber];
            this.BaseDice = record[(int)SpellDbcFieldOffsets.SpellBaseDice + effectNumber];
            this.BasePoints = record[(int)SpellDbcFieldOffsets.SpellBasePoints + effectNumber];
            this.SpellSchool = (SpellSchoolMask)record[(int)SpellDbcFieldOffsets.SpellMiscValue + effectNumber];
            this.PowerType = (Powers)record[(int)SpellDbcFieldOffsets.SpellPowerType];
        }

        public SpellEffects Effect { get; private set; }

        /// <summary>
        /// Gets the base points.
        /// Absolute base points can be computed by the sum of
        /// BasePoints + Random(BaseDice, BaseDice + DiceSidces - 1)
        /// </summary>
        /// <value>
        /// The base points.
        /// </value>
        public int BasePoints { get; private set; }

        public int BaseDice { get; private set; }

        public int DiceSides { get; private set; }

        public SpellSchoolMask SpellSchool { get; private set; }

        public AuraType AuraType { get; private set; }

        public Powers PowerType { get; private set; }
    
    }

    internal enum SpellSchools
    {
        SpellSchoolNormal = 0, //< Physical, Armor

        SpellSchoolHoly = 1,

        SpellSchoolFire = 2,

        SpellSchoolNature = 3,

        SpellSchoolFrost = 4,

        SpellSchoolShadow = 5,

        SpellSchoolArcane = 6
    };

    [Flags]
    internal enum SpellSchoolMask
    {
        SpellSchoolMaskNone = 0x00, // not exist

        SpellSchoolMaskNormal = (1 << SpellSchools.SpellSchoolNormal), // PHYSICAL (Armor)

        SpellSchoolMaskHoly = (1 << SpellSchools.SpellSchoolHoly),

        SpellSchoolMaskFire = (1 << SpellSchools.SpellSchoolFire),

        SpellSchoolMaskNature = (1 << SpellSchools.SpellSchoolNature),

        SpellSchoolMaskFrost = (1 << SpellSchools.SpellSchoolFrost),

        SpellSchoolMaskShadow = (1 << SpellSchools.SpellSchoolShadow),

        SpellSchoolMaskArcane = (1 << SpellSchools.SpellSchoolArcane),

        // unions

        // 124, not include normal and holy damage
        SpellSchoolMaskSpell =
            (SpellSchoolMaskFire | SpellSchoolMaskNature | SpellSchoolMaskFrost | SpellSchoolMaskShadow
             | SpellSchoolMaskArcane),
        // 126
        SpellSchoolMaskMagic = (SpellSchoolMaskHoly | SpellSchoolMaskSpell),

        // 127
        SpellSchoolMaskAll = (SpellSchoolMaskNormal | SpellSchoolMaskMagic)
    };

    internal enum SpellEffects
    {
        SpellEffectNone = 0,

        SpellEffectInstakill = 1,

        SpellEffectSchoolDamage = 2,

        SpellEffectDummy = 3,

        SpellEffectPortalTeleport = 4,

        SpellEffectTeleportUnits = 5,

        SpellEffectApplyAura = 6,

        SpellEffectEnvironmentalDamage = 7,

        SpellEffectPowerDrain = 8,

        SpellEffectHealthLeech = 9,

        SpellEffectHeal = 10,

        SpellEffectBind = 11,

        SpellEffectPortal = 12,

        SpellEffectRitualBase = 13,

        SpellEffectRitualSpecialize = 14,

        SpellEffectRitualActivatePortal = 15,

        SpellEffectQuestComplete = 16,

        SpellEffectWeaponDamageNoschool = 17,

        SpellEffectResurrect = 18,

        SpellEffectAddExtraAttacks = 19,

        SpellEffectDodge = 20,

        SpellEffectEvade = 21,

        SpellEffectParry = 22,

        SpellEffectBlock = 23,

        SpellEffectCreateItem = 24,

        SpellEffectWeapon = 25,

        SpellEffectDefense = 26,

        SpellEffectPersistentAreaAura = 27,

        SpellEffectSummon = 28,

        SpellEffectLeap = 29,

        SpellEffectEnergize = 30,

        SpellEffectWeaponPercentDamage = 31,

        SpellEffectTriggerMissile = 32,

        SpellEffectOpenLock = 33,

        SpellEffectSummonChangeItem = 34,

        SpellEffectApplyAreaAuraParty = 35,

        SpellEffectLearnSpell = 36,

        SpellEffectSpellDefense = 37,

        SpellEffectDispel = 38,

        SpellEffectLanguage = 39,

        SpellEffectDualWield = 40,

        SpellEffect41 = 41, // old SPELL_EFFECT_SUMMON_WILD

        SpellEffect42 = 42, // old SPELL_EFFECT_SUMMON_GUARDIAN

        SpellEffectTeleportUnitsFaceCaster = 43,

        SpellEffectSkillStep = 44,

        SpellEffectUndefined45 = 45,

        SpellEffectSpawn = 46,

        SpellEffectTradeSkill = 47,

        SpellEffectStealth = 48,

        SpellEffectDetect = 49,

        SpellEffectTransDoor = 50,

        SpellEffectForceCriticalHit = 51,

        SpellEffectGuaranteeHit = 52,

        SpellEffectEnchantItem = 53,

        SpellEffectEnchantItemTemporary = 54,

        SpellEffectTamecreature = 55,

        SpellEffectSummonPet = 56,

        SpellEffectLearnPetSpell = 57,

        SpellEffectWeaponDamage = 58,

        SpellEffectOpenLockItem = 59,

        SpellEffectProficiency = 60,

        SpellEffectSendEvent = 61,

        SpellEffectPowerBurn = 62,

        SpellEffectThreat = 63,

        SpellEffectTriggerSpell = 64,

        SpellEffectHealthFunnel = 65,

        SpellEffectPowerFunnel = 66,

        SpellEffectHealMaxHealth = 67,

        SpellEffectInterruptCast = 68,

        SpellEffectDistract = 69,

        SpellEffectPull = 70,

        SpellEffectPickpocket = 71,

        SpellEffectAddFarsight = 72,

        SpellEffect73 = 73, // old SPELL_EFFECT_SUMMON_POSSESSED

        SpellEffect74 = 74, // old SPELL_EFFECT_SUMMON_TOTEM

        SpellEffectHealMechanical = 75,

        SpellEffectSummonObjectWild = 76,

        SpellEffectScriptEffect = 77,

        SpellEffectAttack = 78,

        SpellEffectSanctuary = 79,

        SpellEffectAddComboPoints = 80,

        SpellEffectCreateHouse = 81,

        SpellEffectBindSight = 82,

        SpellEffectDuel = 83,

        SpellEffectStuck = 84,

        SpellEffectSummonPlayer = 85,

        SpellEffectActivateObject = 86,

        SpellEffect87 = 87, // old SPELL_EFFECT_SUMMON_TOTEM_SLOT1

        SpellEffect88 = 88, // old SPELL_EFFECT_SUMMON_TOTEM_SLOT2

        SpellEffect89 = 89, // old SPELL_EFFECT_SUMMON_TOTEM_SLOT3

        SpellEffect90 = 90, // old SPELL_EFFECT_SUMMON_TOTEM_SLOT4

        SpellEffectThreatAll = 91,

        SpellEffectEnchantHeldItem = 92,

        SpellEffect93 = 93, // old SPELL_EFFECT_SUMMON_PHANTASM

        SpellEffectSelfResurrect = 94,

        SpellEffectSkinning = 95,

        SpellEffectCharge = 96,

        SpellEffect97 = 97, // old SPELL_EFFECT_SUMMON_CRITTER

        SpellEffectKnockBack = 98,

        SpellEffectDisenchant = 99,

        SpellEffectInebriate = 100,

        SpellEffectFeedPet = 101,

        SpellEffectDismissPet = 102,

        SpellEffectReputation = 103,

        SpellEffectSummonObjectSlot1 = 104,

        SpellEffectSummonObjectSlot2 = 105,

        SpellEffectSummonObjectSlot3 = 106,

        SpellEffectSummonObjectSlot4 = 107,

        SpellEffectDispelMechanic = 108,

        SpellEffectSummonDeadPet = 109,

        SpellEffectDestroyAllTotems = 110,

        SpellEffectDurabilityDamage = 111,

        SpellEffect112 = 112, // old SPELL_EFFECT_SUMMON_DEMON

        SpellEffectResurrectNew = 113,

        SpellEffectAttackMe = 114,

        SpellEffectDurabilityDamagePct = 115,

        SpellEffectSkinPlayerCorpse = 116,

        SpellEffectSpiritHeal = 117,

        SpellEffectSkill = 118,

        SpellEffectApplyAreaAuraPet = 119,

        SpellEffectTeleportGraveyard = 120,

        SpellEffectNormalizedWeaponDmg = 121,

        SpellEffect122 = 122,

        SpellEffectSendTaxi = 123,

        SpellEffectPlayerPull = 124,

        SpellEffectModifyThreatPercent = 125,

        SpellEffectStealBeneficialBuff = 126,

        SpellEffectProspecting = 127,

        SpellEffectApplyAreaAuraFriend = 128,

        SpellEffectApplyAreaAuraEnemy = 129,

        SpellEffectRedirectThreat = 130,

        SpellEffectPlaySound = 131,

        SpellEffectPlayMusic = 132,

        SpellEffectUnlearnSpecialization = 133,

        SpellEffectKillCreditGroup = 134,

        SpellEffectCallPet = 135,

        SpellEffectHealPct = 136,

        SpellEffectEnergizePct = 137,

        SpellEffectLeapBack = 138,

        SpellEffectClearQuest = 139,

        SpellEffectForceCast = 140,

        SpellEffectForceCastWithValue = 141,

        SpellEffectTriggerSpellWithValue = 142,

        SpellEffectApplyAreaAuraOwner = 143,

        SpellEffectKnockbackFromPosition = 144,

        SpellEffect145 = 145,

        SpellEffect146 = 146,

        SpellEffectQuestFail = 147,

        SpellEffect148 = 148,

        SpellEffectCharge2 = 149,

        SpellEffect150 = 150,

        SpellEffectTriggerSpell2 = 151,

        SpellEffect152 = 152,

        SpellEffect153 = 153,

        TotalSpellEffects = 154
    };

    /**
 * This is what's used in a Modifier by the Aura class
 * to tell what the Aura should modify.
 */

    internal enum AuraType
    {
        SPELL_AURA_NONE = 0,

        SPELL_AURA_BIND_SIGHT = 1,

        SPELL_AURA_MOD_POSSESS = 2,
        /**
     * The aura should do periodic damage, the function that handles
     * this is Aura::HandlePeriodicDamage, the amount is usually decided
     * by the Unit::SpellDamageBonusDone or Unit::MeleeDamageBonusDone
     * which increases/decreases the Modifier::m_amount
     */

        SPELL_AURA_PERIODIC_DAMAGE = 3,
        /**
     * Used by Aura::HandleAuraDummy
     */

        SPELL_AURA_DUMMY = 4,
        /**
     * Used by Aura::HandleModConfuse, will either confuse or unconfuse
     * the target depending on whether the apply flag is set
     */

        SPELL_AURA_MOD_CONFUSE = 5,

        SPELL_AURA_MOD_CHARM = 6,

        SPELL_AURA_MOD_FEAR = 7,
        /**
     * The aura will do periodic heals of a target, handled by
     * Aura::HandlePeriodicHeal, uses Unit::SpellHealingBonusDone
     * to calculate whether to increase or decrease Modifier::m_amount
     */

        SPELL_AURA_PERIODIC_HEAL = 8,
        /**
     * Changes the attackspeed, the Modifier::m_amount decides
     * how much we change in percent, ie, if the m_amount is
     * 50 the attackspeed will increase by 50%
     */

        SPELL_AURA_MOD_ATTACKSPEED = 9,
        /**
     * Modifies the threat that the Aura does in percent,
     * the Modifier::m_miscvalue decides which of the SpellSchools
     * it should affect threat for.
     * \see SpellSchoolMask
     */

        SPELL_AURA_MOD_THREAT = 10,
        /**
     * Just applies a taunt which will change the threat a mob has
     * Taken care of in Aura::HandleModThreat
     */

        SPELL_AURA_MOD_TAUNT = 11,
        /**
     * Stuns targets in different ways, taken care of in
     * Aura::HandleAuraModStun
     */

        SPELL_AURA_MOD_STUN = 12,
        /**
     * Changes the damage done by a weapon in any hand, the Modifier::m_miscvalue
     * will tell what school the damage is from, it's used as a bitmask
     * \see SpellSchoolMask
     */

        SPELL_AURA_MOD_DAMAGE_DONE = 13,
        /**
     * Not handled by the Aura class but instead this is implemented in
     * Unit::MeleeDamageBonusTaken and Unit::SpellBaseDamageBonusTaken
     */

        SPELL_AURA_MOD_DAMAGE_TAKEN = 14,
        /**
     * Not handled by the Aura class, implemented in Unit::DealMeleeDamage
     */

        SPELL_AURA_DAMAGE_SHIELD = 15,
        /**
     * Taken care of in Aura::HandleModStealth, take note that this
     * is not the same thing as invisibility
     */

        SPELL_AURA_MOD_STEALTH = 16,
        /**
     * Not handled by the Aura class, implemented in Unit::isVisibleForOrDetect
     * which does a lot of checks to determine whether the person is visible or not,
     * the SPELL_AURA_MOD_STEALTH seems to determine how in/visible ie a rogue is.
     */

        SPELL_AURA_MOD_STEALTH_DETECT = 17,
        /**
     * Handled by Aura::HandleInvisibility, the Modifier::m_miscvalue in the struct
     * seems to decide what kind of invisibility it is with a bitflag. the miscvalue
     * decides which bit is set, ie: 3 would make the 3rd bit be set.
     */

        SPELL_AURA_MOD_INVISIBILITY = 18,
        /**
     * Adds one of the kinds of detections to the possible detections.
     * As in SPEALL_AURA_MOD_INVISIBILITY the Modifier::m_miscvalue seems to decide
     * what kind of invisibility the Unit should be able to detect.
     */

        SPELL_AURA_MOD_INVISIBILITY_DETECTION = 19,

        SPELL_AURA_OBS_MOD_HEALTH = 20, // 20,21 unofficial

        SPELL_AURA_OBS_MOD_MANA = 21,
        /**
     * Handled by Aura::HandleAuraModResistance, changes the resistance for a unit
     * the field Modifier::m_miscvalue decides which kind of resistance that should
     * be changed, for possible values see SpellSchools.
     * \see SpellSchools
     */

        SPELL_AURA_MOD_RESISTANCE = 22,
        /**
     * Currently just sets Aura::m_isPeriodic to apply and has a special case
     * for Curse of the Plaguebringer.
     */

        SPELL_AURA_PERIODIC_TRIGGER_SPELL = 23,
        /**
     * Just sets Aura::m_isPeriodic to apply
     */

        SPELL_AURA_PERIODIC_ENERGIZE = 24,
        /**
     * Changes whether the target is pacified or not depending on the apply flag.
     * Pacify makes the target silenced and have all it's attack skill disabled.
     * See: http://www.wowhead.com/spell=6462/pacified
     */

        SPELL_AURA_MOD_PACIFY = 25,
        /**
     * Roots or unroots the target
     */

        SPELL_AURA_MOD_ROOT = 26,
        /**
     * Silences the target and stops and spell casts that should be stopped,
     * they have the flag SpellPreventionType::SPELL_PREVENTION_TYPE_SILENCE
     */

        SPELL_AURA_MOD_SILENCE = 27,

        SPELL_AURA_REFLECT_SPELLS = 28,

        SPELL_AURA_MOD_STAT = 29,

        SPELL_AURA_MOD_SKILL = 30,

        SPELL_AURA_MOD_INCREASE_SPEED = 31,

        SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED = 32,

        SPELL_AURA_MOD_DECREASE_SPEED = 33,

        SPELL_AURA_MOD_INCREASE_HEALTH = 34,

        SPELL_AURA_MOD_INCREASE_ENERGY = 35,

        SPELL_AURA_MOD_SHAPESHIFT = 36,

        SPELL_AURA_EFFECT_IMMUNITY = 37,

        SPELL_AURA_STATE_IMMUNITY = 38,

        SPELL_AURA_SCHOOL_IMMUNITY = 39,

        SPELL_AURA_DAMAGE_IMMUNITY = 40,

        SPELL_AURA_DISPEL_IMMUNITY = 41,

        SPELL_AURA_PROC_TRIGGER_SPELL = 42,

        SPELL_AURA_PROC_TRIGGER_DAMAGE = 43,

        SPELL_AURA_TRACK_CREATURES = 44,

        SPELL_AURA_TRACK_RESOURCES = 45,

        SPELL_AURA_46 = 46, // Ignore all Gear test spells

        SPELL_AURA_MOD_PARRY_PERCENT = 47,

        SPELL_AURA_48 = 48, // One periodic spell

        SPELL_AURA_MOD_DODGE_PERCENT = 49,

        SPELL_AURA_MOD_BLOCK_SKILL = 50,

        SPELL_AURA_MOD_BLOCK_PERCENT = 51,

        SPELL_AURA_MOD_CRIT_PERCENT = 52,

        SPELL_AURA_PERIODIC_LEECH = 53,

        SPELL_AURA_MOD_HIT_CHANCE = 54,

        SPELL_AURA_MOD_SPELL_HIT_CHANCE = 55,

        SPELL_AURA_TRANSFORM = 56,

        SPELL_AURA_MOD_SPELL_CRIT_CHANCE = 57,

        SPELL_AURA_MOD_INCREASE_SWIM_SPEED = 58,

        SPELL_AURA_MOD_DAMAGE_DONE_CREATURE = 59,

        SPELL_AURA_MOD_PACIFY_SILENCE = 60,

        SPELL_AURA_MOD_SCALE = 61,

        SPELL_AURA_PERIODIC_HEALTH_FUNNEL = 62,

        SPELL_AURA_PERIODIC_MANA_FUNNEL = 63,

        SPELL_AURA_PERIODIC_MANA_LEECH = 64,

        SPELL_AURA_MOD_CASTING_SPEED_NOT_STACK = 65,

        SPELL_AURA_FEIGN_DEATH = 66,

        SPELL_AURA_MOD_DISARM = 67,

        SPELL_AURA_MOD_STALKED = 68,

        SPELL_AURA_SCHOOL_ABSORB = 69,

        SPELL_AURA_EXTRA_ATTACKS = 70,

        SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL = 71,

        SPELL_AURA_MOD_POWER_COST_SCHOOL_PCT = 72,

        SPELL_AURA_MOD_POWER_COST_SCHOOL = 73,

        SPELL_AURA_REFLECT_SPELLS_SCHOOL = 74,

        SPELL_AURA_MOD_LANGUAGE = 75,

        SPELL_AURA_FAR_SIGHT = 76,

        SPELL_AURA_MECHANIC_IMMUNITY = 77,

        SPELL_AURA_MOUNTED = 78,

        SPELL_AURA_MOD_DAMAGE_PERCENT_DONE = 79,

        SPELL_AURA_MOD_PERCENT_STAT = 80,

        SPELL_AURA_SPLIT_DAMAGE_PCT = 81,

        SPELL_AURA_WATER_BREATHING = 82,

        SPELL_AURA_MOD_BASE_RESISTANCE = 83,

        SPELL_AURA_MOD_REGEN = 84,

        SPELL_AURA_MOD_POWER_REGEN = 85,

        SPELL_AURA_CHANNEL_DEATH_ITEM = 86,

        SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN = 87,

        SPELL_AURA_MOD_HEALTH_REGEN_PERCENT = 88,

        SPELL_AURA_PERIODIC_DAMAGE_PERCENT = 89,

        SPELL_AURA_MOD_RESIST_CHANCE = 90,

        SPELL_AURA_MOD_DETECT_RANGE = 91,

        SPELL_AURA_PREVENTS_FLEEING = 92,

        SPELL_AURA_MOD_UNATTACKABLE = 93,

        SPELL_AURA_INTERRUPT_REGEN = 94,

        SPELL_AURA_GHOST = 95,

        SPELL_AURA_SPELL_MAGNET = 96,

        SPELL_AURA_MANA_SHIELD = 97,

        SPELL_AURA_MOD_SKILL_TALENT = 98,

        SPELL_AURA_MOD_ATTACK_POWER = 99,

        SPELL_AURA_AURAS_VISIBLE = 100,

        SPELL_AURA_MOD_RESISTANCE_PCT = 101,

        SPELL_AURA_MOD_MELEE_ATTACK_POWER_VERSUS = 102,

        SPELL_AURA_MOD_TOTAL_THREAT = 103,

        SPELL_AURA_WATER_WALK = 104,

        SPELL_AURA_FEATHER_FALL = 105,

        SPELL_AURA_HOVER = 106,

        SPELL_AURA_ADD_FLAT_MODIFIER = 107,

        SPELL_AURA_ADD_PCT_MODIFIER = 108,

        SPELL_AURA_ADD_TARGET_TRIGGER = 109,

        SPELL_AURA_MOD_POWER_REGEN_PERCENT = 110,

        SPELL_AURA_ADD_CASTER_HIT_TRIGGER = 111,

        SPELL_AURA_OVERRIDE_CLASS_SCRIPTS = 112,

        SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN = 113,

        SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT = 114,

        SPELL_AURA_MOD_HEALING = 115,

        SPELL_AURA_MOD_REGEN_DURING_COMBAT = 116,

        SPELL_AURA_MOD_MECHANIC_RESISTANCE = 117,

        SPELL_AURA_MOD_HEALING_PCT = 118,

        SPELL_AURA_SHARE_PET_TRACKING = 119,

        SPELL_AURA_UNTRACKABLE = 120,

        SPELL_AURA_EMPATHY = 121,

        SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT = 122,

        SPELL_AURA_MOD_TARGET_RESISTANCE = 123,

        SPELL_AURA_MOD_RANGED_ATTACK_POWER = 124,

        SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN = 125,

        SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT = 126,

        SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS = 127,

        SPELL_AURA_MOD_POSSESS_PET = 128,

        SPELL_AURA_MOD_SPEED_ALWAYS = 129,

        SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS = 130,

        SPELL_AURA_MOD_RANGED_ATTACK_POWER_VERSUS = 131,

        SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT = 132,

        SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT = 133,

        SPELL_AURA_MOD_MANA_REGEN_INTERRUPT = 134,

        SPELL_AURA_MOD_HEALING_DONE = 135,

        SPELL_AURA_MOD_HEALING_DONE_PERCENT = 136,

        SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE = 137,

        SPELL_AURA_MOD_MELEE_HASTE = 138,

        SPELL_AURA_FORCE_REACTION = 139,

        SPELL_AURA_MOD_RANGED_HASTE = 140,

        SPELL_AURA_MOD_RANGED_AMMO_HASTE = 141,

        SPELL_AURA_MOD_BASE_RESISTANCE_PCT = 142,

        SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE = 143,

        SPELL_AURA_SAFE_FALL = 144,

        SPELL_AURA_CHARISMA = 145,

        SPELL_AURA_PERSUADED = 146,

        SPELL_AURA_MECHANIC_IMMUNITY_MASK = 147,

        SPELL_AURA_RETAIN_COMBO_POINTS = 148,

        SPELL_AURA_RESIST_PUSHBACK = 149, //    Resist Pushback

        SPELL_AURA_MOD_SHIELD_BLOCKVALUE_PCT = 150,

        SPELL_AURA_TRACK_STEALTHED = 151, //    Track Stealthed

        SPELL_AURA_MOD_DETECTED_RANGE = 152, //    Mod Detected Range

        SPELL_AURA_SPLIT_DAMAGE_FLAT = 153, //    Split Damage Flat

        SPELL_AURA_MOD_STEALTH_LEVEL = 154, //    Stealth Level Modifier

        SPELL_AURA_MOD_WATER_BREATHING = 155, //    Mod Water Breathing

        SPELL_AURA_MOD_REPUTATION_GAIN = 156, //    Mod Reputation Gain

        SPELL_AURA_PET_DAMAGE_MULTI = 157, //    Mod Pet Damage

        SPELL_AURA_MOD_SHIELD_BLOCKVALUE = 158,

        SPELL_AURA_NO_PVP_CREDIT = 159,

        SPELL_AURA_MOD_AOE_AVOIDANCE = 160,

        SPELL_AURA_MOD_HEALTH_REGEN_IN_COMBAT = 161,

        SPELL_AURA_POWER_BURN_MANA = 162,

        SPELL_AURA_MOD_CRIT_DAMAGE_BONUS = 163,

        SPELL_AURA_164 = 164,

        SPELL_AURA_MELEE_ATTACK_POWER_ATTACKER_BONUS = 165,

        SPELL_AURA_MOD_ATTACK_POWER_PCT = 166,

        SPELL_AURA_MOD_RANGED_ATTACK_POWER_PCT = 167,

        SPELL_AURA_MOD_DAMAGE_DONE_VERSUS = 168,

        SPELL_AURA_MOD_CRIT_PERCENT_VERSUS = 169,

        SPELL_AURA_DETECT_AMORE = 170,

        SPELL_AURA_MOD_SPEED_NOT_STACK = 171,

        SPELL_AURA_MOD_MOUNTED_SPEED_NOT_STACK = 172,

        SPELL_AURA_ALLOW_CHAMPION_SPELLS = 173,

        SPELL_AURA_MOD_SPELL_DAMAGE_OF_STAT_PERCENT = 174,
        // by defeult intelect, dependent from SPELL_AURA_MOD_SPELL_HEALING_OF_STAT_PERCENT

        SPELL_AURA_MOD_SPELL_HEALING_OF_STAT_PERCENT = 175,

        SPELL_AURA_SPIRIT_OF_REDEMPTION = 176,

        SPELL_AURA_AOE_CHARM = 177,

        SPELL_AURA_MOD_DEBUFF_RESISTANCE = 178,

        SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_CHANCE = 179,

        SPELL_AURA_MOD_FLAT_SPELL_DAMAGE_VERSUS = 180,

        SPELL_AURA_MOD_FLAT_SPELL_CRIT_DAMAGE_VERSUS = 181, // unused - possible flat spell crit damage versus

        SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT = 182,

        SPELL_AURA_MOD_CRITICAL_THREAT = 183,

        SPELL_AURA_MOD_ATTACKER_MELEE_HIT_CHANCE = 184,

        SPELL_AURA_MOD_ATTACKER_RANGED_HIT_CHANCE = 185,

        SPELL_AURA_MOD_ATTACKER_SPELL_HIT_CHANCE = 186,

        SPELL_AURA_MOD_ATTACKER_MELEE_CRIT_CHANCE = 187,

        SPELL_AURA_MOD_ATTACKER_RANGED_CRIT_CHANCE = 188,

        SPELL_AURA_MOD_RATING = 189,

        SPELL_AURA_MOD_FACTION_REPUTATION_GAIN = 190,

        SPELL_AURA_USE_NORMAL_MOVEMENT_SPEED = 191,

        SPELL_AURA_MOD_MELEE_RANGED_HASTE = 192,

        SPELL_AURA_HASTE_ALL = 193,

        SPELL_AURA_MOD_DEPRICATED_1 = 194, // not used now, old SPELL_AURA_MOD_SPELL_DAMAGE_OF_INTELLECT

        SPELL_AURA_MOD_DEPRICATED_2 = 195, // not used now, old SPELL_AURA_MOD_SPELL_HEALING_OF_INTELLECT

        SPELL_AURA_MOD_COOLDOWN = 196, // only 24818 Noxious Breath

        SPELL_AURA_MOD_ATTACKER_SPELL_AND_WEAPON_CRIT_CHANCE = 197,

        SPELL_AURA_MOD_ALL_WEAPON_SKILLS = 198,

        SPELL_AURA_MOD_INCREASES_SPELL_PCT_TO_HIT = 199,

        SPELL_AURA_MOD_XP_PCT = 200,

        SPELL_AURA_FLY = 201,

        SPELL_AURA_IGNORE_COMBAT_RESULT = 202,

        SPELL_AURA_MOD_ATTACKER_MELEE_CRIT_DAMAGE = 203,

        SPELL_AURA_MOD_ATTACKER_RANGED_CRIT_DAMAGE = 204,

        SPELL_AURA_MOD_ATTACKER_SPELL_CRIT_DAMAGE = 205,

        SPELL_AURA_MOD_FLIGHT_SPEED = 206,

        SPELL_AURA_MOD_FLIGHT_SPEED_MOUNTED = 207,

        SPELL_AURA_MOD_FLIGHT_SPEED_STACKING = 208,

        SPELL_AURA_MOD_FLIGHT_SPEED_MOUNTED_STACKING = 209,

        SPELL_AURA_MOD_FLIGHT_SPEED_NOT_STACKING = 210,

        SPELL_AURA_MOD_FLIGHT_SPEED_MOUNTED_NOT_STACKING = 211,

        SPELL_AURA_MOD_RANGED_ATTACK_POWER_OF_STAT_PERCENT = 212,

        SPELL_AURA_MOD_RAGE_FROM_DAMAGE_DEALT = 213,

        SPELL_AURA_214 = 214,

        SPELL_AURA_ARENA_PREPARATION = 215,

        SPELL_AURA_HASTE_SPELLS = 216,

        SPELL_AURA_217 = 217,

        SPELL_AURA_HASTE_RANGED = 218,

        SPELL_AURA_MOD_MANA_REGEN_FROM_STAT = 219,

        SPELL_AURA_MOD_RATING_FROM_STAT = 220,

        SPELL_AURA_221 = 221,

        SPELL_AURA_222 = 222,

        SPELL_AURA_223 = 223,

        SPELL_AURA_224 = 224,

        SPELL_AURA_PRAYER_OF_MENDING = 225,

        SPELL_AURA_PERIODIC_DUMMY = 226,

        SPELL_AURA_PERIODIC_TRIGGER_SPELL_WITH_VALUE = 227,

        SPELL_AURA_DETECT_STEALTH = 228,

        SPELL_AURA_MOD_AOE_DAMAGE_AVOIDANCE = 229,

        SPELL_AURA_230 = 230,

        SPELL_AURA_PROC_TRIGGER_SPELL_WITH_VALUE = 231,

        SPELL_AURA_MECHANIC_DURATION_MOD = 232,

        SPELL_AURA_233 = 233,

        SPELL_AURA_MECHANIC_DURATION_MOD_NOT_STACK = 234,

        SPELL_AURA_MOD_DISPEL_RESIST = 235,

        SPELL_AURA_236 = 236,

        SPELL_AURA_MOD_SPELL_DAMAGE_OF_ATTACK_POWER = 237,

        SPELL_AURA_MOD_SPELL_HEALING_OF_ATTACK_POWER = 238,

        SPELL_AURA_MOD_SCALE_2 = 239,

        SPELL_AURA_MOD_EXPERTISE = 240,

        SPELL_AURA_FORCE_MOVE_FORWARD = 241,

        SPELL_AURA_242 = 242,

        SPELL_AURA_FACTION_OVERRIDE = 243,

        SPELL_AURA_COMPREHEND_LANGUAGE = 244,

        SPELL_AURA_245 = 245,

        SPELL_AURA_246 = 246,

        SPELL_AURA_MIRROR_IMAGE = 247,

        SPELL_AURA_MOD_COMBAT_RESULT_CHANCE = 248,

        SPELL_AURA_249 = 249,

        SPELL_AURA_MOD_INCREASE_HEALTH_2 = 250,

        SPELL_AURA_MOD_ENEMY_DODGE = 251,

        SPELL_AURA_252 = 252,

        SPELL_AURA_253 = 253,

        SPELL_AURA_254 = 254,

        SPELL_AURA_255 = 255,

        SPELL_AURA_256 = 256,

        SPELL_AURA_257 = 257,

        SPELL_AURA_258 = 258,

        SPELL_AURA_259 = 259,

        SPELL_AURA_260 = 260,

        SPELL_AURA_261 = 261,

        TOTAL_AURAS = 262
    };

    enum Powers
    {
        POWER_MANA = 0,            // UNIT_FIELD_POWER1
        POWER_RAGE = 1,            // UNIT_FIELD_POWER2
        POWER_FOCUS = 2,            // UNIT_FIELD_POWER3
        POWER_ENERGY = 3,            // UNIT_FIELD_POWER4
        POWER_HAPPINESS = 4,            // UNIT_FIELD_POWER5
    };
}