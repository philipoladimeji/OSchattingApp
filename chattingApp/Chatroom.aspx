<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chatroom.aspx.cs" Inherits="LinqChat.Chatroom" Theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LINQ Chatroom</title>
    <script type="text/javascript">       
        function SetScrollPosition()
        {
            var div = document.getElementById('divMessages');
            div.scrollTop = 100000000000;
        }
        
        function SetToEnd(txtMessage)
        {                    
            if (txtMessage.createTextRange)
            {
                var fieldRange = txtMessage.createTextRange();
                fieldRange.moveStart('character', txtMessage.value.length);
                fieldRange.collapse();
                fieldRange.select();
            }
        }
               
        function ReplaceChars() 
        {
            var txt = document.getElementById('txtMessage').value;
            var out = "<"; // replace this
            var add = ""; // with this
            var temp = "" + txt; // temporary holder

            while (temp.indexOf(out)>-1) 
            {
                pos= temp.indexOf(out);
                temp = "" + (temp.substring(0, pos) + add + 
                temp.substring((pos + out.length), temp.length));
            }
            
            document.getElementById('txtMessage').value = temp;
        }
        
        function LogOutUser(result, context)
        {
            // don't do anything here
        }
        
        function LogMeOut()
        {
            LogOutUserCallBack('LogOut');   
        }
        
        function FocusThisWindow(result, context)
        {
            // don't do anything here
        }
        
        function FocusMe()
        {
            FocusThisWindowCallBack('FocusThisWindow');   
        }
    </script>
</head>
<body style="background-color: gainsboro;" onload="SetScrollPosition()" onunload="LogMeOut()">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager Id="ScriptManager1" runat="server" />
        <asp:Label Id="lblRoomName" Font-Size="18px" runat="server" /><br /><br />
        <asp:Label Id="lblRoomId" Visible="false" runat="server" />
        <asp:UpdatePanel Id="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlId="Timer1" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer Id="Timer1" Interval="7000" OnTick="Timer1_OnTick" runat="server" />
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 500px;">
                            <div id="divMessages" style="background-color: White; border-color:Black;border-width:1px;border-style:solid;height:300px;width:592px;overflow-y:scroll; font-size: 11px; padding: 4px 4px 4px 4px;" onresize="SetScrollPosition()">
                                <asp:Literal Id="litMessages" runat="server" />
                            </div>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <div id="divUsers" style="background-color: White; border-color:Black;border-width:1px;border-style:solid;height:300px;width:150px;overflow-y:scroll; font-size: 11px;  padding: 4px 4px 4px 4px;">
                               <asp:Literal Id="litUsers" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="0px;">
                            <asp:Panel Id="pnlChatNow" Visible="false" CssClass="chatNowPanel" runat="server">
                                <div class="chatNowPanelTitle">Private Message</div>
                                <br /><asp:Label Id="lblChatNowUser" Text="MyGoodFellow" runat="server" />
                                <br />wants to chat with you.<br /><br />
                                 <asp:Button Id="btnChatNow" Text="Chat Now" CausesValidation="false" runat="server" OnClick="BtnChatNow_Click" />
                                 <asp:Button Id="btnCancel" Text="Cancel" CausesValidation="false" runat="server" OnClick="BtnCancel_Click" />
                            </asp:Panel>  
                        </td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox Id="txtMessage" onkeyup="ReplaceChars()" onclick="FocusMe()" onfocus="SetToEnd(this)" runat="server" MaxLength="100" Width="500px" />
                            <asp:Button Id="btnSend" runat="server" Text="Send" OnClientClick="SetScrollPosition()" OnClick="BtnSend_Click" />
                            &nbsp;
                            <b>Color:</b> <asp:DropDownList Id="ddlColor" runat="server">
                                <asp:ListItem Value="Black" Selected="true">Black</asp:ListItem>
                                <asp:ListItem Value="Blue">Blue</asp:ListItem>
                                <asp:ListItem Value="Navy">Navy</asp:ListItem>
                                <asp:ListItem Value="Red">Red</asp:ListItem>
                                <asp:ListItem Value="Orange">Orange</asp:ListItem>
                                <asp:ListItem Value="#666666">Gray</asp:ListItem>
                                <asp:ListItem Value="Green">Green</asp:ListItem>
                                <asp:ListItem Value="#FF00FF">Pink</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Button Id="btnLogOut" Text="Log Out" runat="server" OnClick="BtnLogOut_Click" />
                        </td>
                    </tr>
                </table>                
            </ContentTemplate>
        </asp:UpdatePanel> 
    </div>
    </form>
</body>
</html>
