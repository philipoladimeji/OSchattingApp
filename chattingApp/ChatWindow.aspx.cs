using System;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LinqChat
{
    public partial class ChatWindow : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        private string _callBackStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = lblFromUsername.Text + " - Private Message ..................................................................";

            if (!IsPostBack)
            {
                lblFromUsername.Text = (string)Request["Username"];
                Page.Title = lblFromUsername.Text + " - Private Message ..................................................................";
                lblFromUserId.Text = (string)Request["FromUserId"];
                lblToUserId.Text = (string)Request["ToUserId"];
                string isReply = (string)Request["IsReply"];

                if (isReply == "yes")
                {
                    lblMessageSent.Text = ConfigurationManager.AppSettings["ChatWindowMessageSent"];
                }

                // focus this window
                string chatWindowToFocus = lblFromUserId.Text + "_" + lblToUserId.Text;
                Session["DefaultWindow"] = chatWindowToFocus;
                this.FocusThisWindow();

                // create a call back reference so that we can refocus to this window when the cursor is placed in the message text box
                string focusWindowCallBackReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "FocusThisWindow", "");
                string focusThisWindowCallBackScript = "function FocusThisWindowCallBack(arg, context) { " + focusWindowCallBackReference + "; }";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "FocusThisWindowCallBack", focusThisWindowCallBackScript, true);
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length > 0)
            {
                this.InsertPrivateMessage();
                this.InsertMessage();
                this.GetPrivateMessages();
                txtMessage.Text = String.Empty;
                this.FocusThisWindow();
            }
        }

        // This is where we send a private chat invitation to other chatters
        private void InsertPrivateMessage()
        {
            // if the private message is sent to this user already, 
            // don't send it again
            if (String.IsNullOrEmpty(lblMessageSent.Text))
            {
                // if any private message is found based on the 
                // from user id, or the to user id, then this 
                // private message will not be inserted
                PrivateMessage privateMessage = new PrivateMessage();
                privateMessage.UserID = Convert.ToInt32(lblFromUserId.Text);
                privateMessage.ToUserID = Convert.ToInt32(lblToUserId.Text);

                LinqChatDataContext db = new LinqChatDataContext();
                db.PrivateMessages.InsertOnSubmit(privateMessage);
                db.SubmitChanges();

                // make sure to assign any value to this label
                // to confirm that a message is sent to this user
                lblMessageSent.Text = ConfigurationManager.AppSettings["ChatWindowMessageSent"];
            }
        }

        /// <summary>
        /// Because of the existence of the ToUserID (the user that we want to privately chat with)
        /// we are only retrieving private messages between two (2) users
        /// </summary>
        private void InsertMessage()
        {
            Message message = new Message();
            message.UserID = Convert.ToInt32(lblFromUserId.Text);
            message.ToUserID = Convert.ToInt32(lblToUserId.Text);
            message.TimeStamp = DateTime.Now;
            message.Text = txtMessage.Text.Replace("<", "");
           
            LinqChatDataContext db = new LinqChatDataContext();
            db.Messages.InsertOnSubmit(message);
            db.SubmitChanges();
        }

        private void GetPrivateMessages()
        {
            LinqChatDataContext db = new LinqChatDataContext();
            var privateMessages = (from m in db.Messages
                                  where
                                  (m.UserID == Convert.ToInt32(lblFromUserId.Text) && m.ToUserID == Convert.ToInt32(lblToUserId.Text))
                                  ||
                                  (m.UserID == Convert.ToInt32(lblToUserId.Text) && m.ToUserID == Convert.ToInt32(lblFromUserId.Text))
                                  orderby m.TimeStamp descending
                                  select m).Take(20).OrderBy(m => m.TimeStamp);

            if (privateMessages != null)
            {
                StringBuilder sb = new StringBuilder();
                int ctr = 0;    // toggle counter for alternating color

                foreach (Message message in privateMessages)
                {
                    // alternate background color on messages
                    if (ctr == 0)
                    {
                        sb.Append("<div style='padding: 10px;'>");
                        ctr = 1;
                    }
                    else
                    {
                        sb.Append("<div style='background-color: #EFEFEF; padding: 10px;'>");
                        ctr = 0;
                    }

                    sb.Append("<span style='color: black; font-weight: bold;'>" + message.User.Username + ":</span>  " + message.Text + "</div>");  
                }

                litMessages.Text = sb.ToString();
            }
        }

        protected void Timer1_OnTick(object sender, EventArgs e)
        {
            this.GetPrivateMessages();

            if (Session["DefaultWindow"] != null)
            {
                this.FocusThisWindow();
            }
        }

        private void FocusThisWindow()
        {
            string chatWindowToFocus = lblFromUserId.Text + "_" + lblToUserId.Text;

            if (Session["DefaultWindow"].ToString() == chatWindowToFocus)
            {
                form1.DefaultButton = "btnSend";
                form1.DefaultFocus = "txtMessage";
            }
        }

        #region ICallbackEventHandler Members

        string System.Web.UI.ICallbackEventHandler.GetCallbackResult()
        {
            return _callBackStatus;
        }

        void System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
        {
            if (!String.IsNullOrEmpty(eventArgument))
            {
                if (eventArgument == "FocusThisWindow")
                {
                    string chatWindowToFocus = lblFromUserId.Text + "_" + lblToUserId.Text;
                    Session["DefaultWindow"] = chatWindowToFocus;
                    this.FocusThisWindow();
                }
            }
        }

        #endregion
    }
}
