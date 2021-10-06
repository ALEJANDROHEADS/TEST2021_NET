using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaFuncional.Data;
using LogicaFuncional.Models;


namespace LogicaFuncional
{
    public class ValidarAcceso
    {
        public Response VerificarUsuario(String Usu, String Pass)
        {
            Response Resp = new Response(); 
            try {
                tusuario USU = new tusuario();
                //String StrPass;
                using (DBHeadsEntities db = new DBHeadsEntities())
                {
                    USU = db.tusuario.Where(s => s.usuario == Usu).FirstOrDefault<tusuario>();
                }
                //String PassEncry = SeguridadHeads.Encrypt(Pass);
                if (USU != null)
                {
                    String PassDesEncry = SeguridadHeads.Decrypt(USU.password);
                    if (Pass.Equals(PassDesEncry))
                    {
                        Resp.Ok = true;
                    }
                    else
                    {
                        Resp.Ok = false;
                        Resp.Mensaje = "(Usuario y/o Contraseña) Datos Erroneos";
                    }
                }
                else
                {
                    Resp.Ok = false;
                    Resp.Mensaje = "(Usuario y/o Contraseña) Datos Erroneos";
                }

                
               
            }
            catch (Exception Ex) {
                Resp.Ok = false;
                Resp.Error = "Error Valida Usuario :"+Ex.Message;
            }

            return Resp;        
        }

    }
}
