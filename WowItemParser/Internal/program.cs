using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowItemParser.Internal
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using WowItemParser.Internal.Database;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Item entry:");
            int entry = int.Parse(Console.ReadLine());
            using (var db = new WowItemContext())
            {
                foreach (var item in (from i in db.item_template where i.entry == entry select i))
                {
                    Console.WriteLine(item.name);
                    JsonSerializerSettings s = new JsonSerializerSettings();
                    s.Converters.Add(new StringEnumConverter());
                    s.DefaultValueHandling = DefaultValueHandling.Ignore;
                    Console.WriteLine(JsonConvert.SerializeObject(new WowItem(item), Formatting.Indented, s));
                }
            }

            Console.ReadLine();
        }
    }
}
