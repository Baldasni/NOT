using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NOT.Models;
using Dapper;


//Esempio

//var lookup = new Dictionary<int, OrderDetail>();
//var lookup2 = new Dictionary<int, OrderLine>();
//connection.Query<OrderDetail, OrderLine, OrderLineSize, OrderDetail>(@"
//                    SELECT o.*, ol.*, ols.*
//                    FROM orders_mstr o
//                    INNER JOIN order_lines ol ON o.id = ol.order_id
//                    INNER JOIN order_line_size_relations ols ON ol.id = ols.order_line_id           
//                    ", (o, ol, ols) =>
//{
//    OrderDetail orderDetail;
//    if (!lookup.TryGetValue(o.id, out orderDetail))
//    {
//        lookup.Add(o.id, orderDetail = o);
//    }
//    OrderLine orderLine;
//    if (!lookup2.TryGetValue(ol.id, out orderLine))
//    {
//        lookup2.Add(ol.id, orderLine = ol);
//        orderDetail.OrderLines.Add(orderLine);
//    }
//    orderLine.OrderLineSizes.Add(ols);
//    return orderDetail;
//}).AsQueryable();

//var resultList = lookup.Values.ToList();


namespace NOT.Repository
{
    //public class UserListViewModel
    //{
    //    public IdentityUser UtenteCorrente { get; set; }
    //    public IList<AspNetUser> ListaUtenti
    //    {
    //        get
    //        {
    //            NotDBEntities notDBEntities = new NotDBEntities();
    //            return notDBEntities.AspNetUsers.ToList<AspNetUser>();
    //        }
    //    }
    //            //set; }
    //    public IList<IdentityRole> ListaRuoli { get; set; }
    //}

    public class AspNetUserRepository: BaseRepository
    {
        ////private IDbConnection _con;
        //private SqlConnection _con;

        ////To Handle connection related activities
        //private void Connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //    _con = new SqlConnection(constr);
        //}

        //public void Open()
        //{
        //    _con.Open();
        //}

        //public void Dispose()
        //{
        //    _con.Close();
        //}

        //To Add AspNetUser details
        public static void AddAspNetUser(AspNetUser objAspNetUser)
        {
            //Additing the AspNetUser
            //try
            //{
                //Connection();
                //Open();
                //_con.
                Execute("AddNewAspNetUserDetails", objAspNetUser, commandType: CommandType.StoredProcedure);
                //Dispose();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

//        public EditUtenteViewModel getEditUtente(string idUtente)
//        {
//            return Query<EditUtenteViewModel>(
//@"select U.Id as UserID, U.UserName, U.Email, E.Name as Ruolo from [dbo].[AspNetUsers] U 
//    left join [dbo].[AspNetUserRoles] UR on U.id = UR.UserId 
//    left join [dbo].[AspNetRoles] R on UR.RoleId = R.Id 
//   WHERE U.id = @id ", new { id = idUtente }).FirstOrDefault();
//        }

        public static List<AspNetUser> GetListaUtenti()
        {
            //try
            //{
            //    Connection();
            //    Open();

            //U.Id as UserID, U.UserName, U.Email, E.Name as Ruolo
            var lookup = new Dictionary<string, AspNetUser>();
            Query<AspNetUser, AspNetRole, AspNetUser>(
@"select  U.*, R.*
    from [dbo].[AspNetUsers] U 
    left join [dbo].[AspNetUserRoles] UR on U.id = UR.UserId 
    left join [dbo].[AspNetRoles] R on UR.RoleId = R.Id"
                    , (u, r) =>
                    {
                        AspNetUser user;
                        if (!lookup.TryGetValue(u.Id, out user))
                        {
                            lookup.Add(u.Id, user = u);
                        }

                        user.AspNetRoles.Add(r);
                        return user;
                    }).AsQueryable();



            //    Dispose();

                return lookup.Values.ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        //To view AspNetUser details with generic list 
        //public List<AspNetUser> GetAllAspNetUsers()
        //{
        //    //try
        //    //{
        //    //    Connection();
        //    //    Open();
        //        IList<AspNetUser> AspNetUserList = Query<AspNetUser>("GetUsers").ToList();
        //        //Dispose();
        //        return AspNetUserList.ToList();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    throw;
        //    //}
        //}

        //To Update AspNetUser details
        public static int UpdateAspNetUser(AspNetUser objUpdate)
        {
            //try
            //{
            //    Connection();
            //    Open();
                return Execute("UpdateAspNetUserDetails", objUpdate, commandType: CommandType.StoredProcedure);
            //    Dispose();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        //To delete AspNetUser details
        public static bool DeleteAspNetUser(string Id)
        {
            //try
            //{
                DynamicParameters param = new DynamicParameters();
                param.Add("@AspNetUserId", Id);
                //Connection();
                //Open();
                int ret = Execute("DeleteAspNetUserById", param, commandType: CommandType.StoredProcedure);
            //Dispose();
            return ret == 1 ? true : false;
        //}
        //    catch (Exception ex)
        //    {
        //        //Log error as per your need 
        //        throw ex;
        //    }
        }
    }
}