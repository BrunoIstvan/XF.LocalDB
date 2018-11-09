using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XF.LocalDB.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class UsuarioRepository
    {

        public UsuarioRepository() { }


        private static readonly UsuarioRepository instance = new UsuarioRepository();

        public static UsuarioRepository Instance
        {
            get
            {
                return instance;
            }
        }

        public static bool IsAutenticado(Usuario usuario)
        {

            XElement xmlUsuario = XElement.Parse(App.UsuarioVM.Stream);

            var usuarios = new List<Usuario>();

            foreach (var item in xmlUsuario.Elements("usuario"))
            {
                Usuario user = new Usuario()
                {
                    Nome = item.Element("nome").Value,
                    Senha = item.Element("password").Value,
                    Login = item.Element("username").Value
                };
                usuarios.Add(user);
            }

            return usuarios.Any(user => user.Login == usuario.Login && user.Senha == usuario.Senha);

        }

    }

}
