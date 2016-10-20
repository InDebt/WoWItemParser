using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowItemParser.Internal.SpellSystem
{
    using WowItemParser.Internal.DBC;

    /// <summary>
    /// Simplified projection of a spell record from the spell.dbc
    /// </summary>
    class SpellRecord
    {
        public SpellRecord(int[] spellRecord, DbcFile spellDbc)
        {
            this.Name = spellDbc.ParseString(spellRecord[(int)SpellDbcFieldOffsets.SpellName]);
            this.SpellEffects = new List<SpellEffectRecord>();

            for (int i = 0; i < 3; i++)
            {
                if (spellRecord[(int)SpellDbcFieldOffsets.SpellEffect + i] != 0)
                {
                    this.SpellEffects.Add(new SpellEffectRecord(spellRecord, i));
                }
            }

        }
        public string Name { get; private set; }

        public List<SpellEffectRecord> SpellEffects { get; private set; }

    }
}
