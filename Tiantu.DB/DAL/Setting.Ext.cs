using Dapper;
using DapperExtensions;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantu.DB.DBUtility;

namespace Tiantu.DB.DAL
{
    public partial class Setting
    {
        public const string key_logo = "key_logo";
        public const string key_copyright = "key_copyright";
        public const string key_copyright_en = "key_copyright_en";

        public const string key_instructions_note = "key_instructions_note";
        public const string key_instructions_pdf = "key_instructions_pdf";
        public const string key_instructions_note_en = "key_instructions_note_en";
        public const string key_instructions_pdf_en = "key_instructions_pdf_en";

        public const string key_filterword = "key_filterword";




        /// <summary>
        /// 得到值
        /// </summary>
        public string GetValue(string key)
        {
            Tiantu.DB.Model.Setting model = GetModel(key);
            return model != null ? model.SETVALUE : "";
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool SetValue(string key, string value)
        {
            Tiantu.DB.Model.Setting model = new Tiantu.DB.Model.Setting();
            model.SETKEY = key;
            model.SETVALUE = value;
            if (Exists(key))
            {
                return Update(model);
            }
            else
            {
                return Add(model) > 0;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        private bool Exists(string SETKEY)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Setting");
            strSql.Append(" where SETKEY=@SETKEY ");
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int result = cn.QuerySingle<int>(strSql.ToString(), new { SETKEY = SETKEY });
                cn.Close();
                return result > 0;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        private int Add(Tiantu.DB.Model.Setting model)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                int id = cn.Insert(model);
                cn.Close();
                return id;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        private bool Update(Tiantu.DB.Model.Setting model)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                Tiantu.DB.Model.Setting modelA = GetModel(model.SETKEY);
                modelA.SETVALUE = model.SETVALUE;
                bool result = cn.Update(modelA);
                cn.Close();
                return result;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        private Tiantu.DB.Model.Setting GetModel(string SETKEY)
        {
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                var predicate = Predicates.Field<Tiantu.DB.Model.Setting>(f => f.SETKEY, Operator.Eq, SETKEY);
                var list = cn.GetList<Tiantu.DB.Model.Setting>(predicate);
                Tiantu.DB.Model.Setting model = list.ToList().Count != 0 ? list.First() : null;
                cn.Close();
                return model;
            }
        }





    }
}
