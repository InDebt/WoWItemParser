// This source is for use by Netfira developers or development partners only.
// 
// File: InternalSubClasses.cs
// Date: 2015-11-17

namespace WowItemParser.Internal
{
    internal enum ItemSubclassWeapon
    {
        ItemSubclassWeaponAxe = 0,

        ItemSubclassWeaponAxe2 = 1,

        ItemSubclassWeaponBow = 2,

        ItemSubclassWeaponGun = 3,

        ItemSubclassWeaponMace = 4,

        ItemSubclassWeaponMace2 = 5,

        ItemSubclassWeaponPolearm = 6,

        ItemSubclassWeaponSword = 7,

        ItemSubclassWeaponSword2 = 8,

        ItemSubclassWeaponObsolete = 9,

        ItemSubclassWeaponStaff = 10,

        ItemSubclassWeaponExotic = 11,

        ItemSubclassWeaponExotic2 = 12,

        ItemSubclassWeaponFist = 13,

        ItemSubclassWeaponMisc = 14,

        ItemSubclassWeaponDagger = 15,

        ItemSubclassWeaponThrown = 16,

        ItemSubclassWeaponSpear = 17,

        ItemSubclassWeaponCrossbow = 18,

        ItemSubclassWeaponWand = 19,

        ItemSubclassWeaponFishingPole = 20
    };

    internal enum ItemSubclassGem
    {
        ItemSubclassGemRed = 0,

        ItemSubclassGemBlue = 1,

        ItemSubclassGemYellow = 2,

        ItemSubclassGemPurple = 3,

        ItemSubclassGemGreen = 4,

        ItemSubclassGemOrange = 5,

        ItemSubclassGemMeta = 6,

        ItemSubclassGemSimple = 7,

        ItemSubclassGemPrismatic = 8
    };

    internal enum ItemSubclassArmor
    {
        ItemSubclassArmorMisc = 0,

        ItemSubclassArmorCloth = 1,

        ItemSubclassArmorLeather = 2,

        ItemSubclassArmorMail = 3,

        ItemSubclassArmorPlate = 4,

        ItemSubclassArmorBuckler = 5,

        ItemSubclassArmorShield = 6,

        ItemSubclassArmorLibram = 7,

        ItemSubclassArmorIdol = 8,

        ItemSubclassArmorTotem = 9
    };

    internal enum ItemSubclassProjectile
    {
        ItemSubclassWand = 0,        // ABS
        ItemSubclassBolt = 1,        // ABS
        ItemSubclassArrow = 2,
        ItemSubclassBullet = 3,
        ItemSubclassThrown = 4         // ABS
    };

    internal enum ItemSubclassQuiver
    {
        ItemSubclassQuiver0 = 0,        // ABS
        ItemSubclassQuiver1 = 1,        // ABS
        ItemSubclassQuiver = 2,
        ItemSubclassAmmoPouch = 3
    };
}