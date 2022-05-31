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
	public partial class ExamDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertExams(Exams instance);
    partial void UpdateExams(Exams instance);
    partial void DeleteExams(Exams instance);
    #endregion
		
		public ExamDataContext() : 
				base(global::students.Properties.Settings.Default.peregoncevKPConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public ExamDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExamDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExamDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExamDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Exams> Exams
		{
			get
			{
				return this.GetTable<Exams>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Exams")]
	public partial class Exams : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<System.DateTime> _Date;
		
		private string _Name;
		
		private string _Teacher;
		
		private System.Nullable<int> _StudentId;
		
		private System.Nullable<int> _Score;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTeacherChanging(string value);
    partial void OnTeacherChanged();
    partial void OnStudentIdChanging(System.Nullable<int> value);
    partial void OnStudentIdChanged();
    partial void OnScoreChanging(System.Nullable<int> value);
    partial void OnScoreChanged();
    #endregion
		
		public Exams()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Teacher", DbType="NVarChar(50)")]
		public string Teacher
		{
			get
			{
				return this._Teacher;
			}
			set
			{
				if ((this._Teacher != value))
				{
					this.OnTeacherChanging(value);
					this.SendPropertyChanging();
					this._Teacher = value;
					this.SendPropertyChanged("Teacher");
					this.OnTeacherChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StudentId", DbType="Int")]
		public System.Nullable<int> StudentId
		{
			get
			{
				return this._StudentId;
			}
			set
			{
				if ((this._StudentId != value))
				{
					this.OnStudentIdChanging(value);
					this.SendPropertyChanging();
					this._StudentId = value;
					this.SendPropertyChanged("StudentId");
					this.OnStudentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Score", DbType="Int")]
		public System.Nullable<int> Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				if ((this._Score != value))
				{
					this.OnScoreChanging(value);
					this.SendPropertyChanging();
					this._Score = value;
					this.SendPropertyChanged("Score");
					this.OnScoreChanged();
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