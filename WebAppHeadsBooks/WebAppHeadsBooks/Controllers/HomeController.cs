using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicaFuncional;
using LogicaFuncional.Models;
using WebAppHeadsBooks.Models;
using Newtonsoft.Json;

namespace WebAppHeadsBooks.Controllers
{
    public class HomeController : Controller
    {

        const String TipoError = "alert-danger";
        const String TipoInfo = "alert-info";
        const String TipoSucc = "alert-success";
        const String TipoWarn = "alert-warning";
        const String IconError = "fa-ban";  //Error 
        const String IconInfo = "fa-info";   //Informativo
        const String IconWarn = "fa-warning";   //Advertencia 
        const String IconSucc = "fa-check";    //Exitoso 

        const String KeyCache = "LOGIN";
        public ActionResult Index()
        {

            Login Log = new Login();
            Log.usuario = "";
            Log.password = "";

            ViewBag.MensajeAlert = "";
            ViewBag.TitleAlert = "";
            ViewBag.IconeAlert = "";
            ViewBag.TipoAlert = "";
            return View(Log);
        }

        [HttpPost]
        public ActionResult Index(Login Log)
        {
            String IconAlert = "";
            String MensajeAlert = "";
            String sTipoAlert = "";
            String TitleAlert = "Login Boblioteca";
            LogicaFuncional.ValidarAcceso Valid = new ValidarAcceso();
            if (Log.usuario != null && Log.password != null)
            {
                if (Log.password.Length > 0 && Log.usuario.Length > 0)
                {
                    Response RespValida = Valid.VerificarUsuario(Log.usuario, Log.password);
                    if (RespValida.Ok)
                    {
                        Boolean bcache = AlmacenarLoginCache(Log);
                        return RedirectToAction("Books", "Home");
                    }
                    else
                    {
                        MensajeAlert = RespValida.Mensaje ;
                        sTipoAlert = TipoError;
                        IconAlert = IconError;
                    }
                }
            }
            else
            {
                MensajeAlert = " Se deben ingresar las credenciales para ingresar a la Biblioteca";
                sTipoAlert = TipoWarn;
                IconAlert = IconWarn;
            }

            ViewBag.MensajeAlert = MensajeAlert;
            ViewBag.TitleAlert = TitleAlert;
            ViewBag.IconeAlert = IconAlert;
            ViewBag.TipoAlert = sTipoAlert;


            return View(Log);
        }

        public ActionResult Books()
        {
            ViewBag.Message = "";
            Login LogCache = ValidaCredencialesCache();

            Biblioteca Lib = new Biblioteca();
            List<BibliotecaLibros> Books = new List<BibliotecaLibros>();
            List<Library> Library = new List<Library>();
            Library NewBook = new Library();
            if (LogCache != null)
            {
                if (LogCache.usuario != null )
                {
                    ViewBag.MensajeBox = " ( " + LogCache.usuario + " ) Has Ingresado a la Biblioteca ";
                    
                    Books = Lib.ListarBiblioteca();

                    if (Books.Count > 0) {

                      
                        foreach (var book in Books)
                        {
                            NewBook = new Library();
                            NewBook.Autor = book.Autor;
                            NewBook.titulo = book.titulo;
                            NewBook.Editorial = book.Editorial;
                            NewBook.n_paginas = book.n_paginas;
                            NewBook.sinopsis = book.sinopsis;
                            Library.Add(NewBook);
                        }
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


            return View(Library);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public Login ValidaCredencialesCache()
        {
            String RespCache = "";
            Login LogCache = new Login();

            try
            {
               var cache=  HttpRuntime.Cache.Get(KeyCache);

                if (cache != null) {
                    LogCache = JsonConvert.DeserializeObject<Login>(cache.ToString());
                } 
                return LogCache;
            }
            catch (Exception Ex)
            {
                LogCache = new Login();
                return LogCache;

            }
        }

        public Boolean AlmacenarLoginCache(Login log)
        {
            try {
                String DataInfo = JsonConvert.SerializeObject(log);
                HttpRuntime.Cache.Add(KeyCache,
                                      DataInfo,
                                      null,
                                      System.Web.Caching.Cache.NoAbsoluteExpiration,
                                      TimeSpan.FromMinutes(1),
                                      System.Web.Caching.CacheItemPriority.NotRemovable,
                                      null);

                    return true;
            }
            catch (Exception Ex) {
                return false;
            }
        }


    }
    
}