using System;

namespace use_Delegates {
    class Program {
        static void Main(string[] args) {
            

            MessageSender ms = new MessageSender();

            EnvoyerMessage mail = new EnvoyerMessage(m => { Console.WriteLine("Par Mail: " + m); return 1; }) ;
            EnvoyerMessage SMS = new EnvoyerMessage(m => { Console.WriteLine("Par SMS: " + m); return 2; });
            EnvoyerMessage whatsapp = new EnvoyerMessage(m => { Console.WriteLine("Par Whatsapp: " + m); return 3; });
            EnvoyerMessage whatsappSMS = new EnvoyerMessage(m => { { }; return 5; });

            ms.Envoi += mail; // ajout du delegate dans le delegate de MessageSender
            whatsappSMS += whatsapp + SMS;
            //whatsapp += SMS; // ajout du delegate dans un autre delegate
            ms.Envoi += whatsappSMS; // instance du delegate contenant deux fonctions
            ms.Envoi += viber; // fonction standard
            ms.Envoi += m => { Console.WriteLine("par pigeon: " + m); return 6; }; // fonction anonyme

            var result = ms.SendMessage("1 Mon message à moi !");
            //Console.WriteLine(result[0]);

            foreach (var r in result) {
                Console.WriteLine(r);
            }

            ms.Envoi -= mail; // retirer un delegate
            ms.Envoi -= viber; // retirer une fonction

            ms.SendMessage("2 Mon second message !!");

            ms.Envoi -= whatsapp; // retirer sms + whatsapp

            ms.SendMessage("3 Mon meilleur message !!");

        }

        public static int viber(string m) {
            Console.WriteLine("Par viber: " + m);
            return 4;
        }
    }
}
