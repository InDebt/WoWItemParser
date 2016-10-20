// This source is for use by Netfira developers or development partners only.
// 
// File: WowItemContext.cs
// Date: 2015-11-17

namespace WowItemParser
{
    using System;

    using WowItemParser.Internal;
    using WowItemParser.Internal.Database;
    using WowItemParser.Internal.DBC;
    using WowItemParser.Internal.GemSystem;
    using WowItemParser.Internal.SpellSystem;

    /// <summary>
    ///     Item Model for the item that will be returned from the database
    /// </summary>
    public class WowItem
    {
        private static Lazy<DbcFile> itemDisplayInfo = new Lazy<DbcFile>(() => new DbcFile("ItemDisplayInfo.dbc")); 
        public WowItem(item_template item)
        {
            this.Stats = new StatInfo();
            this.SocketBonus = new StatInfo();
            this.InternalLoadFromTemplate(item);
        }
        public ItemClass Class { get; set; }
        public ItemSubClass SubClass { get; set; }
        public ItemQuality Quality { get; set; }
        public string Name { get; set; }

        public string Icon { get; set; }

        public StatInfo Stats { get; private set; }

        // sockets

        public SocketColor SocketColor_1 { get; set; }
        public SocketColor SocketColor_2 { get; set; }
        public SocketColor SocketColor_3 { get; set; }

        public StatInfo SocketBonus { get; set; }

        // Weapon

        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double Speed { get; set; }
   

        private void InternalLoadFromTemplate(item_template item)
        {
            this.Class = this.ParseClass(item.@class, item.subclass, item.Material);
            this.SubClass = this.ParseSubClass(item.@class, item.subclass, item.Material, item.InventoryType);
            this.Quality = (ItemQuality)item.Quality;
            this.Name = item.name;

            this.SocketColor_1 = (SocketColor)item.socketColor_1;
            this.SocketColor_2 = (SocketColor)item.socketColor_2;
            this.SocketColor_3 = (SocketColor)item.socketColor_3;

            this.Stats.ArcaneResistence = item.arcane_res;
            this.Stats.FrostResistence = item.frost_res;
            this.Stats.FireResistence = item.fire_res;
            this.Stats.ShadowResistence = item.shadow_res;
            this.Stats.NatureResistence = item.nature_res;
            this.Stats.HolyResistence = item.holy_res;

            this.MinDamage = item.dmg_min1;
            this.MaxDamage = item.dmg_max1;
            this.Speed = item.delay / 1000.0;

            this.InternalHandleBaseStats(item);
            this.InternalHandleSpells(item);
            GemMgr.Instance.ApplySocketBonus(item.socketBonus, this.SocketBonus);

            if (item.displayid != 0)
            {
                this.Icon = itemDisplayInfo.Value.ParseString(itemDisplayInfo.Value.Records[item.displayid][5]);
            }

        }

        private void InternalHandleSpells(item_template item)
        {
            SpellMgr.Instance.ApplyItemSpell(item.spellid_1, this.Stats);
            SpellMgr.Instance.ApplyItemSpell(item.spellid_2, this.Stats);
            SpellMgr.Instance.ApplyItemSpell(item.spellid_3, this.Stats);
        }

        private void InternalHandleBaseStats(item_template item)
        {
            this.Stats.ParseBaseAttribute(item.stat_type1, item.stat_value1);
            this.Stats.ParseBaseAttribute(item.stat_type2, item.stat_value2);
            this.Stats.ParseBaseAttribute(item.stat_type3, item.stat_value3);
            this.Stats.ParseBaseAttribute(item.stat_type4, item.stat_value4);
            this.Stats.ParseBaseAttribute(item.stat_type5, item.stat_value5);
            this.Stats.ParseBaseAttribute(item.stat_type6, item.stat_value6);
            this.Stats.ParseBaseAttribute(item.stat_type7, item.stat_value7);
            this.Stats.ParseBaseAttribute(item.stat_type8, item.stat_value8);
            this.Stats.ParseBaseAttribute(item.stat_type9, item.stat_value9);
            this.Stats.ParseBaseAttribute(item.stat_type10, item.stat_value10);
        }

