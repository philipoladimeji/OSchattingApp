
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[System.Data.Linq.Mapping.DatabaseAttribute(Name="LinqChat")]
public partial class LinqChatDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertLoggedInUser(LoggedInUser instance);
  partial void UpdateLoggedInUser(LoggedInUser instance);
  partial void DeleteLoggedInUser(LoggedInUser instance);
  partial void InsertMessage(Message instance);
  partial void UpdateMessage(Message instance);
  partial void DeleteMessage(Message instance);
  partial void InsertRoom(Room instance);
  partial void UpdateRoom(Room instance);
  partial void DeleteRoom(Room instance);
  partial void InsertUser(User instance);
  partial void UpdateUser(User instance);
  partial void DeleteUser(User instance);
  partial void InsertPrivateMessage(PrivateMessage instance);
  partial void UpdatePrivateMessage(PrivateMessage instance);
  partial void DeletePrivateMessage(PrivateMessage instance);
  #endregion
	
	public LinqChatDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["LinqChatConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public LinqChatDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public LinqChatDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public LinqChatDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public LinqChatDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<LoggedInUser> LoggedInUsers
	{
		get
		{
			return this.GetTable<LoggedInUser>();
		}
	}
	
	public System.Data.Linq.Table<Message> Messages
	{
		get
		{
			return this.GetTable<Message>();
		}
	}
	
	public System.Data.Linq.Table<Room> Rooms
	{
		get
		{
			return this.GetTable<Room>();
		}
	}
	
	public System.Data.Linq.Table<User> Users
	{
		get
		{
			return this.GetTable<User>();
		}
	}
	
	public System.Data.Linq.Table<PrivateMessage> PrivateMessages
	{
		get
		{
			return this.GetTable<PrivateMessage>();
		}
	}
}

