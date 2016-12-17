using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Covalition.Igorary.Mvc
{
    public class BaseController: Controller
    {
        public const string VIEW_DATA_MESSAGES = "ViewDataMessages";

        public const string SESSION_MESSAGES = "SessionMessages";

        private NLog.Logger logger = null;
        protected NLog.Logger Logger {
            get {
                if (logger == null)
                    logger = NLog.LogManager.GetLogger(GetType().FullName);
                return logger;
            }
        }

        private void addMessage(MessageType messageType, string message, bool asHtml, HttpSessionStateBase session) {
            List<Message> messages = session != null ? getMessagesFromSession(session) : getMessages();
            messages.Add(new Message { MessageType = messageType, Text = message, AsHtml = asHtml });
        }

        private List<Message> getMessages() {
            List<Message> res;
            if (TempData.ContainsKey(VIEW_DATA_MESSAGES))
                res = TempData[VIEW_DATA_MESSAGES] as List<Message>;
            else {
                res = new List<Message>();
                TempData[VIEW_DATA_MESSAGES] = res;
            }
            return res;
        }

        // TODO: uwspólnić z getMessages()

        private static List<Message> getMessagesFromSession(HttpSessionStateBase session) {
            List<Message> res = session[SESSION_MESSAGES] as List<Message>;
            if (res == null) {
                res = new List<Message>();
                session[SESSION_MESSAGES] = res;
            }
            return res;
        }

        protected void ClearSessionMessages() {
            Session[SESSION_MESSAGES] = null;
        }

        protected void Success(string message, bool asHtml = false, HttpSessionStateBase session = null) {
            addMessage(MessageType.Success, message, asHtml, session);
        }

        protected void Information(string message, bool asHtml = false, HttpSessionStateBase session = null) {
            addMessage(MessageType.Information, message, asHtml, session);
        }

        protected void Error(string message, bool asHtml = false, HttpSessionStateBase session = null) {
            addMessage(MessageType.Error, message, asHtml, session);
        }

        protected void Warning(string message, bool asHtml = false, HttpSessionStateBase session = null) {
            addMessage(MessageType.Warning, message, asHtml, session);
        }

        /// <summary>
        /// Loguje wyjątek i ustawia ModelState.IsValid = false
        /// </summary>
        /// <param name="ex"></param>
        /// <remarks>
        /// Generuje błąd walidacji - do stosowania przy walidowaniu formatki.
        /// </remarks>
        protected void HandleModelException(Exception ex) {
            Logger.Error(ex, "Error");
            ModelState.AddModelError(string.Empty, ex.Message);
        }

        /// <summary>
        /// Loguje wyjątek i wpisuje komunikat o błędzie do TempData
        /// </summary>
        /// <param name="ex"></param>
        /// <remarks>
        /// Do stosowania przy redirect albo tam, gdzie nie ma formatki.
        /// </remarks>
        protected void HandleException(Exception ex, bool asHtml = false) {
            Logger.Error(ex, "Error");
            Error(ex.Message, asHtml);
        }
    }
}