        private ItemSubClass ParseSubClass(int @class, int subclass, int material, int inventoryType)
        {
            InternalInventoryType invType = (InternalInventoryType)inventoryType;
            switch (invType)
            {
                case InternalInventoryType.Invtype2Hweapon:
                    return ItemSubClass.TwoHand;
                case InternalInventoryType.InvtypeAmmo:
                case InternalInventoryType.InvtypeBag:
                case InternalInventoryType.InvtypeRelic:
                case InternalInventoryType.InvtypeQuiver:
                    return ItemSubClass.None;
                case InternalInventoryType.InvtypeBody:
                    return ItemSubClass.Shirt;
                case InternalInventoryType.InvtypeChest:
                case InternalInventoryType.InvtypeRobe:
                    return ItemSubClass.Chest;
                case InternalInventoryType.InvtypeCloak:
                    return ItemSubClass.Back;
                case InternalInventoryType.InvtypeFeet:
                    return ItemSubClass.Feet;
                case InternalInventoryType.InvtypeHands:
                    return ItemSubClass.Hands;
                case InternalInventoryType.InvtypeFinger:
                    return ItemSubClass.Finger;
                case InternalInventoryType.InvtypeHead:
                    return ItemSubClass.Head;
                case InternalInventoryType.InvtypeLegs:
                    return ItemSubClass.Legs;
                case InternalInventoryType.InvtypeNeck:
                    return ItemSubClass.Neck;
                case InternalInventoryType.InvtypeRanged:
                case InternalInventoryType.InvtypeRangedright:
                case InternalInventoryType.InvtypeThrown:
                    return ItemSubClass.Ranged;
                case InternalInventoryType.InvtypeShield:
                    return ItemSubClass.OffHand;
                case InternalInventoryType.InvtypeShoulders:
                    return ItemSubClass.Shoulders;
                case InternalInventoryType.InvtypeTabard:
                    return ItemSubClass.Tabard;
                case InternalInventoryType.InvtypeTrinket:
                    return ItemSubClass.Trinket;
                case InternalInventoryType.InvtypeWaist:
                    return ItemSubClass.Waist;
                case InternalInventoryType.InvtypeWrists:
                    return ItemSubClass.Wrist;
                case InternalInventoryType.InvtypeNonEquip:
                    if (@class == (int)InternalItemClass.ItemClassGem)
                    {
                        ItemSubclassGem gemColor = (ItemSubclassGem)subclass;
                        switch (gemColor)
                        {
                            case ItemSubclassGem.ItemSubclassGemBlue:
                                return ItemSubClass.Blue;
                            case ItemSubclassGem.ItemSubclassGemGreen:
                                return ItemSubClass.Green;
                            case ItemSubclassGem.ItemSubclassGemMeta:
                                return ItemSubClass.Meta;
                            case ItemSubclassGem.ItemSubclassGemPrismatic:
                                return ItemSubClass.Prismatic;
                            case ItemSubclassGem.ItemSubclassGemOrange:
                                return ItemSubClass.Orange;
                            case ItemSubclassGem.ItemSubclassGemPurple:
                                return ItemSubClass.Purple;
                            case ItemSubclassGem.ItemSubclassGemRed:
                                return ItemSubClass.Red;
                            case ItemSubclassGem.ItemSubclassGemSimple:
                                return ItemSubClass.None;
                            case ItemSubclassGem.ItemSubclassGemYellow:
                                return ItemSubClass.Yellow;
                        }
                    }
                    break;
            }
            return ItemSubClass.None;
        }

        private ItemClass ParseClass(int @class, int subclass, int material)
        {
            InternalItemClass iCl = (InternalItemClass)@class;
            switch (iCl)
            {
                case InternalItemClass.ItemClassArmor:
                    ItemSubclassArmor armorType = (ItemSubclassArmor)subclass;
                    switch (armorType)
                    {
                        case ItemSubclassArmor.ItemSubclassArmorCloth:
                            return ItemClass.Cloth;
                        case ItemSubclassArmor.ItemSubclassArmorLeather:
                            return ItemClass.Leather;
                        case ItemSubclassArmor.ItemSubclassArmorMail:
                            return ItemClass.Mail;
                        case ItemSubclassArmor.ItemSubclassArmorPlate:
                            return ItemClass.Plate;
                        case ItemSubclassArmor.ItemSubclassArmorIdol:
                            return ItemClass.Idol;
                        case ItemSubclassArmor.ItemSubclassArmorLibram:
                            return ItemClass.Libram;
                        case ItemSubclassArmor.ItemSubclassArmorTotem:
                            return ItemClass.Totem;
                        case ItemSubclassArmor.ItemSubclassArmorShield:
                            return ItemClass.Shield;
                        default:
                            return ItemClass.None;
                    }
                case InternalItemClass.ItemClassGem:
                    return ItemClass.None;
                case InternalItemClass.ItemClassWeapon:
                    ItemSubclassWeapon weaponType = (ItemSubclassWeapon)subclass;
                    switch (weaponType)
                    {
                        case ItemSubclassWeapon.ItemSubclassWeaponAxe:
                            return ItemClass.OneHandAxe;
                        case ItemSubclassWeapon.ItemSubclassWeaponAxe2:
                            return ItemClass.TwoHandAxe;
                        case ItemSubclassWeapon.ItemSubclassWeaponBow:
                            return ItemClass.Bow;
                        case ItemSubclassWeapon.ItemSubclassWeaponCrossbow:
                            return ItemClass.Crossbow;
                        case ItemSubclassWeapon.ItemSubclassWeaponDagger:
                            return ItemClass.Dagger;
                        case ItemSubclassWeapon.ItemSubclassWeaponFist:
                            return ItemClass.FistWeapon;
                        case ItemSubclassWeapon.ItemSubclassWeaponGun:
                            return ItemClass.Gun;
                        case ItemSubclassWeapon.ItemSubclassWeaponMace:
                            return ItemClass.OneHandMace;
                        case ItemSubclassWeapon.ItemSubclassWeaponMace2:
                            return ItemClass.TwoHandMace;
                        case ItemSubclassWeapon.ItemSubclassWeaponPolearm:
                            return ItemClass.Polearm;
                        case ItemSubclassWeapon.ItemSubclassWeaponStaff:
                            return ItemClass.Staff;
                        case ItemSubclassWeapon.ItemSubclassWeaponSword:
                            return ItemClass.OneHandSword;
                        case ItemSubclassWeapon.ItemSubclassWeaponSword2:
                            return ItemClass.TwoHandSword;
                        case ItemSubclassWeapon.ItemSubclassWeaponThrown:
                            return ItemClass.Thrown;
                        case ItemSubclassWeapon.ItemSubclassWeaponWand:
                            return ItemClass.Wand;
                        default:
                            return ItemClass.None;
                    }
                default:
                    return ItemClass.None;
            }
        }
    }