[Table(Name="dbo.LoggedInUser")]
public partial class LoggedInUser : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _LoggedInUserID;
	
	private int _UserID;
	
	private int _RoomID;
	
	private EntityRef<Room> _Room;
	
	private EntityRef<User> _User;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLoggedInUserIDChanging(int value);
    partial void OnLoggedInUserIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnRoomIDChanging(int value);
    partial void OnRoomIDChanged();
    #endregion
	
	public LoggedInUser()
	{
		this._Room = default(EntityRef<Room>);
		this._User = default(EntityRef<User>);
		OnCreated();
	}
	
	[Column(Storage="_LoggedInUserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int LoggedInUserID
	{
		get
		{
			return this._LoggedInUserID;
		}
		set
		{
			if ((this._LoggedInUserID != value))
			{
				this.OnLoggedInUserIDChanging(value);
				this.SendPropertyChanging();
				this._LoggedInUserID = value;
				this.SendPropertyChanged("LoggedInUserID");
				this.OnLoggedInUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_UserID", DbType="Int NOT NULL")]
	public int UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				if (this._User.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_RoomID", DbType="Int NOT NULL")]
	public int RoomID
	{
		get
		{
			return this._RoomID;
		}
		set
		{
			if ((this._RoomID != value))
			{
				if (this._Room.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnRoomIDChanging(value);
				this.SendPropertyChanging();
				this._RoomID = value;
				this.SendPropertyChanged("RoomID");
				this.OnRoomIDChanged();
			}
		}
	}
	
	[Association(Name="Room_LoggedInUser", Storage="_Room", ThisKey="RoomID", IsForeignKey=true)]
	public Room Room
	{
		get
		{
			return this._Room.Entity;
		}
		set
		{
			Room previousValue = this._Room.Entity;
			if (((previousValue != value) 
						|| (this._Room.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Room.Entity = null;
					previousValue.LoggedInUsers.Remove(this);
				}
				this._Room.Entity = value;
				if ((value != null))
				{
					value.LoggedInUsers.Add(this);
					this._RoomID = value.RoomID;
				}
				else
				{
					this._RoomID = default(int);
				}
				this.SendPropertyChanged("Room");
			}
		}
	}
	
	[Association(Name="User_LoggedInUser", Storage="_User", ThisKey="UserID", IsForeignKey=true)]
	public User User
	{
		get
		{
			return this._User.Entity;
		}
		set
		{
			User previousValue = this._User.Entity;
			if (((previousValue != value) 
						|| (this._User.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User.Entity = null;
					previousValue.LoggedInUsers.Remove(this);
				}
				this._User.Entity = value;
				if ((value != null))
				{
					value.LoggedInUsers.Add(this);
					this._UserID = value.UserID;
				}
				else
				{
					this._UserID = default(int);
				}
				this.SendPropertyChanged("User");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="dbo.Message")]
public partial class Message : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _MessageID;
	
	private System.Nullable<int> _RoomID;
	
	private int _UserID;
	
	private System.Nullable<int> _ToUserID;
	
	private string _Text;
	
	private System.DateTime _TimeStamp;
	
	private string _Color;
	
	private EntityRef<Room> _Room;
	
	private EntityRef<User> _User;
	
	private EntityRef<User> _User1;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMessageIDChanging(int value);
    partial void OnMessageIDChanged();
    partial void OnRoomIDChanging(System.Nullable<int> value);
    partial void OnRoomIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnToUserIDChanging(System.Nullable<int> value);
    partial void OnToUserIDChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnTimeStampChanging(System.DateTime value);
    partial void OnTimeStampChanged();
    partial void OnColorChanging(string value);
    partial void OnColorChanged();
    #endregion
	
	public Message()
	{
		this._Room = default(EntityRef<Room>);
		this._User = default(EntityRef<User>);
		this._User1 = default(EntityRef<User>);
		OnCreated();
	}
	
	[Column(Storage="_MessageID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int MessageID
	{
		get
		{
			return this._MessageID;
		}
		set
		{
			if ((this._MessageID != value))
			{
				this.OnMessageIDChanging(value);
				this.SendPropertyChanging();
				this._MessageID = value;
				this.SendPropertyChanged("MessageID");
				this.OnMessageIDChanged();
			}
		}
	}
	
	[Column(Storage="_RoomID", DbType="Int")]
	public System.Nullable<int> RoomID
	{
		get
		{
			return this._RoomID;
		}
		set
		{
			if ((this._RoomID != value))
			{
				if (this._Room.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnRoomIDChanging(value);
				this.SendPropertyChanging();
				this._RoomID = value;
				this.SendPropertyChanged("RoomID");
				this.OnRoomIDChanged();
			}
		}
	}
	
	[Column(Storage="_UserID", DbType="Int NOT NULL")]
	public int UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				if (this._User.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_ToUserID", DbType="Int")]
	public System.Nullable<int> ToUserID
	{
		get
		{
			return this._ToUserID;
		}
		set
		{
			if ((this._ToUserID != value))
			{
				if (this._User1.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnToUserIDChanging(value);
				this.SendPropertyChanging();
				this._ToUserID = value;
				this.SendPropertyChanged("ToUserID");
				this.OnToUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_Text", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
	public string Text
	{
		get
		{
			return this._Text;
		}
		set
		{
			if ((this._Text != value))
			{
				this.OnTextChanging(value);
				this.SendPropertyChanging();
				this._Text = value;
				this.SendPropertyChanged("Text");
				this.OnTextChanged();
			}
		}
	}
	
	[Column(Storage="_TimeStamp", DbType="DateTime NOT NULL")]
	public System.DateTime TimeStamp
	{
		get
		{
			return this._TimeStamp;
		}
		set
		{
			if ((this._TimeStamp != value))
			{
				this.OnTimeStampChanging(value);
				this.SendPropertyChanging();
				this._TimeStamp = value;
				this.SendPropertyChanged("TimeStamp");
				this.OnTimeStampChanged();
			}
		}
	}
	
	[Column(Storage="_Color", DbType="VarChar(50)")]
	public string Color
	{
		get
		{
			return this._Color;
		}
		set
		{
			if ((this._Color != value))
			{
				this.OnColorChanging(value);
				this.SendPropertyChanging();
				this._Color = value;
				this.SendPropertyChanged("Color");
				this.OnColorChanged();
			}
		}
	}
	
	[Association(Name="Room_Message", Storage="_Room", ThisKey="RoomID", IsForeignKey=true)]
	public Room Room
	{
		get
		{
			return this._Room.Entity;
		}
		set
		{
			Room previousValue = this._Room.Entity;
			if (((previousValue != value) 
						|| (this._Room.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Room.Entity = null;
					previousValue.Messages.Remove(this);
				}
				this._Room.Entity = value;
				if ((value != null))
				{
					value.Messages.Add(this);
					this._RoomID = value.RoomID;
				}
				else
				{
					this._RoomID = default(Nullable<int>);
				}
				this.SendPropertyChanged("Room");
			}
		}
	}
	
	[Association(Name="User_Message", Storage="_User", ThisKey="UserID", IsForeignKey=true)]
	public User User
	{
		get
		{
			return this._User.Entity;
		}
		set
		{
			User previousValue = this._User.Entity;
			if (((previousValue != value) 
						|| (this._User.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User.Entity = null;
					previousValue.Messages.Remove(this);
				}
				this._User.Entity = value;
				if ((value != null))
				{
					value.Messages.Add(this);
					this._UserID = value.UserID;
				}
				else
				{
					this._UserID = default(int);
				}
				this.SendPropertyChanged("User");
			}
		}
	}
	
	[Association(Name="User_Message1", Storage="_User1", ThisKey="ToUserID", IsForeignKey=true)]
	public User User1
	{
		get
		{
			return this._User1.Entity;
		}
		set
		{
			User previousValue = this._User1.Entity;
			if (((previousValue != value) 
						|| (this._User1.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User1.Entity = null;
					previousValue.Messages1.Remove(this);
				}
				this._User1.Entity = value;
				if ((value != null))
				{
					value.Messages1.Add(this);
					this._ToUserID = value.UserID;
				}
				else
				{
					this._ToUserID = default(Nullable<int>);
				}
				this.SendPropertyChanged("User1");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="dbo.Room")]
public partial class Room : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _RoomID;
	
	private string _Name;
	
	private EntitySet<LoggedInUser> _LoggedInUsers;
	
	private EntitySet<Message> _Messages;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRoomIDChanging(int value);
    partial void OnRoomIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
	
	public Room()
	{
		this._LoggedInUsers = new EntitySet<LoggedInUser>(new Action<LoggedInUser>(this.attach_LoggedInUsers), new Action<LoggedInUser>(this.detach_LoggedInUsers));
		this._Messages = new EntitySet<Message>(new Action<Message>(this.attach_Messages), new Action<Message>(this.detach_Messages));
		OnCreated();
	}
	
	[Column(Storage="_RoomID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int RoomID
	{
		get
		{
			return this._RoomID;
		}
		set
		{
			if ((this._RoomID != value))
			{
				this.OnRoomIDChanging(value);
				this.SendPropertyChanging();
				this._RoomID = value;
				this.SendPropertyChanged("RoomID");
				this.OnRoomIDChanged();
			}
		}
	}
	
	[Column(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[Association(Name="Room_LoggedInUser", Storage="_LoggedInUsers", OtherKey="RoomID")]
	public EntitySet<LoggedInUser> LoggedInUsers
	{
		get
		{
			return this._LoggedInUsers;
		}
		set
		{
			this._LoggedInUsers.Assign(value);
		}
	}
	
	[Association(Name="Room_Message", Storage="_Messages", OtherKey="RoomID")]
	public EntitySet<Message> Messages
	{
		get
		{
			return this._Messages;
		}
		set
		{
			this._Messages.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_LoggedInUsers(LoggedInUser entity)
	{
		this.SendPropertyChanging();
		entity.Room = this;
	}
	
	private void detach_LoggedInUsers(LoggedInUser entity)
	{
		this.SendPropertyChanging();
		entity.Room = null;
	}
	
	private void attach_Messages(Message entity)
	{
		this.SendPropertyChanging();
		entity.Room = this;
	}
	
	private void detach_Messages(Message entity)
	{
		this.SendPropertyChanging();
		entity.Room = null;
	}
}

[Table(Name="dbo.[User]")]
public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _UserID;
	
	private string _Firstname;
	
	private string _Lastname;
	
	private string _Username;
	
	private string _Password;
	
	private char _Sex;
	
	private EntitySet<LoggedInUser> _LoggedInUsers;
	
	private EntitySet<Message> _Messages;
	
	private EntitySet<Message> _Messages1;
	
	private EntitySet<PrivateMessage> _PrivateMessages;
	
	private EntitySet<PrivateMessage> _PrivateMessages1;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnFirstnameChanging(string value);
    partial void OnFirstnameChanged();
    partial void OnLastnameChanging(string value);
    partial void OnLastnameChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnSexChanging(char value);
    partial void OnSexChanged();
    #endregion
	
	public User()
	{
		this._LoggedInUsers = new EntitySet<LoggedInUser>(new Action<LoggedInUser>(this.attach_LoggedInUsers), new Action<LoggedInUser>(this.detach_LoggedInUsers));
		this._Messages = new EntitySet<Message>(new Action<Message>(this.attach_Messages), new Action<Message>(this.detach_Messages));
		this._Messages1 = new EntitySet<Message>(new Action<Message>(this.attach_Messages1), new Action<Message>(this.detach_Messages1));
		this._PrivateMessages = new EntitySet<PrivateMessage>(new Action<PrivateMessage>(this.attach_PrivateMessages), new Action<PrivateMessage>(this.detach_PrivateMessages));
		this._PrivateMessages1 = new EntitySet<PrivateMessage>(new Action<PrivateMessage>(this.attach_PrivateMessages1), new Action<PrivateMessage>(this.detach_PrivateMessages1));
		OnCreated();
	}
	
	[Column(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_Firstname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
	public string Firstname
	{
		get
		{
			return this._Firstname;
		}
		set
		{
			if ((this._Firstname != value))
			{
				this.OnFirstnameChanging(value);
				this.SendPropertyChanging();
				this._Firstname = value;
				this.SendPropertyChanged("Firstname");
				this.OnFirstnameChanged();
			}
		}
	}
	
	[Column(Storage="_Lastname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
	public string Lastname
	{
		get
		{
			return this._Lastname;
		}
		set
		{
			if ((this._Lastname != value))
			{
				this.OnLastnameChanging(value);
				this.SendPropertyChanging();
				this._Lastname = value;
				this.SendPropertyChanged("Lastname");
				this.OnLastnameChanged();
			}
		}
	}
	
	[Column(Storage="_Username", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
	public string Username
	{
		get
		{
			return this._Username;
		}
		set
		{
			if ((this._Username != value))
			{
				this.OnUsernameChanging(value);
				this.SendPropertyChanging();
				this._Username = value;
				this.SendPropertyChanged("Username");
				this.OnUsernameChanged();
			}
		}
	}
	
	[Column(Storage="_Password", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[Column(Storage="_Sex", DbType="VarChar(1) NOT NULL")]
	public char Sex
	{
		get
		{
			return this._Sex;
		}
		set
		{
			if ((this._Sex != value))
			{
				this.OnSexChanging(value);
				this.SendPropertyChanging();
				this._Sex = value;
				this.SendPropertyChanged("Sex");
				this.OnSexChanged();
			}
		}
	}
	
	[Association(Name="User_LoggedInUser", Storage="_LoggedInUsers", OtherKey="UserID")]
	public EntitySet<LoggedInUser> LoggedInUsers
	{
		get
		{
			return this._LoggedInUsers;
		}
		set
		{
			this._LoggedInUsers.Assign(value);
		}
	}
	
	[Association(Name="User_Message", Storage="_Messages", OtherKey="UserID")]
	public EntitySet<Message> Messages
	{
		get
		{
			return this._Messages;
		}
		set
		{
			this._Messages.Assign(value);
		}
	}
	
	[Association(Name="User_Message1", Storage="_Messages1", OtherKey="ToUserID")]
	public EntitySet<Message> Messages1
	{
		get
		{
			return this._Messages1;
		}
		set
		{
			this._Messages1.Assign(value);
		}
	}
	
	[Association(Name="User_PrivateMessage", Storage="_PrivateMessages", OtherKey="UserID")]
	public EntitySet<PrivateMessage> PrivateMessages
	{
		get
		{
			return this._PrivateMessages;
		}
		set
		{
			this._PrivateMessages.Assign(value);
		}
	}
	
	[Association(Name="User_PrivateMessage1", Storage="_PrivateMessages1", OtherKey="ToUserID")]
	public EntitySet<PrivateMessage> PrivateMessages1
	{
		get
		{
			return this._PrivateMessages1;
		}
		set
		{
			this._PrivateMessages1.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_LoggedInUsers(LoggedInUser entity)
	{
		this.SendPropertyChanging();
		entity.User = this;
	}
	
	private void detach_LoggedInUsers(LoggedInUser entity)
	{
		this.SendPropertyChanging();
		entity.User = null;
	}
	
	private void attach_Messages(Message entity)
	{
		this.SendPropertyChanging();
		entity.User = this;
	}
	
	private void detach_Messages(Message entity)
	{
		this.SendPropertyChanging();
		entity.User = null;
	}
	
	private void attach_Messages1(Message entity)
	{
		this.SendPropertyChanging();
		entity.User1 = this;
	}
	
	private void detach_Messages1(Message entity)
	{
		this.SendPropertyChanging();
		entity.User1 = null;
	}
	
	private void attach_PrivateMessages(PrivateMessage entity)
	{
		this.SendPropertyChanging();
		entity.User = this;
	}
	
	private void detach_PrivateMessages(PrivateMessage entity)
	{
		this.SendPropertyChanging();
		entity.User = null;
	}
	
	private void attach_PrivateMessages1(PrivateMessage entity)
	{
		this.SendPropertyChanging();
		entity.User1 = this;
	}
	
	private void detach_PrivateMessages1(PrivateMessage entity)
	{
		this.SendPropertyChanging();
		entity.User1 = null;
	}
}

[Table(Name="dbo.PrivateMessage")]
public partial class PrivateMessage : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _PrivateMessageID;
	
	private int _UserID;
	
	private int _ToUserID;
	
	private EntityRef<User> _User;
	
	private EntityRef<User> _User1;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPrivateMessageIDChanging(int value);
    partial void OnPrivateMessageIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnToUserIDChanging(int value);
    partial void OnToUserIDChanged();
    #endregion
	
	public PrivateMessage()
	{
		this._User = default(EntityRef<User>);
		this._User1 = default(EntityRef<User>);
		OnCreated();
	}
	
	[Column(Storage="_PrivateMessageID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int PrivateMessageID
	{
		get
		{
			return this._PrivateMessageID;
		}
		set
		{
			if ((this._PrivateMessageID != value))
			{
				this.OnPrivateMessageIDChanging(value);
				this.SendPropertyChanging();
				this._PrivateMessageID = value;
				this.SendPropertyChanged("PrivateMessageID");
				this.OnPrivateMessageIDChanged();
			}
		}
	}
	
	[Column(Storage="_UserID", DbType="Int NOT NULL")]
	public int UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				if (this._User.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[Column(Storage="_ToUserID", DbType="Int NOT NULL")]
	public int ToUserID
	{
		get
		{
			return this._ToUserID;
		}
		set
		{
			if ((this._ToUserID != value))
			{
				if (this._User1.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnToUserIDChanging(value);
				this.SendPropertyChanging();
				this._ToUserID = value;
				this.SendPropertyChanged("ToUserID");
				this.OnToUserIDChanged();
			}
		}
	}
	
	[Association(Name="User_PrivateMessage", Storage="_User", ThisKey="UserID", IsForeignKey=true)]
	public User User
	{
		get
		{
			return this._User.Entity;
		}
		set
		{
			User previousValue = this._User.Entity;
			if (((previousValue != value) 
						|| (this._User.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User.Entity = null;
					previousValue.PrivateMessages.Remove(this);
				}
				this._User.Entity = value;
				if ((value != null))
				{
					value.PrivateMessages.Add(this);
					this._UserID = value.UserID;
				}
				else
				{
					this._UserID = default(int);
				}
				this.SendPropertyChanged("User");
			}
		}
	}
	
	[Association(Name="User_PrivateMessage1", Storage="_User1", ThisKey="ToUserID", IsForeignKey=true)]
	public User User1
	{
		get
		{
			return this._User1.Entity;
		}
		set
		{
			User previousValue = this._User1.Entity;
			if (((previousValue != value) 
						|| (this._User1.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User1.Entity = null;
					previousValue.PrivateMessages1.Remove(this);
				}
				this._User1.Entity = value;
				if ((value != null))
				{
					value.PrivateMessages1.Add(this);
					this._ToUserID = value.UserID;
				}
				else
				{
					this._ToUserID = default(int);
				}
				this.SendPropertyChanged("User1");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

