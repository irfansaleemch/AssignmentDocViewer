using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Handler;
using GroupDocs.Viewer.Domain.Html;
using System.Text;
using System.Configuration;

namespace AssignmentDocViewer
{
    public class DocUtilty
    {
        /*
        const string directoryPath = @"F:\Irfan Data\SampleApp\Learning\Assignment";
        string docName = "Irfan Saleem_CV.docx";*/

        string directoryPath = ConfigurationManager.AppSettings["directoryPath"];
        string docName = ConfigurationManager.AppSettings["docName"];
        public string GetContent()
        {
            var vc = new ViewerConfig();
            vc.StoragePath = directoryPath;

            var vhHandler = new ViewerHtmlHandler(vc);

            //var docName = "Irfan Saleem_CV.DOCX";
            List<PageHtml> phList = vhHandler.GetPages(docName);
            StringBuilder contentBuilder = new StringBuilder();

            phList.ForEach(ph => contentBuilder.Append(ph.HtmlContent));
            return contentBuilder.ToString();
        }
        public List<PageHtml> GetContent(int pageNumber)
        {

            var vc = new ViewerConfig();
            vc.StoragePath = directoryPath;

            //= ViewerHandler vhHandler = new ViewerHtmlHandler(vc);
            var vhHandler = new ViewerHtmlHandler(vc);
            
            //= vhHandler.RotatePage(new GroupDocs.Viewer.Domain.Options.RotatePageOptions(docName,pageNumber, 1));
            //=List<PageHtml> phList = ((ViewerHtmlHandler)vhHandler).GetPages(docName);

            List<PageHtml> phList = vhHandler.GetPages(docName);
            return phList;

        }
        public string GetContent(int pageNumber, out int totalPages)
        {
            string result = string.Empty;
            totalPages = 0;
            try
            {
                //=throw new Exception("Test Exception");

                List<PageHtml> phList = GetContent(pageNumber);
                totalPages = phList.Count;

                if (phList.Count >= pageNumber)
                {
                    result = phList[pageNumber - 1].HtmlContent;
                }
                else
                {
                    result = "No page found at index " + (pageNumber - 1).ToString();
                }
            }
            catch (Exception ex)
            {
                result = "Sorry! Document could not be loaded due to some internal error. Error details:" + ex.Message;
            }
            
            return result;
        }
    }
}