using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class NorthwindController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;";
        
        public ActionResult Orders()
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            List<Order> orders = db.GetOrders();
            OrdersPageViewModel viewModel = new OrdersPageViewModel
            {
                Orders = orders,
                Date = DateTime.Now
            };
            return View(viewModel);
        }

        public ActionResult OrderDetails(int year, string country)
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            List<Order> orders = db.GetOrdersForYear(year, country);
            return View(orders);
        }

        public ActionResult Categories()
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            CategoriesPageViewModel vm = new CategoriesPageViewModel
            {
                Categories = db.GetCategories()
            };
            return View(vm);
        }

        public ActionResult Products(int categoryId = 2)
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            ProductsPageViewModel vm = new ProductsPageViewModel();
            vm.Products = db.GetProductsForCategory(categoryId);
            vm.CategoryName = db.GetCategoryName(categoryId);
            return View(vm);
        }

        public ActionResult ProductSearch()
        {
            return View();
        }

        public ActionResult ShowProductSearchResults(string searchText)
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            ProductSearchViewModel vm = new ProductSearchViewModel
            {
                Products = db.SearchProducts(searchText),
                SearchText = searchText
            };
            return View(vm);
        }
    }




    //Create an application that has two pages:
    // /northwind/categories
    // /northwind/products
    
    //On the categories page, display a list of all categories in the northwind database
    //(id, name, description). The name of the category should be a link, that when clicked
    //takes the user to the products page. On the products page, only the products
    //for the category that was clicked on should be displayed. Additionally, on top of
    //the products page, have an H1 that says "Products for Category {CategoryName}"
}