namespace SpecFlowWithSelenium.PageObjects
{
    public interface ILoginPage
    {
        void ClickLoginButton();
        void EnterPassword(string _password);
        void EnterUserName(string _userName);
        string ErrorMessageText();
        void NavigateToUrl(string _url);
        string VerifyInventoryPage();
    }
}