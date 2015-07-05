using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Windows;

namespace WcfServiceLibrary1
{

    [DataContract]
    public class Player
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Taim { get; set; }

        [DataMember]
        public int Count_Win { get; set; }


        public Player(string login)
        {
            Login = login;
        }
        public Player(string login, int cout)
        {
            Login = login;
            Count_Win = cout;
        }
    }
}