    public class StatInfo
    {
        // Stats
        // Base Values
        public int Stamina { get; set; }

        public int Intelligence { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Wisdom { get; set; }

        public int Armor { get; set; }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Haste { get; set; }
        public int HitRaiting { get; set; }

        // Melee Stats
        public int MeleeHitRaiting { get; set; }
        public int CritRaiting { get; set; }

        public int MeleeCritRaiting { get; set; }
        public int MeleeHasteRaiting { get; set; }

        public int Attackpower { get; set; }

        public int Expertise { get; set; }

        public int DodgeRaiting { get; set; }

        public int ParryRaiting { get; set; }

        public int BlockRaiting { get; set; }

        public int BlockValue { get; set; }

        public int DefenseRaiting { get; set; }

        public int ArmorPenetration { get; set; }

        public int Resilence { get; set; }

        // Caster Stats
        public int SpellHitRaiting { get; set; }

        public int SpellDamage { get; set; }

        public int SpellCritRaiting { get; set; }

        public int SpellFireDamage { get; set; }

        public int SpellArcaneDamage { get; set; }

        public int SpellFrostDamage { get; set; }

        public int SpellShadowDamage { get; set; }

        public int SpellNatureDamage { get; set; }

        public int SpellHolyDamage { get; set; }

        public int SpellHaste { get; set; }

        public int AddHeal { get; set; }

        public int ManaPer5 { get; set; }

        // Ranged 

        public int RangedAttackpower { get; set; }
        public int RangedHasteRaiting { get; set; }
        public int RangedHitRaiting { get; set; }
        public int RangedCritRaiting { get; set; }

        public int FrostResistence { get; set; }

        public int FireResistence { get; set; }

        public int NatureResistence { get; set; }

        public int ArcaneResistence { get; set; }

        public int ShadowResistence { get; set; }

        public int HolyResistence { get; set; }

        internal void ParseBaseAttribute(int id, int value)
        {
            InternalItemStatTypes statType = (InternalItemStatTypes)id;
            switch (statType)
            {
                case InternalItemStatTypes.ItemModAgility:
                    this.Agility += value;
                    break;
                case InternalItemStatTypes.ItemModBlockRating:
                    this.BlockRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModCritMeleeRating:
                    this.MeleeCritRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModCritRangedRating:
                    this.RangedCritRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModCritSpellRating:
                    this.SpellCritRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModCritRating:
                    this.CritRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModDefenseSkillRating:
                    this.DefenseRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModDodgeRating:
                    this.DodgeRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModExpertiseRating:
                    this.Expertise += value;
                    break;
                case InternalItemStatTypes.ItemModHasteMeleeRating:
                    this.MeleeHasteRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModHasteRangedRating:
                    this.RangedHasteRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModHasteSpellRating:
                    this.SpellHaste += value;
                    break;
                case InternalItemStatTypes.ItemModHealth:
                    this.SpellHaste += value;
                    break;
                case InternalItemStatTypes.ItemModHitMeleeRating:
                    this.MeleeHitRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModHitRangedRating:
                    this.RangedHitRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModHitRating:
                    this.HitRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModHitSpellRating:
                    this.SpellHitRaiting += value;
                    break;
                case InternalItemStatTypes.ItemModIntellect:
                    this.Intelligence += value;
                    break;
                case InternalItemStatTypes.ItemModMana:
                    this.Mana += value;
                    break;
                case InternalItemStatTypes.ItemModParryRating:
                    this.ParryRaiting = value;
                    break;
                case InternalItemStatTypes.ItemModResilienceRating:
                    this.Resilence += value;
                    break;
                case InternalItemStatTypes.ItemModSpirit:
                    this.Wisdom += value;
                    break;
                case InternalItemStatTypes.ItemModStamina:
                    this.Stamina += value;
                    break;
                case InternalItemStatTypes.ItemModStrength:
                    this.Strength += value;
                    break;
            }
        }
    }
}