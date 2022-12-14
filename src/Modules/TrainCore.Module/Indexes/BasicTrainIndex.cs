using OrchardCore.ContentManagement;
using TrainCore.Module.Models;
using YesSql.Indexes;

namespace TrainCore.Module.Indexes
{
    public class BasicTrainIndex : MapIndex
    {
        public string CompanyName { get; set; }
        public string ModelEra { get; set; }
    }

    public class BasicTrainIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context) =>
            context.For<BasicTrainIndex>().Map(contentItem =>
            {
                var trainPart = contentItem.As<BaseTrain>();

                return trainPart == null ? null
                    : new BasicTrainIndex
                    {
                        CompanyName= trainPart.CompanyName,
                        ModelEra= trainPart.ModelEra
                    };
            });
    }
}
