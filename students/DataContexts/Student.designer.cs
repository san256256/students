﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace students.DataContexts
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="peregoncevKP")]
	public partial class StudentDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertStudents(Students instance);
    partial void UpdateStudents(Students instance);
    partial void DeleteStudents(Students instance);
    #endregion
		
		public StudentDataContext() : 
				base(global::students.Properties.Settings.Default.peregoncevKPConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StudentDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Students> Students
		{
			get
			{
				return this.GetTable<Students>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Students")]
	public partial class Students : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FullName;
		
		private string _Male;
		
		private System.Nullable<int> _Course;
		
		private System.Nullable<int> _RecordBookNum;
		
		private string _Group;
		
		private string _EducationForm;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnMaleChanging(string value);
    partial void OnMaleChanged();
    partial void OnCourseChanging(System.Nullable<int> value);
    partial void OnCourseChanged();
    partial void OnRecordBookNumChanging(System.Nullable<int> value);
    partial void OnRecordBookNumChanged();
    partial void OnGroupChanging(string value);
    partial void OnGroupChanged();
    partial void OnEducationFormChanging(string value);
    partial void OnEducationFormChanged();
    #endregion
		
		public Students()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="VarChar(50)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Male", DbType="VarChar(50)")]
		public string Male
		{
			get
			{
				return this._Male;
			}
			set
			{
				if ((this._Male != value))
				{
					this.OnMaleChanging(value);
					this.SendPropertyChanging();
					this._Male = value;
					this.SendPropertyChanged("Male");
					this.OnMaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Course", DbType="Int")]
		public System.Nullable<int> Course
		{
			get
			{
				return this._Course;
			}
			set
			{
				if ((this._Course != value))
				{
					this.OnCourseChanging(value);
					this.SendPropertyChanging();
					this._Course = value;
					this.SendPropertyChanged("Course");
					this.OnCourseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecordBookNum", DbType="Int")]
		public System.Nullable<int> RecordBookNum
		{
			get
			{
				return this._RecordBookNum;
			}
			set
			{
				if ((this._RecordBookNum != value))
				{
					this.OnRecordBookNumChanging(value);
					this.SendPropertyChanging();
					this._RecordBookNum = value;
					this.SendPropertyChanged("RecordBookNum");
					this.OnRecordBookNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Group]", Storage="_Group", DbType="VarChar(10)")]
		public string Group
		{
			get
			{
				return this._Group;
			}
			set
			{
				if ((this._Group != value))
				{
					this.OnGroupChanging(value);
					this.SendPropertyChanging();
					this._Group = value;
					this.SendPropertyChanged("Group");
					this.OnGroupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EducationForm", DbType="VarChar(50)")]
		public string EducationForm
		{
			get
			{
				return this._EducationForm;
			}
			set
			{
				if ((this._EducationForm != value))
				{
					this.OnEducationFormChanging(value);
					this.SendPropertyChanging();
					this._EducationForm = value;
					this.SendPropertyChanged("EducationForm");
					this.OnEducationFormChanged();
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
}
#pragma warning restore 1591