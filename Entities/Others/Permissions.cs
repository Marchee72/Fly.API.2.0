using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Others
{
    public static class Permissions
    {
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string Inquilino = "Inquilino";
            public const string Propietario = "Propietario";

        }

        public static class Access
        {
            public const string Edificios = "Edificios";
            public const string Dashboard = "Dashboard";
            public const string Usuarios = "Usuarios";
            public const string Perfil = "Perfil";
        }
    }
}
