using FluentNHibernate.Mapping;
using LifeCore.Models;

namespace LifeCore.Mappings
{
    public class TestMap : ClassMap<Test>
    {
        public TestMap()
        {
            Id(i => i.Id).GeneratedBy.Native();
            Map(i => i.Name)
                .Column("name");
        }
    }
}
