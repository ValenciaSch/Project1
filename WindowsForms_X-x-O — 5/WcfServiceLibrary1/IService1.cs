using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool Login(string login); //проверка Логина и  регистрация;

        //[OperationContract]
        //List<Player> GetAllPlayerGame(string Login);

        [OperationContract]
        string[] GetAllPlayerGame222(string login);


        //[OperationContract]
        //List<Player> GetAllPlayer();

        [OperationContract]
        void SendCoord(string Player, int Namber);// получение   координаты Server

        [OperationContract]
        string[] SendCoordOpponent();//  отправка координаты Сопернику

        [OperationContract]
        void Win_Lose_Draw(string login, string resultGame);

        [OperationContract]

        List<Player> GetAllPlayerWin();//список играков, которые выйграли

        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
