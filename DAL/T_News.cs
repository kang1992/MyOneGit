/**  版本信息模板在安装目录下，可自行修改。
* T_News.cs
*
* 功 能： N/A
* 类 名： T_News
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/3 14:26:34   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace 第三学期三层构架_新闻管理_.DAL
{
	/// <summary>
	/// 数据访问类:T_News
	/// </summary>
	public partial class T_News
	{
		public T_News()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "T_News"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_News");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(第三学期三层构架_新闻管理_.Model.T_News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_News(");
			strSql.Append("NewsTitle,NewsContent,NewsCreator,CreateTime,ClassId)");
			strSql.Append(" values (");
			strSql.Append("@NewsTitle,@NewsContent,@NewsCreator,@CreateTime,@ClassId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,64),
					new SqlParameter("@NewsContent", SqlDbType.VarChar,-1),
					new SqlParameter("@NewsCreator", SqlDbType.VarChar,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.NewsContent;
			parameters[2].Value = model.NewsCreator;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = Guid.NewGuid();

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(第三学期三层构架_新闻管理_.Model.T_News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_News set ");
			strSql.Append("NewsTitle=@NewsTitle,");
			strSql.Append("NewsContent=@NewsContent,");
			strSql.Append("NewsCreator=@NewsCreator,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("ClassId=@ClassId");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsTitle", SqlDbType.VarChar,64),
					new SqlParameter("@NewsContent", SqlDbType.VarChar,-1),
					new SqlParameter("@NewsCreator", SqlDbType.VarChar,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ClassId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.NewsTitle;
			parameters[1].Value = model.NewsContent;
			parameters[2].Value = model.NewsCreator;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.ClassId;
			parameters[5].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_News ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_News ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public 第三学期三层构架_新闻管理_.Model.T_News GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,NewsTitle,NewsContent,NewsCreator,CreateTime,ClassId from T_News ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			第三学期三层构架_新闻管理_.Model.T_News model=new 第三学期三层构架_新闻管理_.Model.T_News();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public 第三学期三层构架_新闻管理_.Model.T_News DataRowToModel(DataRow row)
		{
			第三学期三层构架_新闻管理_.Model.T_News model=new 第三学期三层构架_新闻管理_.Model.T_News();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["NewsTitle"]!=null)
				{
					model.NewsTitle=row["NewsTitle"].ToString();
				}
				if(row["NewsContent"]!=null)
				{
					model.NewsContent=row["NewsContent"].ToString();
				}
				if(row["NewsCreator"]!=null)
				{
					model.NewsCreator=row["NewsCreator"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId= new Guid(row["ClassId"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,NewsTitle,NewsContent,NewsCreator,CreateTime,ClassId ");
			strSql.Append(" FROM T_News ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,NewsTitle,NewsContent,NewsCreator,CreateTime,ClassId ");
			strSql.Append(" FROM T_News ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_News ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from T_News T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_News";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        //分页获取新闻表内容并join
         string paixu = null;
         public DataSet selectNew(int i,out int pagesize)
        {
            string cmdstring = "select T1.indexs,T1.NewsTitle,SUBSTRING(T1.NewsContent,0,20)+'......' AS NewsContent,T2.RealName,T3.ClassName,T1.CreateTime from (select ROW_NUMBER() over(order by Id) as indexs,* from T_News1 ) AS T1 join T_User AS T2 on T1.NewsCreator=T2.UserId join T_NewsClass AS T3 on T1.ClassId=T3.ClassId where T1.indexs between (@pageindex-1) * @pagesize + 1 and @pageindex * @pagesize";
            cmdstring = cmdstring + paixu;

            SqlParameter[] sp = new SqlParameter[]{
              new SqlParameter("@pageSize", 10),
              new SqlParameter("@pageIndex",SqlDbType.Int)
            };
            sp[1].Value = i;

            int size = DbHelperSQL.ExecuteSql("select * from T_News1");
            pagesize = size / 10;

           return DbHelperSQL.Query(cmdstring, sp);

        }
		#endregion  ExtensionMethod
	}
}

