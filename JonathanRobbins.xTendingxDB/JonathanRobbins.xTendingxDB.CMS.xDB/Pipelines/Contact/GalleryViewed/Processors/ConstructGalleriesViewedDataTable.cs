using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Contact.Campaign;
using Sitecore.Cintel.Reporting.Processors;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Pipelines.Contact.GalleryViewed.Processors
{
    public class ConstructGalleriesViewedDataTable : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            args.ResultTableForView = new DataTable();
            args.ResultTableForView.Columns.Add(Schema.ContactId.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.VisitId.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.VisitIndex.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.VisitStartDateTime.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.VisitEndDateTime.ToColumn());

            args.ResultTableForView.Columns.Add(Schema.Id.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.Title.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.ProductTitle.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.Factions.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.ProductSku.ToColumn());
            args.ResultTableForView.Columns.Add(Schema.ProductType.ToColumn());
        }
    }
}
