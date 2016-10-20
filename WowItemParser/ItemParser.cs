using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowItemParser
{
    using WowItemParser.Internal.Database;

    public class ItemParser
    {
        public WowItem GetItemById(int id)
        {
            using (var db = new WowItemContext())
            {
                var item = (from i in db.item_template where i.entry == id select i).FirstOrDefault();
                if (item == null)
                {
                    return null;
                }

                return new WowItem(item);
            }
        }
    }
}
