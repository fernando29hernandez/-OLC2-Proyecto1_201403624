using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_LOGIN : Nodo_LUP

    {
        Nodo_LUP usuario;
        Nodo_LUP pass;

        public ETIQUETA_LOGIN(Nodo_LUP usuario,Nodo_LUP pass) {
            this.usuario = usuario;
            this.pass = pass;
        }
        public override object ejecutar()
        {
            String usuario_final = usuario.ejecutar().ToString();
            String pass_final = pass.ejecutar().ToString();
            return "El usuario es: "+usuario_final+"su contra es: "+pass_final;
        }
    }
}