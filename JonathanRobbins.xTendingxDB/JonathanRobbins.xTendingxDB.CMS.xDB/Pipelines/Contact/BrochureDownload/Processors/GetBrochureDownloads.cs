using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using JonathanRobbins.xTendingxDB.CMS.xDB.Repository;
using Sitecore.Analytics.Data;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Cintel.Reporting.ReportingServerDatasource;
using Sitecore.Diagnostics;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Pipelines.Contact.BrochureDownload.Processors
{
    public class GetBrochureDownloads : ReportProcessorBase
    {
        private readonly QueryBuilder _contactsQueryBuilder = new QueryBuilder()
        {
            collectionName = "Contacts", // Name of the collection containing contacts in MongoDb
            QueryParms =
            {
                {"_id", "@contactid"},
            },
            Fields =
            {
                "_id",
                "KeyInteractions_BrochuresDownload", // path so the Sample Order Element in our custom xDB Facet
                "System_VisitCount"
            }
        };

        public override void Process(ReportProcessorArgs args)
        {
            PassContactElementIntoQueryResult(args);
            return;

            Guid contactId = args.ReportParameters.ContactId;
            DataTable contactQueryExpression =
                base.GetTableFromContactQueryExpression(_contactsQueryBuilder.Build(), contactId, new Guid?());
            Assert.IsTrue(contactQueryExpression.Rows.Count >= 1,
                string.Format("Contact with id {0} was not found.", (object)contactId));
            int? nullable = DataRowExtensions.Field<int?>(contactQueryExpression.Rows[0], "System_VisitCount");
            if (nullable == null)
                Log.Debug(string.Format("No VisitCount exists for contact: {0}", (object)contactId));
            args.QueryResult = contactQueryExpression;
        }

        private void PassContactElementIntoQueryResult(ReportProcessorArgs args)
        {
            DataTable queryResultTable = new DataTable();

            var contactRepository = Sitecore.Configuration.Factory.CreateObject("tracking/contactRepository", true) as ContactRepository;
            var contact = contactRepository.LoadContactReadOnly(args.ReportParameters.ContactId);

            IKeyInteractionsRepository keyInteractionsRepository = new KeyInteractionsRepository();

            var brochureDownloads = keyInteractionsRepository.GetBrochureDownloads(contact);

            foreach (var brochureDownload in brochureDownloads)
            {
                DataRow dataRow = queryResultTable.NewRow();
                dataRow[Schema.Id.Name] = brochureDownload.Id;
                dataRow[Schema.Title.Name] = brochureDownload.Title;
                dataRow[Schema.ProductTitle.Name] = brochureDownload.ProductTitle;
                dataRow[Schema.ProductSku.Name] = brochureDownload.ProductSku;
                queryResultTable.Rows.Add(dataRow);
            }

            args.QueryResult = queryResultTable;
        }
    }
}