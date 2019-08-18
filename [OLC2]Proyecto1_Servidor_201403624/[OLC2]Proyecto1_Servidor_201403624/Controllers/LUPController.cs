﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_CQL;
using _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_LUP;
using _OLC2_Proyecto1_Servidor_201403624.Controllers.Analizador_CHISON;
namespace _OLC2_Proyecto1_Servidor_201403624.Controllers
{
    public class LUPController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>/   
        public string Post([FromBody]string value)
        {
            //Sintactico_CQL parser = new Sintactico_CQL();
            Sintactico_LUP parser = new Sintactico_LUP();
            //Sintactico_CHISON parser = new Sintactico_CHISON();

            parser.analizar(value);
            return "API FUNCIONANDO "+ parser.analizar(value); ;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}