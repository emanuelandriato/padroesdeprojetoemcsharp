using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WinFormsApp1.padroes
{

    //https://youtu.be/5oyBsfsoRts
    //interface responsável por garantir que todas as classes implementem o método Enviar
    public interface IEnvioDeNotificacao
    {
        public void Enviar();
    }

    //enumarado para separarmos os tipos de notificação
    public enum TipoEnvio
    {
        Email,
        Sms,
        WhatsApp
    }

    //classes com os parâmetros necessários para a realização dos envios
    public class EmailParams
    {
        /*
        Sugestões para email marketing:             
        MailerLite,HubSpot,SendPulse,Mailchimp,Brevo  
        */
        public string EmailMarketingUser = "noreply@seudominio.xxx.yy";  //essas configuracoes podem ser incluidas em uma classe singleton de parametros do sistema :)
        public string EmailMarketingPass = "password";
        public string EmailMarketingHost = "smtp.exemplo.com";
        public int EmailMarketingPort = 587;
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Corpo { get; set; }
    }

    public class SmsParams
    {
        public string Numero { get; set; }
        public string Mensagem { get; set; }
    }

    public class WhatsAppParams
    {
        public string DispositivoId { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }


    //classe reponsável por enviar emails
    public class EnvioEmail : IEnvioDeNotificacao
    {
        private readonly EmailParams _parametros;
        public EnvioEmail(EmailParams parametros)
        {         
            _parametros = parametros;
        }

        public void Enviar()
        {
            try
            {
                string emailTo = _parametros.Destinatario.Trim();
                var smtp = new SmtpClient
                {
                    Host = _parametros.EmailMarketingHost,
                    Port = _parametros.EmailMarketingPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_parametros.EmailMarketingUser, _parametros.EmailMarketingPass)
                };

                using (var smtpMessage = new MailMessage(_parametros.EmailMarketingUser, emailTo))
                {
                    smtpMessage.Subject = _parametros.Assunto;
                    smtpMessage.Body = _parametros.Corpo;
                    smtpMessage.IsBodyHtml = false; //utilize true caso o corpo do email seja em html
                    smtp.Send(smtpMessage);
                };

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            //implementar o envio
            Console.WriteLine("Email enviado");
        }
    }

    //classe reponsável por enviar SMS
    public class EnvioSMS : IEnvioDeNotificacao
    {
        private readonly SmsParams _parametros;
        public EnvioSMS(SmsParams parametros)
        {
            _parametros = parametros;
        }
        public async void Enviar()
        {
            /*
             precisa utilizar alguma biblioteca, normalmente são pagas mas custam baratinho
             ao contratar esse serviço você receberá esses dados
            */
            string BaseUriSMS = "";         
            string SMSUser = "SMSUSER";
            string SMSPass = "password";
            string SMSNumber = "552799999";



            //implementar o envio
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(BaseUriSMS);
                var url = $"/reluzcap/wsreluzcap.asmx/EnviaSMS?NumUsu=" +       //pegar o link com a empresa contratada
                        $"{HttpUtility.UrlEncode(SMSUser)}" +
                        $"&Senha={HttpUtility.UrlEncode(SMSPass)}" +
                        $"&SeuNum={HttpUtility.UrlEncode(SMSNumber)}" +
                        $"&Celular={HttpUtility.UrlEncode(_parametros.Numero)}" +
                        $"&Mensagem={HttpUtility.UrlEncode(_parametros.Mensagem)}";

                var response = await httpClient.GetAsync(url);
                Console.WriteLine("SMS enviado");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }


    //classe reponsável por enviar whatsapp
    public class EnvioWhatsApp : IEnvioDeNotificacao
    {
        private readonly WhatsAppParams _parametros;
        public EnvioWhatsApp(WhatsAppParams parametros)
        {
            _parametros = parametros;
        }
        public void Enviar()
        {
            //implementar o envio
            Console.WriteLine("WhatsApp enviado");
        }

    }


    //classe Factory responsável por criar a classe necessária, dependendo do tipo de envio solicitado
    public class NotificationFactory
    {
        public static IEnvioDeNotificacao CriarEnvio(TipoEnvio tipo, object parametros)
        {
            return tipo switch
            {
                TipoEnvio.Email => new EnvioEmail(parametros as EmailParams),
                TipoEnvio.Sms => new EnvioSMS(parametros as SmsParams),
                TipoEnvio.WhatsApp => new EnvioWhatsApp(parametros as WhatsAppParams),
            };
        }
    }



    /*
     * exemplo de uso da chamada dos métodos
    var emailParams = new EmailParams { Destinatario = "emanuel", Assunto = "teste", Corpo = "testando" };
    IEnvioNotificacao envioEmail = NotificationFactory.CriarEnvio(TipoEnvio.Email, emailParams);
    envio.Enviar();

    var smsParams = new SmsParams { Mensagem = "", Numero = "999" };
    IEnvioNotificacao envioSMS = NotificationFactory.CriarEnvio(TipoEnvio.Sms, smsParams);
    envio2.Enviar();
    
    */


}
