using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_USER : Nodo_LUP
    {
        String usuario;
        String usuario_resuelto;

        public ETIQUETA_USER(String usuario)
        {

            this.usuario = usuario;
        }
        public override object ejecutar()
        {
            usuario = usuario.Replace("[+USER]","");
            usuario = usuario.Replace("[-USER]", "");
            usuario = usuario.Replace("(CONTENIDOUSER)", "");
            usuario = usuario.Trim();
            usuario_resuelto = usuario;
            return this.usuario_resuelto;

        }
    }
}