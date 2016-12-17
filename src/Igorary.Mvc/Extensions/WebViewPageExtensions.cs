using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covalition.Igorary.Mvc.Extensions
{
    public static class WebViewPageExtensions
    {
        public static IEnumerable<MessageType> GetMessageTypes(this WebViewPage webViewData, bool useSession = false) {
            return GetMessageTypes(webViewData.TempData, webViewData.ViewData, webViewData.Session, useSession);
        }

        /// <summary>
        /// Wersja dla unit testów
        /// </summary>
        public static IEnumerable<MessageType> GetMessageTypes(TempDataDictionary tempData, ViewDataDictionary viewData, HttpSessionStateBase session = null, bool useSession = false) {
            List<MessageType> res = getMessages(tempData, session, useSession)
                .GroupBy(m => m.MessageType)
                .Select(gr => gr.Key)
                .ToList(); 

            //if (tempData.ContainsKey(CommonController.VIEW_DATA_MESSAGES))
            //    res = (tempData[CommonController.VIEW_DATA_MESSAGES] as List<Message>).GroupBy(m => m.MessageType).Select(gr => gr.Key).ToList();
            //else
            //    res = new List<MessageType>();

            if (viewData.ModelState.Errors().Count() > 0 && !res.Any(mt => mt == MessageType.Error))
                res.Add(MessageType.Error);
            return res;
        }

        private static List<Message> getMessages(TempDataDictionary tempData, HttpSessionStateBase session, bool useSession) {
            List<Message> res;
            if (useSession)
                res = session[BaseController.SESSION_MESSAGES] as List<Message>;
            else {
                if (tempData.ContainsKey(BaseController.VIEW_DATA_MESSAGES))
                    res = tempData[BaseController.VIEW_DATA_MESSAGES] as List<Message>;
                else
                    res = null;
            };
            if (res == null) {
                res = new List<Message>();
            };
            return res;
        }

        public static IEnumerable<Message> GetMessages(this WebViewPage webViewData, MessageType messageType, bool useSession = false) {
            return GetMessages(messageType, webViewData.TempData, webViewData.ViewData, webViewData.Session, useSession);
        }

        /// <summary>
        /// Wersja dla unit testów
        /// </summary>
        public static IEnumerable<Message> GetMessages(MessageType messageType, TempDataDictionary tempData, ViewDataDictionary viewData, HttpSessionStateBase session = null, bool useSession = false) {
            List<Message> res = getMessages(tempData, session, useSession);
            //if (tempData.ContainsKey(CommonController.VIEW_DATA_MESSAGES))
            //    res = (tempData[CommonController.VIEW_DATA_MESSAGES] as List<Message>);
            //else
            //    res = new List<Message>();
            foreach (string modelError in viewData.ModelState.Errors())
                res.Add(new Message { MessageType = MessageType.Error, Text = modelError, AsHtml = false });
            return res.Where(m => m.MessageType == messageType);
        }
    }
}