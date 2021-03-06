﻿using Entity_Layer;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class NegCliente
    {
        // Business Layer
        public string Actualizar(ClienteBO dto) {
            daoCliente dao = new daoCliente();
            return dao.Actualizar(dto);
        }
        public string Eliminar(string dto) {
            daoCliente dao = new daoCliente();
            return dao.Eliminar(dto);
        }
        public string Insertar(ClienteBO dto) {
            daoCliente dao = new daoCliente();
            return dao.Insertar(dto);
        }
        public List<ClienteBO> Listar() {
            daoCliente dao = new daoCliente();
            return dao.Listar();
        }
    }
}
