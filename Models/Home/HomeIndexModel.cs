using Online_Shopping.DataModel;
using Online_Shopping.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models.Home
{
    public class HomeIndexModel 
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        db_WoodWiseEntities context = new db_WoodWiseEntities();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }
        public HomeIndexModel CreateModel(string search, int pageSize, int? page)
        {
            SqlParameter[] param = new SqlParameter[] {
                   new SqlParameter("@search",search??(object)DBNull.Value)
                   };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new HomeIndexModel
            {
                ListOfProducts = data
            };
        }
    }
}