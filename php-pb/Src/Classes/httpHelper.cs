using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace php_pb.Src.Classes
{
    class httpHelper
    {
        //cria o delegate (que alguém vai ter que implementar)
        public delegate void HttpHelperDelegate(String xml);
        //Método que faz uma requisição http na url indicada
        //o retorno é assincrono e feito pela chamado do delegate que é passado por parametro
        public static void get(String url, HttpHelperDelegate callback)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
            {
                //lê o retorno (xml ou json)
                String xml = e.Result;
                //chama o httpdHelperDelegate que foi passado como argumento "callback"
                callback(xml);
            };
            client.DownloadStringAsync(new Uri(url));
        }
    }
}
