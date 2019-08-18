using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_PASS : Nodo_LUP
    {

        String pass;
        String pass_resuelto;
        public ETIQUETA_PASS(String pass)
        {
            this.pass = pass;
        }
        public override object ejecutar()
        {
            pass = pass.Replace("[+PASS]", "");
            pass = pass.Replace("[-PASS]", "");
            pass = pass.Replace("(CONTENIDOPASS)","");
            pass = pass.Trim();
            pass_resuelto = pass;
            return this.pass_resuelto;
        }
    }
}