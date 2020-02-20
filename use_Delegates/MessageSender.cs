using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace use_Delegates {

    public delegate int EnvoyerMessage(string message);
    class MessageSender {
        public EnvoyerMessage Envoi;

        public List<int> SendMessage(string message) {
            //Console.WriteLine(Envoi.GetInvocationList()[1].Method.MakeGenericMethod());

            List<int> result = new List<int>();

            // multi results for multi invocations 
            foreach(var fct in Envoi.GetInvocationList()) {
                result.Add((int)fct.DynamicInvoke(message));
            }

            return result;
        }
    }
}
