using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP.Arbol_LUP
{
    public class ETIQUETA_STRUCT : Nodo_LUP
    {

        Nodo_LUP usuario;

        public ETIQUETA_STRUCT(Nodo_LUP usuario)
        {
            this.usuario = usuario;
        }
        public override object ejecutar()
        {
            String usuario_final = usuario.ejecutar().ToString();
            return "Pedi los ARCHIVOS DE:"+usuario_final;
        }
    }
}