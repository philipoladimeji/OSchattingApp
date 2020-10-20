<%@ Language="C#" "CodeFile="ChatWindow.aspx.cs"%>

<!DOCTYPE html PUBLIC "Transitional">

<head id="Head1" runat="server">
    <title>Private Chat</title>
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
<body style="background-color: gainsboro; margin: 0 0 0 0;" onload="SetScrollPosition()">
    <form id="form1" runat="server" >
    <div>
        <asp:Label Id="lblFromUserId" Visible="false" runat="server" />
        <asp:Label Id="lblToUserId" Visible="false" runat="server" />
        <asp:Label Id="lblFromUsername" Visible="false" runat="server" />
        <asp:Label Id="lblMessageSent" Visible="false" runat="server" />
        <asp:ScriptManager Id="ScriptManager1" runat="server" />
        
        <asp:UpdatePanel Id="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlId="Timer1" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer Id="Timer1" Interval="7000" OnTick="Timer1_OnTick" runat="server" />
                <div id="divMessages" style="background-color: White; border-color:Black;border-width:1px;border-style:solid;height:160px;width:388px;overflow-y:scroll; font-size: 11px; padding: 4px 4px 4px 4px;" onresize="SetScrollPosition()">
                    <asp:Literal Id="litMessages" runat="server" />
                </div>  
                <asp:TextBox Id="txtMessage" onkeyup="ReplaceChars()" onclick="FocusMe()" onfocus="SetToEnd(this)" runat="server" Width="340px" />
                <asp:Button Id="btnSend" runat="server" Text="Send" OnClientClick="SetScrollPosition()" OnClick="BtnSend_Click" />           
            </ContentTemplate>
        </asp:UpdatePanel>  
    </div>
    </form>
</body>
</html>
