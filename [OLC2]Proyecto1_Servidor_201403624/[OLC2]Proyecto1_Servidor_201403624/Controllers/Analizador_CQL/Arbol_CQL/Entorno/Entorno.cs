using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_CQL.Arbol_CQL.Entorno
{
    public class Entorno
    {
        LinkedList<Simbolo> tablasimbolos;
        Entorno entornoPadre;
        public Entorno(Entorno entornoPadre)
        {
            tablasimbolos = new LinkedList<Simbolo>();
            this.entornoPadre = entornoPadre;

        }
    }
}