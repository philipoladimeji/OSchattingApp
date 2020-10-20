<%@ Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "Transitional//EN">

<head id="Head1" runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
            onloggedin="Login1_LoggedIn" />
    </div>
    </form>
</body>
</html>
    


