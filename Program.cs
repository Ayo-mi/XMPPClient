// See https://aka.ms/new-console-template for more information
using XmppDotNet;
using XmppDotNet.Xmpp.Register;

Console.WriteLine("Hello, World!");
public class RegisterAccountHandler : IRegister
{
    private XmppClient xmppClient;
    public RegisterAccountHandler(XmppClient xmppClient)
    {
        this.xmppClient = xmppClient;
    }

    public bool RegisterNewAccount => true;

    public async Task<Register> RegisterAsync(Register register)
    {
        return await Task<Register>.Run(() =>
        {
            register.RemoveAll();
            register.Username = xmppClient.Jid;
            register.Password = xmppClient.Password;

            return register;
        });
    }

}
