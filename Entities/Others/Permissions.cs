using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Others
{
    public static class Permissions
    {
        public enum Access
        {
            Edificios,
            Usuarios,
            Dashboard,
            Perfil,
        }

        public enum Roles
        {
            Admin,
            Inquilino,
            Propietario
        }

        public static string Admin => Roles.Admin.ToString();
        public static string Inquilino => Roles.Inquilino.ToString();
        public static string Propietario => Roles.Propietario.ToString();
    }
}
