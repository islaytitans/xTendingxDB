using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Cintel.Client;
using Sitecore.Cintel.Client.Transformers;
using Sitecore.Cintel.Commons;
using Sitecore.Cintel.Endpoint.Transfomers;
using Sitecore.Diagnostics;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Pipelines.Contact.BrochureDownload.Processors
{
    public class BrochureDownloadResultTransformer : IIntelResultTransformer, IResultTransformer<DataTable>
    {
        private ResultSetExtender resultSetExtender;

        public BrochureDownloadResultTransformer()
        {
            this.resultSetExtender = ClientFactory.Instance.GetResultSetExtender();
        }

        public BrochureDownloadResultTransformer(ResultSetExtender resultSetExtender)
        {
            this.resultSetExtender = resultSetExtender;
        }

        public object Transform(ResultSet<DataTable> resultSet)
        {
            Assert.ArgumentNotNull((object)resultSet, "resultSet");
            this.resultSetExtender.AddRecency(resultSet, "VisitStartDateTime");
            return (object)resultSet;
        }
    }
}
