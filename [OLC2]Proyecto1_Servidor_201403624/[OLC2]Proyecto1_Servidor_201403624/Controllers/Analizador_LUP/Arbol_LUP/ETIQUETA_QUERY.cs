using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_QUERY : Nodo_LUP
    {

        Nodo_LUP usuario;
        Nodo_LUP data;

        public ETIQUETA_QUERY(Nodo_LUP usuario,Nodo_LUP data)
        {
            this.usuario = usuario;
            this.data = data;

        }

        public override object ejecutar()
        {
            String usuario_final = usuario.ejecutar().ToString();
            String data_final = data.ejecutar().ToString();
            return "el usuario: " + usuario_final + " pidio lo siguiente: " + data_final;


        }
    }
}