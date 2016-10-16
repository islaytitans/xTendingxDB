using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Pipelines.Contact.SampleOrder.Processors
{
    public class PopulateSampleOrdersWithXdbData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            DataTable queryResult = args.QueryResult;
            DataTable resultTableForView = args.ResultTableForView;
            ProjectRawTableIntoResultTable(args, queryResult, resultTableForView);
        }

        private void ProjectRawTableIntoResultTable(ReportProcessorArgs args, DataTable rawTable, DataTable resultTable)
        {
            foreach (DataRow sourceRow in DataTableExtensions.AsEnumerable(rawTable))
            {
                DataRow dataRow = resultTable.NewRow();
                TryFillData<Guid>(dataRow, new ViewField<Guid>("ContactId"), sourceRow, "ContactId");
                TryFillData<Guid>(dataRow, new ViewField<Guid>("VisitId"), sourceRow, "_id");
                TryFillData<int>(dataRow, new ViewField<int>("VisitIndex"), sourceRow, "LatestVisitIndex");
                TryFillData<DateTime>(dataRow, new ViewField<DateTime>("VisitStartDateTime"), sourceRow, "StartDateTime");

                TryFillData<string>(dataRow, new ViewField<string>(Schema.Title.Name), sourceRow, Schema.Title.Name);
                TryFillData<string>(dataRow, new ViewField<string>(Schema.Sku.Name), sourceRow, Schema.Sku.Name);
                TryFillData<string>(dataRow, new ViewField<string>(Schema.Type.Name), sourceRow, Schema.Type.Name);
                resultTable.Rows.Add(dataRow);
            }
        }
    }
}