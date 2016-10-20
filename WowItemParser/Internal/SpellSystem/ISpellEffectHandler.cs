using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowItemParser.Internal.SpellSystem
{
    using WowItemParser.Internal.Database;

    interface ISpellEffectHandler
    {
        bool CanHandleSpell(SpellEffectRecord record);

        void ApplySpellEffect(SpellEffectRecord record, ref StatInfo item);
    }
}
