using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaFuncional.Models;
using LogicaFuncional.Data;
namespace LogicaFuncional
{
    public class Biblioteca
    {

        public List<BibliotecaLibros> ListarBiblioteca() 
        {
            List<BibliotecaLibros> DataBooks = new List<BibliotecaLibros>();
            BibliotecaLibros BiblioLib = new BibliotecaLibros();
            try
            {
                using (  DBHeadsEntities  db = new DBHeadsEntities())
                {
                    DataBooks = db.Database.SqlQuery<BibliotecaLibros>("sp_listar_biblioteca").ToList(); 
                }
            }
            catch (Exception Ex)
            {
                string Err = Ex.Message.ToString();
            }
            return DataBooks;
        }


    }
}
