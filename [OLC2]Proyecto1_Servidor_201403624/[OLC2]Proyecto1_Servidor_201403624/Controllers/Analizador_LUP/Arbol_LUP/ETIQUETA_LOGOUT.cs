using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_LOGOUT : Nodo_LUP
    {

        Nodo_LUP usuario;

        public ETIQUETA_LOGOUT(Nodo_LUP usuario)
        {
            this.usuario = usuario;

        }
        public override object ejecutar()
        {
            String usuario_final = usuario.ejecutar().ToString();
            return "el usuario es: " + usuario_final;
        }
    }
}