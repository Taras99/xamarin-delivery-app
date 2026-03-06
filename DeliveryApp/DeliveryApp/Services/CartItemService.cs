using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DeliveryApp.Services
{
    public class CartItemService
    {
        private readonly ISQLite _sqliteProvider;

        public CartItemService() { }

        public CartItemService(ISQLite sqliteProvider)
        {
            _sqliteProvider = sqliteProvider;
        }

        private SQLite.SQLiteConnection GetConnection()
        {
            return _sqliteProvider != null
                ? _sqliteProvider.GetConnection()
                : DependencyService.Get<ISQLite>().GetConnection();
        }

        public int GetUserCartCount()
        {
            var cn = GetConnection();
            var count = cn.Table<CartItem>().Count();
            cn.Close();
            return count;
        }

        public void RemoveItemsFromCart()
        {
            var cn = GetConnection();
            cn.DeleteAll<CartItem>();
            cn.Commit();
            cn.Close();
        }
    }
}
