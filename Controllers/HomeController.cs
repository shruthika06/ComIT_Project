using Online_Shopping.Authorization;
using Online_Shopping.DataModel;
using Online_Shopping.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Shopping.Controllers
{
    public class HomeController : Controller
    {
       
        db_WoodWiseEntities contxt = new db_WoodWiseEntities();
        public ActionResult Index(string search,int? page)
        {
            HomeIndexModel model = new HomeIndexModel();
            return View(model.CreateModel(search, 4, page));
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }

        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                var product = contxt.Tbl_Product.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        int prevQty = item.Quantity;
                        if (prevQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new CartItem()
                            {
                                Product = product,
                                Quantity = prevQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("ShoppingCart");
        }
        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                var product = contxt.Tbl_Product.Find(productId);
                cart.Add(new CartItem()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                var count = cart.Count();
                var product = contxt.Tbl_Product.Find(productId);
                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == productId)
                    {
                        int prevQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new CartItem()
                        {
                            Product = product,
                            Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new CartItem()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }
                    Session["cart"] = cart;
                }
                return Redirect(url);
            }

            public ActionResult RemoveFromCart(int productId)
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        cart.Remove(item);
                        break;
                    }
                }
                Session["cart"] = cart;
                return Redirect("Index");
            }

            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
    }
