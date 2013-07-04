/**  版本信息模板在安装目录下，可自行修改。
* T_NewsClass.cs
*
* 功 能： N/A
* 类 名： T_NewsClass
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/3 14:26:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace 第三学期三层构架_新闻管理_.Model
{
	/// <summary>
	/// T_NewsClass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_NewsClass
	{
		public T_NewsClass()
		{}
		#region Model
		private int _id;
		private Guid _classid;
		private string _classname;
		private string _classcreator;
		private DateTime _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类别编号
		/// </summary>
		public Guid ClassId
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 创建者
		/// </summary>
		public string ClassCreator
		{
			set{ _classcreator=value;}
			get{return _classcreator;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

