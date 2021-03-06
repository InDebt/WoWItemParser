﻿// This source is for use by Netfira developers or development partners only.
// 
// File: WowItem.cs
// Date: 2015-11-17

namespace WowItemParser.Internal.Database
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using MySql.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    internal class WowItemContext : DbContext
    {
        public WowItemContext()
            : base("Server=localhost;User Id=root;Password=#k9000FF;Database=mangos;PersistSecurityInfo=True")
        {
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///             classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<item_template> item_template { get; set; }
    }

    [Table("item_template")]
    public class item_template
    {
        [Key]
        public int entry { get; set; }

        public int @class { get; set; }

        public int subclass { get; set; }

        public int unk0 { get; set; }

        public string name { get; set; }

        public int displayid { get; set; }

        public int Quality { get; set; }

        public int Flags { get; set; }

        public int BuyCount { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public int InventoryType { get; set; }

        public int AllowableClass { get; set; }

        public int AllowableRace { get; set; }

        public int ItemLevel { get; set; }

        public int RequiredLevel { get; set; }

        public int RequiredSkill { get; set; }

        public int RequiredSkillRank { get; set; }

        public int requiredspell { get; set; }

        public int requiredhonorrank { get; set; }

        public int RequiredCityRank { get; set; }

        public int RequiredReputationFaction { get; set; }

        public int RequiredReputationRank { get; set; }

        public int maxcount { get; set; }

        public int stackable { get; set; }

        public int ContainerSlots { get; set; }

        public int stat_type1 { get; set; }

        public int stat_value1 { get; set; }

        public int stat_type2 { get; set; }

        public int stat_value2 { get; set; }

        public int stat_type3 { get; set; }

        public int stat_value3 { get; set; }

        public int stat_type4 { get; set; }

        public int stat_value4 { get; set; }

        public int stat_type5 { get; set; }

        public int stat_value5 { get; set; }

        public int stat_type6 { get; set; }

        public int stat_value6 { get; set; }

        public int stat_type7 { get; set; }

        public int stat_value7 { get; set; }

        public int stat_type8 { get; set; }

        public int stat_value8 { get; set; }

        public int stat_type9 { get; set; }

        public int stat_value9 { get; set; }

        public int stat_type10 { get; set; }

        public int stat_value10 { get; set; }

        public double dmg_min1 { get; set; }

        public double dmg_max1 { get; set; }

        public int dmg_type1 { get; set; }

        public double dmg_min2 { get; set; }

        public double dmg_max2 { get; set; }

        public int dmg_type2 { get; set; }

        public double dmg_min3 { get; set; }

        public double dmg_max3 { get; set; }

        public int dmg_type3 { get; set; }

        public double dmg_min4 { get; set; }

        public double dmg_max4 { get; set; }

        public int dmg_type4 { get; set; }

        public double dmg_min5 { get; set; }

        public double dmg_max5 { get; set; }

        public int dmg_type5 { get; set; }

        public int armor { get; set; }

        public int holy_res { get; set; }

        public int fire_res { get; set; }

        public int nature_res { get; set; }

        public int frost_res { get; set; }

        public int shadow_res { get; set; }

        public int arcane_res { get; set; }

        public int delay { get; set; }

        public int ammo_type { get; set; }

        public double RangedModRange { get; set; }

        public int spellid_1 { get; set; }

        public int spelltrigger_1 { get; set; }

        public int spellcharges_1 { get; set; }

        public double spellppmRate_1 { get; set; }

        public int spellcooldown_1 { get; set; }

        public int spellcategory_1 { get; set; }

        public int spellcategorycooldown_1 { get; set; }

        public int spellid_2 { get; set; }

        public int spelltrigger_2 { get; set; }

        public int spellcharges_2 { get; set; }

        public double spellppmRate_2 { get; set; }

        public int spellcooldown_2 { get; set; }

        public int spellcategory_2 { get; set; }

        public int spellcategorycooldown_2 { get; set; }

        public int spellid_3 { get; set; }

        public int spelltrigger_3 { get; set; }

        public int spellcharges_3 { get; set; }

        public double spellppmRate_3 { get; set; }

        public int spellcooldown_3 { get; set; }

        public int spellcategory_3 { get; set; }

        public int spellcategorycooldown_3 { get; set; }

        public int spellid_4 { get; set; }

        public int spelltrigger_4 { get; set; }

        public int spellcharges_4 { get; set; }

        public double spellppmRate_4 { get; set; }

        public int spellcooldown_4 { get; set; }

        public int spellcategory_4 { get; set; }

        public int spellcategorycooldown_4 { get; set; }

        public int spellid_5 { get; set; }

        public int spelltrigger_5 { get; set; }

        public int spellcharges_5 { get; set; }

        public double spellppmRate_5 { get; set; }

        public int spellcooldown_5 { get; set; }

        public int spellcategory_5 { get; set; }

        public int spellcategorycooldown_5 { get; set; }

        public int bonding { get; set; }

        public string description { get; set; }

        public int PageText { get; set; }

        public int LanguageID { get; set; }

        public int PageMaterial { get; set; }

        public int startquest { get; set; }

        public int lockid { get; set; }

        public int Material { get; set; }

        public int sheath { get; set; }

        public int RandomProperty { get; set; }

        public int RandomSuffix { get; set; }

        public int block { get; set; }

        public int itemset { get; set; }

        public int MaxDurability { get; set; }

        public int area { get; set; }

        public int Map { get; set; }

        public int BagFamily { get; set; }

        public int TotemCategory { get; set; }

        public int socketColor_1 { get; set; }

        public int socketContent_1 { get; set; }

        public int socketColor_2 { get; set; }

        public int socketContent_2 { get; set; }

        public int socketColor_3 { get; set; }

        public int socketContent_3 { get; set; }

        public int socketBonus { get; set; }

        public int GemProperties { get; set; }

        public int RequiredDisenchantSkill { get; set; }

        public double ArmorDamageModifier { get; set; }

        public string ScriptName { get; set; }

        public int DisenchantID { get; set; }

        public int FoodType { get; set; }

        public int minMoneyLoot { get; set; }

        public int maxMoneyLoot { get; set; }

        public int Duration { get; set; }

        public int ExtraFlags { get; set; }
    }
}